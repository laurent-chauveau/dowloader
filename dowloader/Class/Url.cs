using System.Collections.Generic;

namespace Dowloader.Class
{
    public class Url
    {
        public Url() { }
        public List<string> VideoUrls { get; set; }
        public string BaseUrl { get; set; }
        public string Folder { get; set; }
        public bool isYoutube { get; set; }
    }
}
