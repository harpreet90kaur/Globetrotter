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
    public class BookingObj
    {
        public string bookuser;
        public string bookhotel;
        public string bookroom;
        public int bookroomimg;
        public string bookcost;
        public string bookcheckin;
        public string bookcheckout;

        public BookingObj()
        {

        }

        public BookingObj(string buser, string bhotel, string broom, int broomimg, string bcost, string bcheckin, string bcheckout)
        {
            this.bookuser = buser;
            this.bookhotel = bhotel;
            this.bookroom = broom;
            this.bookroomimg = broomimg;
            this.bookcost = bcost;
            this.bookcheckin = bcheckin;
            this.bookcheckout = bcheckout;
        }
    }
}