using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace com.mxply.net.common.Extensions
{
    public static class StreamExtension
    {
        private const long BUFFER_SIZE = 4096;
        public static long CopyTo(this Stream input, Stream output)
        {
            long bufferSize = input.Length < BUFFER_SIZE ? input.Length : BUFFER_SIZE;
            byte[] buffer = new byte[bufferSize];
            int read;
            long written = 0;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
                written += read;
            }
            return written;
        }
    }
}
