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
    class Favorites_Adapter : BaseAdapter<FavoriteObj>
    {
        List<FavoriteObj> hotelList;
        Activity context;

        public Favorites_Adapter(Activity context, List<FavoriteObj> hList)
        {
            this.context = context;
            this.hotelList = hList;
        }

        public override FavoriteObj this[int position]
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
            FavoriteObj myObj = hotelList[position];

            View myView = convertView;
            if (myView == null)
            {
                myView = context.LayoutInflater.Inflate(Resource.Layout.FavoritesView_Layout, null);
            }

            myView.FindViewById<ImageView>(Resource.Id.elem_favimg).SetImageResource(myObj.favImg);
            myView.FindViewById<TextView>(Resource.Id.elem_favhotel).Text = myObj.favHotel + "\n" + myObj.favAddress + "\n" + myObj.favPhone;
            /*myView.FindViewById<TextView>(Resource.Id.elem_favaddress).Text = myObj.favAddress;
            myView.FindViewById<TextView>(Resource.Id.elem_favphone).Text = myObj.favPhone;
            if (myObj.favRatings == "1-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.elem_favrating_img).SetImageResource(Resource.Drawable.h1star);
            }
            else if (myObj.favRatings == "2-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.elem_favrating_img).SetImageResource(Resource.Drawable.h2star);
            }
            else if (myObj.favRatings == "3-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.elem_favrating_img).SetImageResource(Resource.Drawable.h3star);
            }
            else if (myObj.favRatings == "4-Star Hotel")
            {
                myView.FindViewById<ImageView>(Resource.Id.elem_favrating_img).SetImageResource(Resource.Drawable.h4star);
            }
            else
            {
                myView.FindViewById<ImageView>(Resource.Id.elem_favrating_img).SetImageResource(Resource.Drawable.h5star);
            }
            myView.FindViewById<TextView>(Resource.Id.elem_favrating).Text = myObj.favRatings;
            */
            return myView;
        }
    }
}