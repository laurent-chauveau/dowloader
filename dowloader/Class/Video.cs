using System;
using System.Collections.Generic;
using System.Text;

namespace Dowloader.Class
{
    public class Video
    {
        public Video() { }
        public string Url { get; set; }
        public byte[] Bytes { get; set; }
        public string Name {get;set;}
    }
}
