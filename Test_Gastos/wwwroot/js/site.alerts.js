const NotifyIcon = {
    success: 'success',
    info: 'info',
    warning: 'warning',
    error: 'error',
    none: 'none'
};
// Notifiaciones
Notify = (text, icon = NotifyIcon.info) => {
    $.toast({
        heading: '',
        text: text,
        icon: icon,
        //showHideTransition: 'slide',
        position: 'bottom-center',
        //bgColor: '#fff',
        //textColor: '#6a0527',
        hideAfter: 2500
    });


}
Notify = (text, icon = NotifyIcon.info, callback = null) => {
    if (callback == null) {
        $.toast({
            heading: '',
            text: text,
            icon: icon,
            //showHideTransition: 'slide',
            position: 'bottom-center',
            //bgColor: '#fff',
            //textColor: '#6a0527',
            hideAfter: 1800
        });
    } else {
        $.toast({
            heading: '',
            text: text,
            icon: icon,
            //showHideTransition: 'slide',
            position: 'bottom-center',
            //bgColor: '#fff',
            //textColor: '#6a0527',
            hideAfter: 1800,
            afterHidden: callback
        });
    }
}
// Alerta
Alert = (text, icon = NotifyIcon.info, callback = null, isHtml = false) => {
    if (callback == null && isHtml == false) {
        swal('', text, icon);
    } else if (callback == null && isHtml) {
        swal({ title: '', text: text, type: icon, html: isHtml });
    } else {
        swal({ title: '', text: text, type: icon, html: isHtml }, callback);
    }
}
AlertMessage = (text, isHtml = false) => {
    swal({ title: '', text: text, confirmButtonText: 'Aceptar', html: isHtml });
}
// Confirmación de accion
Confirm = (text, callback, isHtml = false) => {
    swal({ title: '', text: text, html: isHtml, showCancelButton: true, cancelButtonText: 'No', confirmButtonText: 'Si', type: 'info' }, function (isConfirm) {
        if (isConfirm) {
            callback();
        }
    });
}