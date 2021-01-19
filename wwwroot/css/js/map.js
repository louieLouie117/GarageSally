function initMap(){
    let latLng

    const map= new googlemaps.Map(document.getElementById('map'), {
        zoom: 13,
        fullscreenControl: true,
        zoomControl: true,
        streetViewControl: false
    });

    const userLocation= new google.maps.Marker({
        position: latLng,
        map,
        title: "Garage Sally User"
    });

    navigator.geolocation.getCurrentPosition(function(position) {
        latLng= new google.maps.LatLng(position.coords.latitude,
            position.coords.longitude);
        map.setCenter(latLng);
        userLocation.setPosition(latLng);
    }), function (error) {
        console.log(`GeoLocation Failed ${error}`);
        map.setCenter({
            lat: 37.221,
            lng: -122.0841
        })
    }
}