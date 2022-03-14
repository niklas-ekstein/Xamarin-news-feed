using System;
using Xamarin.Forms;

namespace NewsFeed.Core
{
    public class Monk
    {
        public string Name { get; set; }

        public ImageSource MonkImage { get; set; }



        public byte[] ImageArrayMonk { get; set; }

        public bool image = true;

        public bool video = false;

        public Monk()
        {
        }
    }
}