using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace GlobeTrotter
{
    public class FavoriteHotel_Fragment : Fragment
    {
        List<FavoriteObj> hotelList = new List<FavoriteObj>();
        FavoriteObj favobj;
        ListView listElement;
        Activity context;
        DatabaseHelper dbhelper;
        string useremail;

        public FavoriteHotel_Fragment(Activity cont, Bundle savedInstanceState)
        {
            context = cont;
            useremail = savedInstanceState.GetString("useremail");
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View favHotel = inflater.Inflate(Resource.Layout.favlist_frag_layout, container, false);
            dbhelper = new DatabaseHelper(context);
            listElement = favHotel.FindViewById<ListView>(Resource.Id.favlistElement);
            favobj = new FavoriteObj();
            hotelList = dbhelper.GetFavoriteHotels(useremail);
            var restAdapter = new Favorites_Adapter(context, hotelList);

            listElement.SetAdapter(restAdapter);

            listElement.ItemClick += myListViewEvent;

            return favHotel;
        }

        void myListViewEvent(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            FavoriteObj value = hotelList[index];
            System.Console.WriteLine("Hotel Name " + value.favHotel);

            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(context);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Favorites");
            alert.SetMessage("Do you want to remove this hotel from your favorites list or view the details about the hotel?");
            alert.SetButton2("Remove", (c, ev) =>
            {
                dbhelper.RemoveSingleFavorite(useremail, value.favHotel);
                hotelList.Clear();
                hotelList = dbhelper.GetFavoriteHotels(useremail);
                var favsAdapter2 = new Favorites_Adapter(context, hotelList);
                listElement.SetAdapter(favsAdapter2);
            });
            alert.SetButton("View Details", (c, ev) =>
            {
                Intent hotelDetailsScreen = new Intent(context, typeof(HotelDetails_Activity));
                hotelDetailsScreen.PutExtra("useremail", useremail);
                hotelDetailsScreen.PutExtra("hotelname", value.favHotel);
                StartActivity(hotelDetailsScreen);
            });
            alert.Show();
        }
    }
}