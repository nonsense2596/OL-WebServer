using System;
using System.Collections.Generic;

namespace WebApiTeszt2.Models
{
    public partial class DataMs
    {
        public int DataId { get; set; }
        public int Pm10 { get; set; }
        public int SensorId { get; set; }
        public string CoordX { get; set; }
        public string CoordY { get; set; }
        public string Date { get; set; }

        public virtual Sensors Sensor { get; set; }
    }
}
