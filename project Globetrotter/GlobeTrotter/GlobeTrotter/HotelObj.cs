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
    public class HotelObj
    {
        public int hotelimg;
        public string hotelname;
        public string hoteladdress;
        public string hotelcontact;
        public string hotelratings;
        DatabaseHelper dbhelper;

        public HotelObj()
        {

        }

        public HotelObj(int himg, string hname, string haddress, string hcontact, string hratings)
        {
            this.hotelimg = himg;
            this.hotelname = hname;
            this.hoteladdress = haddress;
            this.hotelcontact = hcontact;
            this.hotelratings = hratings;
        }

        public List<HotelObj> GetAllHotels(Activity activity)
        {
            List<HotelObj> hobj = new List<HotelObj>();

            hobj.Add(new HotelObj(Resource.Drawable.h1, "Bond Place Hotel Toronto", "65 Dundas St E, Toronto, ON M5B 2G8", "(416) 362-6061", "3-Star Hotel"));
            hobj.Add(new HotelObj(Resource.Drawable.h2, "The Westin Harbour Castle", "1 Harbour Square, Toronto, ON M5J 1A6", "(416) 869-1600", "4-Star Hotel"));
            hobj.Add(new HotelObj(Resource.Drawable.h3, "Chelsea Hotel", "33 Gerrard St W, Toronto, ON M5G 1Z4", "(416) 595-1975", "4-Star Hotel"));
            hobj.Add(new HotelObj(Resource.Drawable.h4, "The Strathcona Hotel", "60 York St, Toronto, ON M5J 1S8", "(416) 363-3321", "3-Star Hotel"));
            hobj.Add(new HotelObj(Resource.Drawable.h5, "Hotel Fairmont Royal York", "100 Front St W, Toronto, ON M5J 1E3", "(416) 368-2511", "4-Star Hotel"));

            dbhelper = new DatabaseHelper(activity);
            if(!dbhelper.DoesHotelTableExist())
            {
                dbhelper.InsertHotelList(hobj);
            }
            return hobj;
        }
    }
}