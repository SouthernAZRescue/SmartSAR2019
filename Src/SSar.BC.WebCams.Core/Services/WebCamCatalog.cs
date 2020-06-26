using System;
using System.Collections.Generic;
using System.Text;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Services
{
    public class WebCamCatalog : IWebCamCatalog
    {
        public WebCamCatalog(IReadOnlyList<CameraGroup> cameraGroups)
        {
            CameraGroups = cameraGroups;
        }

        public IReadOnlyList<CameraGroup> CameraGroups { get; private set; }
    }
}
