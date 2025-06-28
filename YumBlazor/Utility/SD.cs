using YumBlazor.Data;

namespace YumBlazor.Utility;

public static class SD
{
    public static string Role_Admin = "Admin";
    public static string Role_Customer = "Customer";

    public static string StatusPending = "Pending";
    public static string StatusApproved = "Approved";
    public static string StatusReadyForPickUp = "ReadyForPickUp";
    public static string StatusCompleted = "Completed";
    public static string StatusCancelled = "Cancelled";

    public static List<OrderDetail> ConvertShoppingCartListToOrderDetail(List<ShoppingCart> shoppingCarts)
    {
        return shoppingCarts.Select(cart => new OrderDetail
        {
            ProductId = cart.ProductId,
            Count = cart.Count,
            Price = cart.Product.Price,
            ProductName = cart.Product.Name
        }).ToList();
    }
}