$(document).ready(function () {
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
});