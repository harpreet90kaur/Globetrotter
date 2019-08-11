using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GlobeTrotter
{
    public class FavoriteObj
    {
        public string favEmail;
        public int favImg;
        public string favHotel;
        public string favAddress;
        public string favPhone;
        public string favRatings;

        public FavoriteObj()
        {

        }

        public FavoriteObj(string fuser, int fimg, string fhotel, string faddress, string fphone, string fratings)
        {
            this.favEmail = fuser;
            this.favImg = fimg;
            this.favHotel = fhotel;
            this.favAddress = faddress;
            this.favPhone = fphone;
            this.favRatings = fratings;
        }
    }
}