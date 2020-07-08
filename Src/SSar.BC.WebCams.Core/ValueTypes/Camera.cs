using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.WebCams.Core.ValueTypes
{
    public class Camera
    {
        // Issue:
        // Due to a bug in the DotNet Core deserializer used for configuration
        // binding as of June 2020, a list with non-null default property values
        // will not get bound to a target model. For example, a list containing a
        // class with the following property definition:
        //
        //     public string Name { get; set; } = "";   // Will prevent binding
        //
        // Since this Camera class gets bound to a CameraGroup in a List<Camera>, this
        // presents a problem.
        //
        // Solution:
        // As a workaround an explicit default constructor has been created that sets
        // the default values.
        //
        // See:
        //     https://github.com/dotnet/runtime/issues/36390 
        // and the comments in:
        //     https://stackoverflow.com/questions/59929875/dependency-injection-with-options-pattern
        //
        // Don't ask me how long it took to figure this out. I'm not bitter. Really.

        public Camera()
        {
            CameraId = 0;
            Name = "";
            Description = "";
            ImageSourceUrl = "";
        }
        public int CameraId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string ImageSourceUrl { get; set; }
    }
}
