﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.WebCams.Core.ValueTypes
{
    public class Camera
    {
        // Issue:
        // Due to a bug in the dotnet core deserializer used in configuration
        // binding as of June 2020, a list with non-null default property values
        // will not get bound to a target model. For example:
        //
        //     public string Name { get; set; } = "";   // A definite NOPE, not gonna work.
        //
        // Since this Camera class gets bound to a CameraGroup as a List<Camera>, this
        // presents a problem.
        //
        // Solution:
        // As a workaround an explicit default constructor has been created that sets
        // the default values.
        //
        // See: 
        //    https://stackoverflow.com/questions/59929875/dependency-injection-with-options-pattern
        //    and
        //    https://github.com/dotnet/runtime/issues/36390 
        //
        // Don't ask me how long it took to figure this out. I'm not bitter. Really.

        public Camera()
        {
            Id = 0;
            Name = "";
            UrlName = "";
            Description = "";
            SourceUrl = "";
        }
        public int Id { get; set; }
        public string Name { get; set; } 
        public string UrlName { get; set; }
        public string Description { get; set; }
        public string SourceUrl { get; set; } 
    }
}
