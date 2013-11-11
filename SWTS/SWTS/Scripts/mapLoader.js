var geocoder;
var map;
function initialize() {
    geocoder = new google.maps.Geocoder();
    
    if ($("div.supplierInfo .mapLat").attr("name") > 0) {
        var lat = parseFloat($("div.supplierInfo .mapLat").attr("name"));
        var lng = parseFloat($("div.supplierInfo .mapLng").attr("name"));
    }
    else if($("div.supplier .mapLat").attr("value") > 0){
        var lat = $("div.supplier .mapLat").attr("value").toString().replace(",", ".");
        var lng = $("div.supplier .mapLng").attr("value").toString().replace(",", ".");
    }
    
    var latAndLng = new google.maps.LatLng(lat, lng);
    var mapOptions = {
        zoom: 16,
        center: latAndLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
    
    var marker = new google.maps.Marker({
        position: latAndLng,
        map: map,
    });
}

function codeAddress(addressInput, cityInput, countryInput) {

    if (typeof (addressInput) === 'undefined') addressInput = "";
    if (typeof (cityInput) === 'undefined') cityInput = "";
    if (typeof (countryInput) === 'undefined') countryInput = "";

    var address = addressInput + " " + cityInput + " " + countryInput;

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
            
            $(".supplier .lat").attr("value", results[0].geometry.location.lat().toString().replace(".", ","));
            $(".supplier .lng").attr("value", results[0].geometry.location.lng().toString().replace(".", ","));
        }
    });
}

$('.geocodeAddress').on('change', function () {
    if ($(".geocodeAddress").attr("value").length >= 3)
    codeAddress($('.geocodeAddress').attr("value"), $('.geocodeCity').attr("value"), $('.geocodeCountry').attr("value"));
});
$('.geocodeCity').on('change', function () {
    if ($(".geocodeCity").attr("value").length >= 3)
        codeAddress($('.geocodeAddress').attr("value"), $('.geocodeCity').attr("value"), $('.geocodeCountry').attr("value"));
});
$('.geocodeCountry').on('change', function () {
    if ($(".geocodeCountry").attr("value").length >= 3)
        codeAddress($('.geocodeAddress').attr("value"), $('.geocodeCity').attr("value"), $('.geocodeCountry').attr("value"));
});


function loadScript() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "http://maps.googleapis.com/maps/api/js?key=AIzaSyCV6pBeEmMNqozllUvxpKZgkf0YME469pE&sensor=true&callback=initialize";
    document.body.appendChild(script);
}

window.onload = loadScript;