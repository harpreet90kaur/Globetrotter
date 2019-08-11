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
    [Activity(Label = "RoomsList_Activity")]
    public class RoomsList_Activity : Activity
    {
        TextView hotelname;
        ListView roomlist;
        List<RoomObj> rList = new List<RoomObj>();
        string useremail;
        string hname;
        DatabaseHelper dbhelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.roomslist_layout);
            useremail = Intent.GetStringExtra("useremail");
            hname = Intent.GetStringExtra("hotelname");

            hotelname = FindViewById<TextView>(Resource.Id.rooms_hotelname);
            roomlist = FindViewById<ListView>(Resource.Id.roomslist);
            hotelname.Text = hname;
            dbhelper = new DatabaseHelper(this);

            rList = dbhelper.GetAllRooms(hname);
            var roomsAdapter = new RoomsList_Adapter(this, rList);
            roomlist.SetAdapter(roomsAdapter);
            roomlist.ItemClick += myListViewEvent;
        }

        void myListViewEvent(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            RoomObj value = rList[index];
            System.Console.WriteLine("Room Name - " + value.roomName);

            Intent roomDetailsScreen = new Intent(this, typeof(RoomDetails_Activity));
            roomDetailsScreen.PutExtra("useremail", useremail);
            roomDetailsScreen.PutExtra("hotelname", value.roomHotel);
            roomDetailsScreen.PutExtra("roomname", value.roomName);
            StartActivity(roomDetailsScreen);
        }
    }
}