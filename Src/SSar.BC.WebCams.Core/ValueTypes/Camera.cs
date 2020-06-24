﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.WebCams.Core.ValueTypes
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public string Description { get; set; }
        public string SourceUrl { get; set; }
    }
}