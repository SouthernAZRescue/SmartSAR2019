using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.WebCams.Core.ValueTypes
{
    public class CamImage
    {
        public CamImage(Byte[] imageByteArray)
        {
            ByteArray = imageByteArray;
        }
        public byte[] ByteArray { get; private set; }
    }
}
