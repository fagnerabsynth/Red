

using System;
using RedTube.Droid.Interface;
using RedTube.Interface;
using Xamarin.Forms;
using Android.Content;

[assembly: Dependency(typeof(VideoPlayer))]

namespace RedTube.Droid.Interface
{
    class VideoPlayer : IVideoPlayer
    {
        
      

        public void AbrirPlayer(string url)
        {
           
            Intent playVideo = new Intent(Intent.ActionView);
            playVideo.SetDataAndType( Android.Net.Uri.Parse (url), "video/mp4");
            Forms.Context.StartActivity(playVideo);
        }
    }



}