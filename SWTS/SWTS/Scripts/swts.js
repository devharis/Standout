$(document).ready(function () {
    
    // This function uses ajax to call controller action and renders it to a div.
    $('.editSupplier').on( "click", function () {
        $.ajax({
            url: '/Home/EditSupplier',
            type: 'GET',
            contentType: 'application/json',
            data: { id: $(".supplierInfo .supplierId").attr("name") },
            success: function (result) {
                var map = $(".map");
                $("div.supplier").html(result);
                $(".map").replaceWith(map);
            },
            complete: function () {
                $("form").each(function() { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
            }            
        });

    });
    
    // This function is changing menu icons on click
    $('.ui-menu .accordion-heading').on("click", function (e) {
        $(this).find('i').toggleClass('glyphicon-minus-sign glyphicon-plus-sign', 200);
    });
});