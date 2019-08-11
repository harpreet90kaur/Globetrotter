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
    class Bookings_Adapter : BaseAdapter<BookingObj>
    {
        List<BookingObj> bookingList;
        Activity context;

        public Bookings_Adapter(Activity context, List<BookingObj> bList)
        {
            this.context = context;
            this.bookingList = bList;
        }

        public override BookingObj this[int position]
        {
            get { return bookingList[position]; }
        }

        public override int Count
        {
            get { return bookingList.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            BookingObj myObj = bookingList[position];

            View myView = convertView;
            if (myView == null)
            {
                myView = context.LayoutInflater.Inflate(Resource.Layout.BookingView_Layout, null);
            }

            myView.FindViewById<ImageView>(Resource.Id.elem_bookimg).SetImageResource(myObj.bookroomimg);
            string bookingdate = "From " + myObj.bookcheckin + " To " + myObj.bookcheckout;
            myView.FindViewById<TextView>(Resource.Id.elem_bookhotel).Text = "Hotel: " + myObj.bookhotel + "\nRoom: " + myObj.bookroom + "\nDates: " + bookingdate + "\nPrice: " + "CAD $" + myObj.bookcost + "/-"; 
            return myView;
        }

    }
}