using Dowloader.Class;
using Dowloader.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dowloader
{
    public class Downloader
    {
        public Downloader() { }

        public void Init()
        {
            Url url = new Url();
            Console.WriteLine("Video's urls (Separate urls with a pipe) :");
            url.BaseUrl = Console.ReadLine();
            Console.WriteLine("Folder to save videos");
            url.Folder = Console.ReadLine();
            Console.WriteLine("Youtube video ? Yes - No");
            url.isYoutube = Console.ReadLine().ToLower().Equals("yes");

            if (url.isYoutube)
            {
                YoutubeService youtubeService = new YoutubeService();
                youtubeService.Init(url);
            }
            Console.WriteLine("End");

        }
    }
}
