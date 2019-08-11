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
    [Activity(Label = "Payment_Activity")]
    public class Payment_Activity : Activity
    {
        TextView cardnumber;
        TextView cardname;
        TextView cardmonth;
        TextView cardyear;
        TextView cardcode;
        Button payment;
        string useremail;
        string hotelname;
        string roomname;
        string roomimg;
        string roomcost;
        string checkindate;
        string checkoutdate;
        DatabaseHelper dbhelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.payment_layout);
            useremail = Intent.GetStringExtra("useremail");
            hotelname = Intent.GetStringExtra("hotelname");
            roomname = Intent.GetStringExtra("roomname");
            roomimg = Intent.GetStringExtra("roomimg");
            roomcost = Intent.GetStringExtra("roomprice");
            checkindate = Intent.GetStringExtra("checkin");
            checkoutdate = Intent.GetStringExtra("checkout");

            cardnumber = FindViewById<TextView>(Resource.Id.txt_payment_ccno);
            cardname = FindViewById<TextView>(Resource.Id.txt_payment_ccname);
            cardmonth = FindViewById<TextView>(Resource.Id.txt_payment_expmonth);
            cardyear = FindViewById<TextView>(Resource.Id.txt_payment_expyear);
            cardcode = FindViewById<TextView>(Resource.Id.txt_payment_cvc);
            payment = FindViewById<Button>(Resource.Id.btn_payment_proceed);

            dbhelper = new DatabaseHelper(this);

            payment.Click += delegate
            {
                if (cardnumber.Text.Equals("") ||
                    cardname.Text.Equals("") ||
                    cardmonth.Text.Equals("") ||
                    cardyear.Text.Equals("") ||
                    cardcode.Text.Equals(""))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Missing Data");
                    alert.SetMessage("Please enter all the details before proceeding with payment");
                    alert.SetButton("OK", (c, ev) => { });
                    alert.Show();
                } else
                {
                    dbhelper.InsertBooking(useremail, hotelname, roomname, int.Parse(roomimg), roomcost, checkindate, checkoutdate);
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Booking Confirmed");
                    alert.SetMessage("Thank you! Your booking has been confirmed. See you soon!");
                    alert.SetButton("OK", (c, ev) => {
                        Intent welcomepage = new Intent(this, typeof(Welcome_Activity));
                        welcomepage.PutExtra("useremail", useremail);
                        StartActivity(welcomepage);
                        this.Finish();
                    });
                    alert.Show();
                }
            };
        }
    }
}