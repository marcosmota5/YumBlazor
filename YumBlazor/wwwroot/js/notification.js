window.ShowToastr = function (type, message) {
    if (typeof toastr === 'undefined') {
        console.error('Toastr library is not loaded.');
        return;
    }
    switch (type) {
        case 'success':
            toastr.success(message);
            break;
        case 'info':
            toastr.info(message);
            break;
        case 'warning':
            toastr.warning(message);
            break;
        case 'error':
            toastr.error(message);
            break;
        default:
            console.warn('Unknown notification type:', type);
    }
}