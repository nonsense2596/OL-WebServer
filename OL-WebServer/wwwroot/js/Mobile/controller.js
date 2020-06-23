function randomInRange(min, max) {
    return Math.random() < 0.5 ? ((1 - Math.random()) * (max - min) + min) : (Math.random() * (max - min) + min);
}




function markerOnClick(e) {

    var thisid = parseInt(this.options.Id);
    var xhr2 = new XMLHttpRequest();
    xhr2.open("GET", `https://localhost:44372/api/MobileData/${thisid}`, true);
    xhr2.send();
    xhr2.onload = () => {
        var data2 = xhr2.responseText;
        var arr2 = JSON.parse(data2);
        var pm10 = arr2[0].item1;
        var time = arr2[0].item2;
        var name = arr2[0].item3;
        var ipad = arr2[0].item4;
        var lat = this.getLatLng().lat;
        var lng = this.getLatLng().lng;

        const popup_content = `
            <h3>${name}</h3><hr>
            <div class="col-12"><h4>PM10: ${pm10}</h4></div><hr>
            <div class="row"><div class="col-6"><h6><b>Y: </b>${lat}</h6></div><div class="col-6"><h6><b>X: </b>${lng}</h6></div></div><hr>
            <div class="row"><div class="col-6"><h6><b>Time:</b> ${time}</h6></div><div class="col-6"><h6><b>IP: </b>${ipad}</h6></div></div>
        ` ;

        this._popup.setContent(popup_content);
    }
}


var mymap = L.map('mapid');

L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
    maxZoom: 18,
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, ' +
        '<a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
        'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1
}).addTo(mymap);

L.control.scale().addTo(mymap);


var markers = L.markerClusterGroup({ spiderfyOnMaxZoom: true, showCoverageOnHover: true, zoomToBoundsOnClick: true });

var xhr = new XMLHttpRequest();
xhr.open("GET", "https://localhost:44372/api/MobileData", true);
xhr.send();

var lat_top = -90.0000;
var lat_bot = 90.0000;
var lng_lft = 180.0000;
var lng_rgt = -180.0000;

xhr.onload = () => {
    if (xhr.status == 200) {
        var data = xhr.responseText;
        var arr = JSON.parse(data);
        var out = '';
        for (i = 0; i < arr.length; i++) {      
            var id = arr[i].item1;
            var mx = arr[i].item2;
            var my = arr[i].item3;          
            var marker = L.marker([my, mx], { Id: id, icon: myIcon, iconSize: [26, 41], iconAnchor: [12, 41], popupAnchor: [0,-41] });
            markers.addLayer(marker);
            
            marker.bindPopup("loading...", { maxWidth: 700 });
            marker.on('click', markerOnClick);

            if (my < lat_bot)
                lat_bot = my;
            if (my > lat_top)
                lat_top = my;
            if (mx < lng_lft)
                lng_lft = mx;
            if (mx > lng_rgt)
                lng_rgt = mx;
            console.log(`lat: ${my} lng: ${mx}`);
        }
    } else {
        console.error('Error!');
    }

    console.log(`lat_bot:${lat_bot} lat_top:${lat_top} lng_lft:${lng_lft} lng_rgt:${lng_rgt}`);
    mymap.addLayer(markers);

    var bounds = new L.LatLngBounds([[lat_top, lng_lft], [lat_bot, lng_rgt]]);

    //mymap.setView([0, 0], 4);
    mymap.fitBounds(bounds);
};






//mymap.fitBounds(markers.getBounds());