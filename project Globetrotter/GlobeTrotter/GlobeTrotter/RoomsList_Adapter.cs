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
    class RoomsList_Adapter : BaseAdapter<RoomObj>
    {

        List<RoomObj> roomList;
        Activity context;

        public RoomsList_Adapter(Activity context, List<RoomObj> mList)
        {
            this.context = context;
            this.roomList = mList;
        }


        public override RoomObj this[int position]
        {
            get { return roomList[position]; }
        }

        public override int Count
        {
            get { return roomList.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            RoomObj myObj = roomList[position];

            View myView = convertView;
            if (myView == null)
            {
                myView = context.LayoutInflater.Inflate(Resource.Layout.roomlist_view_layout, null);
            }

            myView.FindViewById<TextView>(Resource.Id.roomname).Text = myObj.roomName;
            myView.FindViewById<TextView>(Resource.Id.roomdetails).Text = myObj.roomDetails;
            myView.FindViewById<TextView>(Resource.Id.roomprice).Text = myObj.roomPrice;

            return myView;
        }
    }
}