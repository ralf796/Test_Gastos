function Table(obj, sizeWindow) {
    try {
        if (sizeWindow == null || sizeWindow == 0) {
            var size = $(obj).attr('data-height');
            if (size != undefined && size != '' && size != null)
                sizeWindow = parseFloat(size);
            else
                sizeWindow = window.innerHeight - 250;
        }

        var orderColumn = false;
        var objectOrder = $(obj).attr('data-object-order');
        if (objectOrder != undefined && objectOrder != '' && objectOrder != null) {
            orderColumn = true;
        }

        var colOrderColumn = false;
        var objectColOrder = $(obj).attr('data-object-colorder');
        if (objectColOrder != undefined && objectColOrder != '' && objectColOrder != null) {
            colOrderColumn = true;
            $(obj).addClass('nowrap');
        }
        else {
            $(obj).addClass('nowrap w-100');
        }

        $(obj).addClass('nowrap w-100');
        let tableOut = $(obj).DataTable({
            destroy: true,
            fixedHeader: true,
            scrollCollapse: true,
            scrollY: sizeWindow,
            scrollX: true,
            info: false,
            paginate: false,
            language: 'es-ES.json',
            ordering: orderColumn,
            colReorder: colOrderColumn
        });

        var objectSearch = $(obj).attr('data-object-search');
        if (objectSearch != undefined && objectSearch != '' && objectSearch != null) {
            $(objectSearch).on('keyup', function () {
                tableOut.search(this.value).draw();
            });
        }

        return tableOut;

    } catch (err) {
        console.log(err);
    }
}
function TableNoSearch(obj, sizeWindow) {
    try {
        console.log(obj);
        if (sizeWindow == null || sizeWindow == 0) {
            var size = $(obj).attr('data-height');
            if (size != undefined && size != '' && size != null)
                sizeWindow = parseFloat(size);
            else
                sizeWindow = window.innerHeight - 250;
        }

        var orderColumn = false;
        var objectOrder = $(obj).attr('data-object-order');
        if (objectOrder != undefined && objectOrder != '' && objectOrder != null) {
            orderColumn = true;
        }

        var colOrderColumn = false;
        var objectColOrder = $(obj).attr('data-object-colorder');
        if (objectColOrder != undefined && objectColOrder != '' && objectColOrder != null) {
            colOrderColumn = true;
            $(obj).addClass('nowrap');
        }
        else {
            $(obj).addClass('nowrap w-100');
        }
        let tableOut = $(obj).DataTable({
            destroy: true,
            fixedHeader: true,
            scrollCollapse: true,
            scrollY: sizeWindow,
            scrollX: true,
            info: false,
            paginate: false,
            language: 'es-ES.json',
            ordering: orderColumn,
            colReorder: colOrderColumn
        });


        var objectSearch = $(obj).attr('data-object-search');
        if (objectSearch != undefined && objectSearch != '' && objectSearch != null) {
            $(objectSearch).on('keyup', function () {
                tableOut.search(this.value).draw();
            });
        }

        return tableOut;
    } catch (err) {
        console.log(err);
    }
}
function TableResponsive(obj, sizeWindow) {
    try {
        if (sizeWindow == null || sizeWindow == 0) {
            var size = $(obj).attr('data-height');
            if (size != undefined && size != '' && size != null)
                sizeWindow = parseFloat(size);
            else
                sizeWindow = window.innerHeight - 250;
        }

        var orderColumn = false;
        var objectOrder = $(obj).attr('data-object-order');
        if (objectOrder != undefined && objectOrder != '' && objectOrder != null) {
            orderColumn = true;
        }

        $(obj).addClass('nowrap w-100');
        let tableOut = $(obj).DataTable({
            destroy: true,
            fixedHeader: true,
            scrollCollapse: true,
            scrollY: sizeWindow,
            scrollX: true,
            info: false,
            paginate: false,
            language: 'es-ES.json',
            responsive: true,
            ordering: orderColumn
        });

        var objectSearch = $(obj).attr('data-object-search');
        if (objectSearch != undefined && objectSearch != '' && objectSearch != null) {
            $(objectSearch).on('keyup', function () {
                tableOut.search(this.value).draw();
            });
        }
        return tableOut;

    } catch (err) {
        console.log(err);
    }
}