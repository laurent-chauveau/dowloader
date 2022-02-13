using System;
using System.ComponentModel;
using System.Net;

namespace videoDownload
{
    public class Program
    {
        static void Main(string[] args)
        {
            Downloader();
        }

        private static void Downloader()
        {
            Console.WriteLine("URL de la vidéo");

            string url = Console.ReadLine();

            Console.WriteLine("Nom de la vidéo");
            string videoName = Console.ReadLine();
            string path = @"d:\tuto-grim-dark\" + videoName + ".mp4";
            if (!string.IsNullOrWhiteSpace(url))
            {
                var client = new WebClient();
                Uri uri = new Uri(url);
                Console.WriteLine(client.ResponseHeaders);
                client.DownloadFile(uri, path);
                Console.Read();
            }
        }

        private static void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download completed!");
        }

    }
}
