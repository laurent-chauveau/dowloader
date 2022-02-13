using Dowloader.Class;
using Dowloader.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dowloader.Services
{
    public abstract class BaseVideoService : IVideo
    {
        public BaseVideoService() { }

        public virtual void Init(Url url)
        {
            url.VideoUrls = GetVideosUrl(url.BaseUrl);
        }

        public abstract void BeginDownload(Video videos, string folder);

        public List<string> GetVideosUrl(string url)
        {
            List<string> result = url.Contains("|") ? url.Split("|").ToList() : new List<string>() { url };

            return result;
        }

        public void CreateFolder(string folder)
        {
            bool folderExist = Directory.Exists(folder);
            if (!folderExist)
            {
                Directory.CreateDirectory(folder);
            }
        }

        public void SaveVideo(string folder, Video video)
        {
            folder = folder.EndsWith("\\") ? folder : folder + "\\";
            File.WriteAllBytes($"{folder}{video.Name}", video.Bytes);
        }
    }

}
