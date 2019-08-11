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
    [Activity(Label = "RoomDetails_Activity")]
    public class RoomDetails_Activity : Activity
    {
        ImageView roomimg;
        TextView roomname;
        TextView roomhotel;
        TextView roomdetails;
        TextView roomfacilities;
        TextView roomprice;
        Button bookroom;
        DatabaseHelper dbhelper;
        string useremail;
        string hname;
        string rname;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.roomdetails_layout);
            useremail = Intent.GetStringExtra("useremail");
            hname = Intent.GetStringExtra("hotelname");
            rname = Intent.GetStringExtra("roomname");
            dbhelper = new DatabaseHelper(this);

            roomname = FindViewById<TextView>(Resource.Id.roomdetails_name);
            roomhotel = FindViewById<TextView>(Resource.Id.roomdetails_hotel);
            roomdetails = FindViewById<TextView>(Resource.Id.roomdetails_details);
            roomfacilities = FindViewById<TextView>(Resource.Id.roomdetails_facilities);
            roomprice = FindViewById<TextView>(Resource.Id.roomdetails_price);

            bookroom = FindViewById<Button>(Resource.Id.btn_bookroom);
            roomimg = FindViewById<ImageView>(Resource.Id.roomdetails_img);

            RoomObj room = new RoomObj();
            room = dbhelper.GetSingleRoom(hname, rname);
            System.Console.WriteLine("Room Name - " + room.roomName);
            System.Console.WriteLine("Hotel Name - " + room.roomHotel);
            System.Console.WriteLine("Room Details - " + room.roomDetails);
            System.Console.WriteLine("Room Facilities - " + room.roomFacilities);
            System.Console.WriteLine("Room Price - " + room.roomPrice);

            roomimg.SetImageResource(room.roomImg);
            roomname.Text = room.roomName;
            roomhotel.Text = room.roomHotel;
            roomdetails.Text = room.roomDetails + "\nGuests Capacity: " + room.roomPeople;
            roomfacilities.SetSingleLine(false);
            String[] facilities = room.roomFacilities.Split(":");
            for (int i = 0; i < facilities.Length; i++)
            {
                roomfacilities.Text += facilities[i] + "\n";
            }
            roomprice.Text = "CAD $" + room.roomPrice + "/-";

            bookroom.Click += delegate
            {
                Intent checkinSelectionScreen = new Intent(this, typeof(CheckinSelect_Activity));
                checkinSelectionScreen.PutExtra("useremail", useremail);
                checkinSelectionScreen.PutExtra("hotelname", room.roomHotel);
                checkinSelectionScreen.PutExtra("roomname", room.roomName);
                checkinSelectionScreen.PutExtra("roomprice", room.roomPrice);
                checkinSelectionScreen.PutExtra("roomimg", room.roomImg.ToString());
                StartActivity(checkinSelectionScreen);
            };
        }
    }
}