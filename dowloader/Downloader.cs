using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dowloader
{
    public class Downloader
    {
        public Downloader() { }

        public void InitDownlaod()
        {
            Console.WriteLine("Video's url");
            int count;
            Console.WriteLine("Videos count :");
            int.TryParse(Console.ReadLine(), out count);

            BeginDownload(count);
        }

        private void BeginDownload(int count)
        {
            List<string> urls = GetUrls(count);

            urls.ForEach((url) =>
            {
                bool isYtbVideo = url.Contains("?v=");
                if (isYtbVideo)
                {
                    GetYtbVideo(url);
                }
            });

            Console.WriteLine("Download end");
        }

        private void GetYtbVideo(string url)
        {
            VideoLibrary.YouTube youtube = VideoLibrary.YouTube.Default;
            VideoLibrary.YouTubeVideo video = youtube.GetVideo(url);
            byte[] bytes = video.GetBytes();
            string fullName = video.FullName;


            string folder = @"D:\Mon_Dossier_Test\";
            CreateFolder(folder);
            SaveVideo(folder, fullName, bytes);
        }

        private void SaveVideo(string folder,string fullName, byte[] bytes)
        {
            File.WriteAllBytes($"{folder}{fullName}", bytes);
        }

        private void CreateFolder(string folder)
        {
            bool folderExist = Directory.Exists(folder);
            if (!folderExist)
            {
                Directory.CreateDirectory(folder);
            }
        }

        private static List<string> GetUrls(int urlCount)
        {
            List<string> urls = new List<string>();
            string url;
            int count = 0; // Current member index;
            Console.Write("Video's url :");
            while (count < urlCount)
            {
                url = Console.ReadLine();
                if (!string.IsNullOrEmpty(url))
                {
                    urls.Add(url);
                    count++;
                }
                else
                {
                    count++;
                }
            }
            Console.WriteLine("Url saved");
            return urls;
        }
    }
}
