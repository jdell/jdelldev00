﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace com.mxply.net.common.Extensions
{
    public static class StreamExtension
    {
        public static void CopyTo(this Stream source, Stream target)  
        {
            CopyTo(source, target, 1024);  
        }

        public static void CopyTo(this Stream source, Stream target, int bufferLength)  
        {  
            byte[] buffer = new byte[bufferLength];  
            int bytesRead = 0;  
  
            do  
            {  
                bytesRead = source.Read(buffer, 0, buffer.Length);  
                target.Write(buffer, 0, bytesRead);  
            } while (bytesRead > 0);  
        }
    }
}
