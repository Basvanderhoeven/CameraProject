using System;
using System.Collections.Generic;
using System.Text;

namespace CLI_Cameras
{
    public class Camera
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
