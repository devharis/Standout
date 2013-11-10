var geocoder;
var map;
function initialize() {
    geocoder = new google.maps.Geocoder();
    var lat = parseFloat($("div.supplierInfo .mapLat").attr("name"));
    var lng = parseFloat($("div.supplierInfo .mapLng").attr("name"));
    var supplier = $("div.supplier h2").html();
    
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
        title: supplier
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

$('.geocodeAddress').change('input', function () {
    if ($(".geocodeAddress").attr("value").length >= 3)
    codeAddress($('.geocodeAddress').attr("value"), $('.geocodeCity').attr("value"), $('.geocodeCountry').attr("value"));
});
$('.geocodeCity').change('input', function () {
    if ($(".geocodeCity").attr("value").length >= 3)
        codeAddress($('.geocodeAddress').attr("value"), $('.geocodeCity').attr("value"), $('.geocodeCountry').attr("value"));
});
$('.geocodeCountry').change('input', function () {
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