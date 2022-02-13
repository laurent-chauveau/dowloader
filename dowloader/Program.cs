using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using VideoLibrary;

namespace dowloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Downloader downloader = new Downloader();
            downloader.InitDownlaod();
        }
    }
}
