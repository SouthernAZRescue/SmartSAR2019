using System;
using System.Collections.Generic;
using System.Text;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Services
{
    public class WebCamCatalogOptions
    {
        public const string WebCams = "WebCams"; // Configuration key to bind

        public IReadOnlyList<CameraGroup> CameraGroups { get; set; }
    }
}
