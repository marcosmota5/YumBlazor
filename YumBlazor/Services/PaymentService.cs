﻿using Microsoft.AspNetCore.Components;
using Stripe.Checkout;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;
using YumBlazor.Utility;

namespace YumBlazor.Services;

public class PaymentService
{
    private readonly NavigationManager _navigationManager;
    private readonly IOrderRepository _orderRepository;

    public PaymentService(NavigationManager navigationManager, IOrderRepository orderRepository)
    {
        _navigationManager = navigationManager;
        _orderRepository = orderRepository;
    }

    public Session CreateStripeCheckoutSession(OrderHeader orderHeader)
    {
        var lineItems = orderHeader.OrderDetails
            .Select(order => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "cad",
                    UnitAmountDecimal = (order.Price * 100), // Convert to cents
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = order.ProductName,
                    },
                },
                Quantity = order.Count,
            }).ToList();

        var options = new SessionCreateOptions
        {
            SuccessUrl = $"{_navigationManager.BaseUri}order/confirmation/{{CHECKOUT_SESSION_ID}}",
            CancelUrl = $"{_navigationManager.BaseUri}cart",
            LineItems = lineItems,
            Mode = "payment",
        };


        var service = new SessionService();
        var session = service.Create(options);

        return session;
    }

    public async Task<OrderHeader> CheckPaymentStatusAndUpdateOrder(string sessionId)
    {
        var orderHeader = await _orderRepository.GetOrderBySessionIdAsync(sessionId);

        var service = new SessionService();
        var session = await service.GetAsync(sessionId);

        if (session.PaymentStatus.ToLower() == "paid")
        {
            orderHeader = await _orderRepository.UpdateStatusAsync(orderHeader.Id, SD.StatusApproved, session.PaymentIntentId);
        }

        return orderHeader;
    }
}
