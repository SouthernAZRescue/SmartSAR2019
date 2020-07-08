using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.WebCams.Core.ValueTypes
{
    public class CameraGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Camera> Cameras { get; set; } = new List<Camera>();
    }
}
