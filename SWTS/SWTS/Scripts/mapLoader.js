function initialize() {

    var lat = parseFloat($("div.supplierInfo .mapLat").attr("name"));
    var lng = parseFloat($("div.supplierInfo .mapLng").attr("name"));
    var supplier = $("div.supplier h2").html();
    
    var latAndLng = new google.maps.LatLng(lat, lng);
    var mapOptions = {
        zoom: 16,
        center: latAndLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
    
    var marker = new google.maps.Marker({
        position: latAndLng,
        map: map,
        title: supplier
    });
}

function loadScript() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "http://maps.googleapis.com/maps/api/js?key=AIzaSyCV6pBeEmMNqozllUvxpKZgkf0YME469pE&sensor=true&callback=initialize";
    document.body.appendChild(script);
}

window.onload = loadScript;