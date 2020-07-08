using System;
using System.Collections.Generic;
using System.Text;

namespace SSar.BC.WebCams.Core.ValueTypes
{
    public class CameraImage
    {
        public CameraImage(byte[] imageByteArray)
        {
            ByteArray = imageByteArray
                ?? throw new ArgumentNullException(nameof(imageByteArray));
        }
        public byte[] ByteArray { get; private set; }
    }
}
