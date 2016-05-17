using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTube.models
{



    public class Thumb
    {
        public string size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string src { get; set; }
    }

    public class Tag
    {
        public string tag_name { get; set; }
    }

    public class Star
    {
        public string star_name { get; set; }
    }

    public class Video2
    {
        public string duration { get; set; }
        public string views { get; set; }
        public string video_id { get; set; }
        public string rating { get; set; }
        public string ratings { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string embed_url { get; set; }
        public string default_thumb { get; set; }
        public string thumb { get; set; }
        public object publish_date { get; set; }
        public List<Thumb> thumbs { get; set; }
        public List<Tag> tags { get; set; }
        public List<Star> stars { get; set; }
    }

    public class Video
    {
        public Video2 video { get; set; }
    }

    public class ProcuraVideos
    {
        public List<Video> videos { get; set; }
        public int count { get; set; }
    }

}
