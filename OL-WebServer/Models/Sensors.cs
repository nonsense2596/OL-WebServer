using System;
using System.Collections.Generic;

namespace WebApiTeszt2.Models
{
    public partial class Sensors
    {
        public Sensors()
        {
            DataMs = new HashSet<DataMs>();
            DataSs = new HashSet<DataSs>();
        }

        public int SensorId { get; set; }
        public string Name { get; set; }
        public bool Mode { get; set; }
        public string Ip { get; set; }
        public string CoordX { get; set; }
        public string CoordY { get; set; }

        public virtual ICollection<DataMs> DataMs { get; set; }
        public virtual ICollection<DataSs> DataSs { get; set; }
    }
}
