// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
const langCode = 'es-GT';

// Write your JavaScript code.
$(function () {
    //Verifica si tiene el loader
    var iloader = $('body').find('.loader');
    if (iloader.length == 0) {
        $('body').append('<div class="loader"></div>');
    }
    $(document).bind('ajaxStart', function () {
        blockUI();
    }).bind('ajaxStop', function () {
        unblockUI();
    });
    //form submit
    $('form').on('submit', function () {
        blockUI();
    });
    //Tips
    LoadTips();
});
$.ajaxSetup({
    error: function (event, request, settings) {
        unblockUI();
    }
});
blockUI = () => {
    $('.loader').fadeIn('fast');
}
unblockUI = () => {
    $('.loader').fadeOut('slow');
}
$(document).ready(function () {

    $("input[type=text]").keyup(function () {
        var start = this.selectionStart, end = this.selectionEnd;
        var valor = $(this).val();
        $(this).val($(this).val().toUpperCase());
        this.setSelectionRange(start, end);

        console.log($(this).val().toUpperCase())
    });

    // Menu activo  
    MarcarMenuActivo();
});

//Cambio de Empresa
$('#CurrentEmpresa').on('change', function () {
    let cod_emp = $('#CurrentEmpresa option:selected')[0].value;
    let url = $('#CurrentEmpresa').attr('data-url');
    $.post(url, { cod_emp }, function () {
        window.location.reload();
    });
});
//Color Picker
$('#btnColorPicker').on('click', function () {
    let theme_color = $('body').attr("data-theme");
    $('#btnColorPicker > i').toggleClass('fa-chevron-up');
    $('#btnColorPicker > i').toggleClass('fa-chevron-down');
    $('#ColorPicker').fadeToggle();
});
$('#btnColorPicker').on('click', function () {
    let theme_color = $('body').attr("data-theme");
    $('#btnColorPicker > .color-picker').removeClass('active');
    $('#btnColorPicker > .color-picker[data-theme="' + theme_color + '"]').addClass('active');
});
$('.color-picker').on('click', function () {
    let theme_color = $(this).attr("data-theme");
    let url = $(this).attr('data-url');
    $('#btnColorPicker > .color-picker').removeClass('active');
    $('#btnColorPicker > .color-picker[data-theme="' + theme_color + '"]').addClass('active');
    $('body').attr("data-theme", theme_color);
    $.post(url, { theme_color });
});
//Salir
$('#bntSalir').on('click', function () {
    /*
    Confirm('¿Desea salir del sistema?', function () {
        window.location = $('#bntSalir').attr('data-url');
    });
    */
    window.location = $('#bntSalir').attr('data-url');
});

function MarcarMenuActivo() {
    $('#accordionMenu .list-group-item-action').on('click', function () {
        let menuId = $(this).attr('menu-id');
        let menuPadre = $(this).attr('menu-padre');
        localStorage.setItem("menu-id", menuId);
        localStorage.setItem("menu-padre", menuPadre);
    });
    let markId = localStorage.getItem('menu-id');
    let markPadre = localStorage.getItem('menu-padre');
    $('#accordionMenu .accordion-header[menu-id="' + markPadre + '"] button').click();
    $('#accordionMenu .list-group-item-action[menu-id="' + markId + '"]').addClass('active');
}

function LoadTips() {

    $('[data-bs-toggle="tooltip"]').tooltip({
        placement: 'bottom'
    });

    //Form control nav with enter
    let list_controls = '.form-next';
    var $inp = $(list_controls);
    $inp.bind('keypress', function (e) {
        var n = $(list_controls).length;
        var key = e.which;
        if (key == 13) {
            e.preventDefault();
            var nextIndex = $inp.index(this) + 1;
            if (nextIndex < n) {
                $(list_controls)[nextIndex].focus();
            }
        }
    });

    //Table
    $.each($('.table-auto').not('.ready-table'), function (index, item) {
        $(item).addClass('ready-table');
        Table(item);
    });
    $.each($('.table-auto-responsive').not('.ready-table-responsive'), function (index, item) {
        $(item).addClass('ready-table-responsive');
        TableResponsive(item);
    });
}
function numberWithCommas(number) {
    let numberClean = numberWithOutCommas(number);
    return new Intl.NumberFormat(langCode, { minimumFractionDigits: 2 }).format(numberClean);
}
function numberWithOutCommas(number) {
    return number.toString().replace(/,/g, "");
}
function DownloadFile(request, data = null) {
    $.post(request, data, function (result) {
        var pom = document.createElement('a');
        pom.setAttribute('href', 'data:' + result.mimeType + ';base64,' + result.file);
        pom.setAttribute('download', result.fileName);
        if (document.createEvent) {
            var event = document.createEvent('MouseEvents');
            event.initEvent('click', true, true);
            pom.dispatchEvent(event);
            Notify('Reporte generado exitosamente.', 'success');
        }
        else {
            pom.click();
        }
    });
}

function InputNumbers(e) {
    var key = window.event ? e.which : e.keyCode;
    if (key < 48 || key > 57) {
        e.preventDefault();
    }
}

function InputNumbersDecimal(e) {
    var key = window.event ? e.which : e.keyCode;
    if ((key < 48 || key > 57) && (key != 46)) {
        e.preventDefault();
    }
}

function InputLetters(e) {
    var key = e.keyCode || e.which,
        tecla = String.fromCharCode(key).toLowerCase(),
        letras = " áéíóúabcdefghijklmnñopqrstuvwxyz",
        especiales = [8, 37, 39, 46],
        tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        e.preventDefault();
    }
}

function ShowImg(img, nombre, codigo) {
    swal({
        title: nombre + '<br> <h5>' + codigo + '</h5>',
        text: "<img src='" + img + "' style='height:250px; width:250px'>",
        html: true,
        position: 'top-center',
    });

}

function InputNumbers(e) {
    var key = window.event ? e.which : e.keyCode;
    if (key < 48 || key > 57) {
        e.preventDefault();
    }
}

function InputNumbersDecimal(e) {
    var key = window.event ? e.which : e.keyCode;
    if ((key < 48 || key > 57) && (key != 46)) {
        e.preventDefault();
    }
}

function InputLetters(e) {
    var key = e.keyCode || e.which,
        tecla = String.fromCharCode(key).toLowerCase(),
        letras = " áéíóúabcdefghijklmnñopqrstuvwxyz",
        especiales = [8, 37, 39, 46],
        tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        e.preventDefault();
    }
}

function Mayusculas(string) {
    return string.toUpperCase();
}

function GetDateStart() {
    let f = new Date();
    return f.setDate(1);
}
function GetDateEnd() {
    let f = new Date();
    return new Date(f.getFullYear(), f.getMonth() + 1, 0);
}

function PasteFileImg(event, idImg) {
    var selectedFile = event.target.files[0];
    var reader = new FileReader();
    var imgtag = document.getElementById(idImg);
    imgtag.title = selectedFile.name;
    reader.onload = function (event) { imgtag.src = event.target.result; };
    reader.readAsDataURL(selectedFile);
}

function DesmarcarMenuActivo() {
    $('#accordionMenu .list-group-item-action').removeClass('active');
}

function GetDateStart() {
    let f = new Date();
    return f.setDate(1);
}
function GetDateEnd() {
    let f = new Date();
    return new Date(f.getFullYear(), f.getMonth() + 1, 0);
}