// map.js will call the google maps api (once implemented)
// and generate to div on the html side with an ID of "map"
// 

function initMap(){
    // latLng will hold an object location for
    // where the map should be centered on once
    // loaded.
    // example:( let latLng= {lat: 37.221, lng: -122.0841}; )...
    // example coordinates are google in san fransico
    let latLng;

    // generate map with specific controls enabled or disabled
    // zoom determines the closeness of the map 0 being the furthest out
    // center option determines where the map will start at (currently...
    //   null for user location to be set)
    const map= new googlemaps.Map(document.getElementById('map'), {
        zoom: 13,
        fullscreenControl: true,
        zoomControl: true,
        streetViewControl: false
    });

    // userLocation is a marker made to pin
    // where the use is current at
    // latLng is currently null may cause issues without
    // default values
    const userLocation= new google.maps.Marker({
        position: latLng,
        map,
        title: "Garage Sally User"
    });

    // navigator gets the location of user from the browser
    // user must allow location access on the browser either mobile or pc
    // if succesful latLng variable will be set to the the users location
    // following will set the center of the map to the user location
    // also will a pin be placed
    // pin will also be given a listener for when clicked it will display
    // provided info
    // if navigator fails the map center will be set to a default value
    // no marker will be set.
    navigator.geolocation.getCurrentPosition(function(position) {
        latLng= new google.maps.LatLng(position.coords.latitude,
            position.coords.longitude);
        map.setCenter(latLng);
        userLocation.setPosition(latLng);
        userLocation.addListener('click', () => {
            new google.maps.InfoWindow().open(map, userLocation)
        })
    }), function (error) {
        console.log(`GeoLocation Failed ${error}`);
        map.setCenter({
            lat: 37.221,
            lng: -122.0841
        })
    }
}


// details of the user location info is subject to change
// may not be something used in the future
// will be used for garage sale pins
function setUserLocationMarkerInfo(){ 
    () =>userLocationContent={
        content:
        '<div id="marker-wrapper">' +
            '<div id="marker-title-wrapper">' +
                '<h1 id="marker-title class="firstHeading">You Are Here!</h1>' +
            '</div>' +
        '<div id="marker-body">' +
          '<p>This is where you currently are located.' +
          'Garage sale markers will be generated around you.</p>' +
        '</div>' +
      '</div>'
    }
}