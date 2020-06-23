var MarkerIcon = L.Icon.extend({
    options: {
      Id: "",
      iconSize: [25, 41],
      iconAnchor: [12, 41],
      popupAnchor:[0,-41]
      /*iconSize: [64, 64],*/
      /*shadowSize: [50, 64],
      iconAnchor: [22, 94],
      shadowAnchor: [4, 62],
      popupAnchor: [-3, -76]*/
    }
  });

var myIcon = new MarkerIcon({
    iconUrl: './leaflet/images/marker-icon.png',
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [0, -41]
});
/*var myIcon2 = new MarkerIcon({
    iconUrl: 'jakab.png',
    iconSize: [70, 70],
    iconAnchor: [22, 94],
    popupAnchor: [-3, -76],
});
var myIcon3 = new MarkerIcon({
    iconUrl: 'tevesz.png',
    iconSize: [70, 70],
    iconAnchor: [22, 94],
    popupAnchor: [-3, -76],
});*/