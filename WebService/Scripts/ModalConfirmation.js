$(document).ready(function () {
    $('a[data-confirm]').click(function () {
        var href = $(this).attr('href');
        $('#myModal').find('.modal-title').text($(this).attr('data-confirm'));
        $('#dataConfirmOK').attr('href', href);
        $('#myModal').modal({ show: true });
        return false;
    });
});