using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace GlobeTrotter
{
    [Activity(Label = "CheckSelect_Activity")]
    public class CheckinSelect_Activity : Activity
    {
        DatePicker checkindate;
        DatePicker checkoutdate;
        TextView roomprice;
        Button paymentbtn;
        string useremail;
        string hotelname;
        string roomname;
        string roomimg;
        string price;
        long roomcost;
        string checkin_forward;
        string checkout_forward;

        DatabaseHelper dbhelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.checkinselect_layout);
            useremail = Intent.GetStringExtra("useremail");
            hotelname = Intent.GetStringExtra("hotelname");
            roomname = Intent.GetStringExtra("roomname");
            roomimg = Intent.GetStringExtra("roomimg");
            price = Intent.GetStringExtra("roomprice");
            dbhelper = new DatabaseHelper(this);
            // Create your application here
            checkindate = FindViewById<DatePicker>(Resource.Id.checkindate);
            checkoutdate = FindViewById<DatePicker>(Resource.Id.checkoutdate);
            roomprice = FindViewById<TextView>(Resource.Id.totalcost);
            paymentbtn = FindViewById<Button>(Resource.Id.btn_payment);

            checkindate.DateChanged += CheckinDateChangeEvent;
            checkoutdate.DateChanged += CheckoutDateChangeEvent;
            roomprice.Text = "CAD $" + price + "/-";

            Recalculate_Price();

            paymentbtn.Click += delegate
            {
                Intent paymentScreen = new Intent(this, typeof(Payment_Activity));
                paymentScreen.PutExtra("useremail", useremail);
                paymentScreen.PutExtra("hotelname", hotelname);
                paymentScreen.PutExtra("roomname", roomname);
                paymentScreen.PutExtra("roomprice", roomcost.ToString());
                paymentScreen.PutExtra("roomimg", roomimg);
                paymentScreen.PutExtra("checkin", checkin_forward);
                paymentScreen.PutExtra("checkout", checkout_forward);
                StartActivity(paymentScreen);
            };
        }

        public void CheckinDateChangeEvent(object sender, DatePicker.DateChangedEventArgs args)
        {
            Recalculate_Price();
        }

        public void CheckoutDateChangeEvent(object sender, DatePicker.DateChangedEventArgs args)
        {
            Recalculate_Price();
        }

        public void Recalculate_Price()
        {
            string checkinday = checkindate.DayOfMonth.ToString();
            string checkinmonth = (checkindate.Month + 1).ToString();
            string checkinyear = checkindate.Year.ToString();

            string checkoutday = checkoutdate.DayOfMonth.ToString();
            string checkoutmonth = (checkoutdate.Month + 1).ToString();
            string checkoutyear = checkoutdate.Year.ToString();

            SimpleDateFormat dates = new SimpleDateFormat("dd/M/yyyy");
            System.Console.Write("Date 1 - " + checkinday + " " + checkinmonth + " " + checkinyear);
            System.Console.Write("Date 2 - " + checkoutday + " " + checkoutmonth + " " + checkoutyear);
            Date date_checkin = dates.Parse(checkinday + "/" + checkinmonth + "/" + checkinyear);
            checkin_forward = checkinday + "/" + checkinmonth + "/" + checkinyear;
            System.Console.WriteLine("Date - " + date_checkin);
            Date date_checkout = dates.Parse(checkoutday + "/" + checkoutmonth + "/" + checkoutyear);
            checkout_forward = checkoutday + "/" + checkoutmonth + "/" + checkoutyear;
            System.Console.WriteLine("Date - " + date_checkout);
            
            long difference = date_checkout.Time - date_checkin.Time;
            long differenceDates = difference / (24 * 60 * 60 * 1000);
            long cost = long.Parse(price);
            System.Console.WriteLine("Difference : " + cost * differenceDates);
            if ((cost * differenceDates) > 0)
            {
                roomprice.Text = "CAD $" + cost * differenceDates + "/-";
                roomcost = cost * differenceDates;
            }
        }
    }
}