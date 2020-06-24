using System;
using System.Collections.Generic;
using System.Text;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Interfaces
{
    public interface IWebCamCatalog
    {
        IReadOnlyList<CameraGroup>  CameraGroups { get; }
        IReadOnlyList<Camera>  Cameras { get; }
    }
}
