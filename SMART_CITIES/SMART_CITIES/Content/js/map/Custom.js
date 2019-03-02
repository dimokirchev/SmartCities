
window.onload = function () {          
    var mapOptions = {
        center: new google.maps.LatLng(48.148598, 17.107748),
        zoom: 10,
        scrollwheel: true,
        gestureHandling: 'cooperative',
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var infoWindow = new google.maps.InfoWindow();          
    var latlngbounds = new google.maps.LatLngBounds();
    var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
    var url = "/Home/GetMapInfoes";
    var my_json;
    alert("test");
    $.getJSON(url, function (json) {        
        my_json = json;
        $.each(my_json, function (key, value) {         
            var latlng = new google.maps.LatLng(value.Latitude, value.Longitude);
            //var distance = google.maps.geometry.spherical.computeDistanceBetween(value.Longitude, latLngB);
            placeMarker(map, latlng,value);
        });
    });

}

// Създаваме маркера и радиуса към него , спрямо геогравските координати , които сме записали в базата
function placeMarker(map, location, value) {
    console.log(map);
    console.log(location);
    console.log(value);
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });

    var infowindow = new google.maps.InfoWindow({
        content: '' + value.Address
        + '<video class="Myclass"  src="' + value.file + '" id="'+value.Id+'" width="200" height="200"  controls></video>',
        maxWidth: 200,
        map:map
    });
           
    marker.addListener('click', function () {
        infowindow.open(map, marker);              
    });

    var sunCircle = {
        strokeColor: "black",
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: "red",
        fillOpacity: 0.35,
        map: map,
        center: location,
        radius: 100 // in meters
    };
    cityCircle = new google.maps.Circle(sunCircle);
    //cityCircle.bindTo('center', marker, 'position');
    //infowindow.open(map, marker);
    infowindow.close();
    // Видео попЪП  - видеото да с епоказва на цял екран
    google.maps.event.addListener(infowindow, 'domready', function () {
        $('.Myclass').on('click', function () {
            var modal = document.getElementById('myModalImage');
            var targetSRC = $(this).attr('src');
            var modalImg = document.getElementById("img01");
            modalImg.src = targetSRC;
            modal.style.display = "block";
            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
            }
        });
    });
} 