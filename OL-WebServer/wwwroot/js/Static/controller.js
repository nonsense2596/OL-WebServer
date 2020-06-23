function randomInRange(min, max) {
    return Math.random() < 0.5 ? ((1 - Math.random()) * (max - min) + min) : (Math.random() * (max - min) + min);
}
var $activemarker;



function markerOnClick(e) {
    var thisid = parseInt(this.options.Id);
    var xhr2 = new XMLHttpRequest();
    xhr2.open("GET", `https://localhost:44372/api/StaticData/${thisid}`, true);
    xhr2.send();
    xhr2.onload = () => {
        var data2 = xhr2.responseText;
        var arr2 = JSON.parse(data2);
        var name = arr2[0].item3;
        var sideroutput = "";
        var lastknown_ipad = arr2[arr2.length - 1].item4;
        var modalpm10 = "";
        var modaldate = "";
        var modalipad = `<h6>Last known IP address: ${lastknown_ipad}</h6><br>`;

        var lat = this.getLatLng().lat;
        var lng = this.getLatLng().lng;

        for (i = 0; i < arr2.length; i++) {
            var pm10 = arr2[i].item1;
            var time = arr2[i].item2;
            modalpm10 += `${pm10}<br>`;
            modaldate += `${time}<br>`;
        }
        $('.modal-ipad').html(modalipad);
        $('.modal-pm10').html(modalpm10);
        $('.modal-date').html(modaldate);
        $('.modal-x').html(lng);
        $('.modal-y').html(lat);

        $activemarker = $(this._icon);
        $("#exampleModalLongTitle").html(name);
        $('#exampleModalLong').modal('show');
    }
    $(this).css("display", "none");

}

//var mymap = L.map('mapid').setView([35.026, 138.889], 1);
var mymap = L.map('mapid').setView([0, 0], 2);

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
xhr.open("GET", "https://localhost:44372/api/StaticData", true);
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

    mymap.fitBounds(bounds);
};





