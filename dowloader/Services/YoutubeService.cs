using Dowloader.Class;
using System.Collections.Generic;

namespace Dowloader.Services
{
    public class YoutubeService : VideoService
    {
        public YoutubeService() : base() { }

        public override void Init(Url url)
        {
            url.VideoUrls = GetVideosUrl(url.BaseUrl);
            List<Video> videos = ConvertUrlToYoutubeVideo(url);
            videos?.ForEach(video => {
                BeginDownload(video, url.Folder);
            });
        }

        public override void BeginDownload(Video video, string folder)
        {
            CreateFolder(folder);
            SaveVideo(folder, video);
        }

        public List<Video> ConvertUrlToYoutubeVideo(Url url)
        {
            List<Video> result = new List<Video>();
            VideoLibrary.YouTube youtube = VideoLibrary.YouTube.Default;
            url?.VideoUrls?.ForEach((videoUrl) =>
            {
                Video video = new Video();
                VideoLibrary.YouTubeVideo youtubeVideo = youtube.GetVideo(videoUrl);
                video.Bytes = youtubeVideo.GetBytes();
                video.Url = videoUrl;
                video.Name = youtubeVideo.FullName;

                result.Add(video);
            });

            return result;
        }
    }
}
