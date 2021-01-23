// map.js will call the google maps api (once implemented)
// and generate to div on the html side with an ID of "map"
// 

function initMap(){
    // latLng will hold an object location for
    // where the map should be centered on once
    // loaded.
    // default coordinates are google in san fransico
    let latLng= {
      lat: 37.221,
      lng: -122.0841
    }
  
    // generate map with specific controls enabled or disabled
    // zoom determines the closeness of the map 0 being the furthest out
    // center option determines where the map will start at (currently...
    //   null for user location to be set)
    const map= new google.maps.Map(document.getElementById('map'), {
        // center: latLng,
        zoom: 13,
        fullscreenControl: false,
        mapTypeControl: false,
        rotateControl: false,
        scaleControl: false,
        zoomControl: true,
        streetViewControl: false
    });
  
    setMapCenter(map, latLng);
  }
  
  function setMapCenter(map, latLng){
  
    // userLocation.setPosistion(latLng);
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
        const marker= new google.maps.Marker({
          position: latLng,
          map,
          title: "User"
        })
        marker.addListener("click", () =>{
          new google.maps.InfoWindow({
            content: setMarkerInfo('USER', 'TEST THIS IS WHERE YOU ARE!')
          }).open(map, marker);
        });
    }), function (error) {
        console.log(`GeoLocation Failed ${error}`);
        map.setCenter(latLng)
    }
  }
  
  // REF for loading in a radius:
  // https://developers.google.com/maps/documentation/javascript/geometry
  // https://developers.google.com/maps/documentation/javascript/reference#spherical
  function getRadiusMarkers(map){
    let garageSales= [{
        username: "Test_User",
        lat: 37.000,
        lng: -100.0064,
        details: "info here"
    }];
    let markers=[];
    let marker;
    garageSales.forEach(garageSale => {
        markers.push(
            marker= new google.maps.Marker({
                position: new google.maps.LatLng(garageSale.lat, garageSale.lng),
                map,
                title: garageSale.username
            })
        );
        marker.addListener("click", () => {
            new google.maps.InfoWindow({
                content: setMarkerInfo(garageSale.username, garageSale.details)
            });
        });
    });
  }
  
  function setMarkerInfo(username, info){
    // details of the user location info is subject to change
    // may not be something used in the future
    // will be used for garage sale pins
    return '<div id="marker-wrapper">' +
            '<div id="marker-title-wrapper">' +
                '<h1 id="marker-title class="firstHeading">' + username + '</h1>' +
            '</div>' +
            '<div id="marker-body">' +
                '<p>' + info + '</p>' +
            '</div>' +
        '</div>'
  }
  
  function directionsFunction(){}