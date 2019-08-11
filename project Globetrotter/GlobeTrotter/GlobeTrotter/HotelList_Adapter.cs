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
    public class HotelList_Adapter : BaseAdapter<HotelObj>
    {

        List<HotelObj> hotelList;
        Activity context;

        public HotelList_Adapter(Activity context, List<HotelObj> hList)
        {
            this.context = context;
            this.hotelList = hList;
        }

        public override HotelObj this[int position]
        {
            get { return hotelList[position]; }
        }

        public override int Count
        {
            get { return hotelList.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            HotelObj myObj = hotelList[position];

            View myView = convertView;
            if (myView == null)
            {
                myView = context.LayoutInflater.Inflate(Resource.Layout.HotelView_Layout, null);
            }

            myView.FindViewById<ImageView>(Resource.Id.hotelImg).SetImageResource(myObj.hotelimg);
            myView.FindViewById<TextView>(Resource.Id.hotelName).Text = myObj.hotelname + "\n" + myObj.hoteladdress + "\n" + myObj.hotelcontact;
            /*myView.FindViewById<TextView>(Resource.Id.hotelAddress).Text = myObj.hoteladdress;
            myView.FindViewById<TextView>(Resource.Id.hotelPhone).Text = myObj.hotelcontact;
            if(myObj.hotelratings == "1-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.hotelRatingImg).SetImageResource(Resource.Drawable.h1star);
            }
            else if (myObj.hotelratings == "2-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.hotelRatingImg).SetImageResource(Resource.Drawable.h2star);
            }
            else if (myObj.hotelratings == "3-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.hotelRatingImg).SetImageResource(Resource.Drawable.h3star);
            }
            else if (myObj.hotelratings == "4-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.hotelRatingImg).SetImageResource(Resource.Drawable.h4star);
            }
            else
            {
                myView.FindViewById<ImageView>(Resource.Id.hotelRatingImg).SetImageResource(Resource.Drawable.h5star);
            }
            myView.FindViewById<TextView>(Resource.Id.hotelRating).Text = myObj.hotelratings;
            */
            return myView;
        }
    }
}