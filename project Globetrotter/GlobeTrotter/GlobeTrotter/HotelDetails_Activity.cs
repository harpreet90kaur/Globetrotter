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
    [Activity(Label = "HotelDetails_Activity")]
    public class HotelDetails_Activity : Activity
    {
        ImageView hotelimg;
        ImageView ratingimg;
        TextView hotelname;
        TextView hoteladdress;
        TextView hotelphone;
        ListView roomslist;
        Button favButton;
        Button roomButton;
        string hname;
        string useremail;
        List<RoomObj> rList = new List<RoomObj>();
        DatabaseHelper dbhelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.hoteldetails_layout);
            useremail = Intent.GetStringExtra("useremail");
            hname = Intent.GetStringExtra("hotelname");

            hotelname = FindViewById<TextView>(Resource.Id.hoteldetails_name);
            hoteladdress = FindViewById<TextView>(Resource.Id.hoteldetails_address);
            hotelphone = FindViewById<TextView>(Resource.Id.hoteldetails_phone);
            hotelimg = FindViewById<ImageView>(Resource.Id.hoteldetails_img);
            ratingimg = FindViewById<ImageView>(Resource.Id.hoteldetails_rating);

            favButton = FindViewById<Button>(Resource.Id.btn_details_fav);
            roomButton = FindViewById<Button>(Resource.Id.btn_details_rooms);

            dbhelper = new DatabaseHelper(this);
            HotelObj hotel = new HotelObj();
            hotel = dbhelper.GetSingleHotel(hname);
            
            hotelimg.SetImageResource(hotel.hotelimg);
            hotelname.Text = hotel.hotelname;
            hoteladdress.Text = hotel.hoteladdress;
            hotelphone.Text = hotel.hotelcontact;

            if (hotel.hotelratings == "1-Star Hotel")
            {
                ratingimg.SetImageResource(Resource.Drawable.h1star);
            }
            else if (hotel.hotelratings == "2-Star Hotel")
            {
                ratingimg.SetImageResource(Resource.Drawable.h2star);
            }
            else if (hotel.hotelratings == "3-Star Hotel")
            {
                ratingimg.SetImageResource(Resource.Drawable.h3star);
            }
            else if (hotel.hotelratings == "4-Star Hotel")
            {
                ratingimg.SetImageResource(Resource.Drawable.h4star);
            }
            else
            {
                ratingimg.SetImageResource(Resource.Drawable.h5star);
            }

            if (dbhelper.AlreadyFavorite(useremail, hotel.hotelname))
            {
                favButton.Visibility = ViewStates.Gone;
            }
            else
            {
                favButton.Visibility = ViewStates.Visible;
            }

            favButton.Click += delegate
            {
                FavoriteObj fobj = new FavoriteObj(useremail, hotel.hotelimg, hotel.hotelname, hotel.hoteladdress, hotel.hotelcontact, hotel.hotelratings);
                dbhelper.InsertSingleFavoriteObj(fobj);
                favButton.Visibility = ViewStates.Gone;
                Android.App.AlertDialog.Builder dialog2 = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert2 = dialog2.Create();
                alert2.SetTitle("Favorites Added");
                alert2.SetMessage("The hotel has been added to your favorites list.");
                alert2.SetButton("OK", (c, ev) =>
                {
                    // Ok button clicked
                });
                alert2.Show();
            };

            roomButton.Click += delegate
            {
                Intent roomsListScreen = new Intent(this, typeof(RoomsList_Activity));
                roomsListScreen.PutExtra("useremail", useremail);
                roomsListScreen.PutExtra("hotelname", hotel.hotelname);
                StartActivity(roomsListScreen);
            };
        }
    }
}