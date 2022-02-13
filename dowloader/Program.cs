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
            Dowloader();
        }

        private static void Dowloader()
        {
            Console.WriteLine("Url de la vidéo!");

            List<string> urls = GetUrls();

            List<string> videoIds = new List<string>();

            urls.ForEach(async (url) =>
            {
                var videoId = url.Split(new string[] { "?v=" }, StringSplitOptions.None)[1];

                var videoUrl = "https://www.youtube.com/embed/" + videoId + ".mp4";
                var youTube = YouTube.Default;
                var video = youTube.GetVideo(videoUrl);
                string folderName = @"D:\Mon_Dossier_Test";

                bool folderExist = Directory.Exists(folderName);
                if (!folderExist)
                {
                    Directory.CreateDirectory(folderName);
                }
                try
                {


                    var client = new HttpClient();
                    long? totalByte = 0;
                    using (Stream output = File.OpenWrite(Path.Combine(folderName, video.FullName)))
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Head, video.Uri))
                        {
                            totalByte = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result.Content.Headers.ContentLength;
                        }
                        using (var input = await client.GetStreamAsync(video.Uri))
                        {
                            byte[] buffer = new byte[16 * 1024];
                            int read;
                            int totalRead = 0;
                            Console.WriteLine("Download Started for " + video.FullName);
                            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                output.Write(buffer, 0, read);
                                totalRead += read;
                                Console.Write($"\rDownloading {totalRead}/{totalByte} Octets ...");
                            }
                            Console.WriteLine();
                            Console.WriteLine(video.FullName + " Download Complete");
                        }
                    }
                    Console.ReadLine();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

                Console.WriteLine(video.FullName + " down");
            });

            Console.ReadLine();
        }

        private static List<string> GetUrls()
        {
            List<string> urls = new List<string>();
            string url;
            int count = -2; // Current member index;
            int totalcount = 0; // Total members count;
            while (count < totalcount)
            {
                url = Console.ReadLine();
                if (!string.IsNullOrEmpty(url)) // your app doesn't count first and second line
                {
                    urls.Add(url);
                }
                else
                {
                    count = 0;
                }
            }
            Console.WriteLine("Url enregistrées");
            return urls;
        }

        private static void DrawTextProgressBar(int progress, int total)
        {
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
        }
    }
}
