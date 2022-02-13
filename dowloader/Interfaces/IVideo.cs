using Dowloader.Class;
namespace Dowloader.Interfaces
{
    public interface IVideo
    {
        void BeginDownload(Video video, string folder);
        void CreateFolder(string folder);
        void SaveVideo(string folder, Video video);
    }
}
