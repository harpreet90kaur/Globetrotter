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
    public class HotelList_Fragment : Fragment
    {
        List<HotelObj> hotelList = new List<HotelObj>();
        HotelObj hotelObj;
        SearchView hotelSearch;
        ListView hotellistElement;
        Activity context;
        DatabaseHelper dbhelper;
        string useremail;

        public HotelList_Fragment(Activity actContext, Bundle savedInstanceState)
        {
            this.context = actContext;
            useremail = savedInstanceState.GetString("useremail");
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View viewHotelList = inflater.Inflate(Resource.Layout.hotellist_frag_layout, container, false);
            hotelSearch = viewHotelList.FindViewById<SearchView>(Resource.Id.hotelSearch);
            hotellistElement = viewHotelList.FindViewById<ListView>(Resource.Id.hotelList);

            hotelObj = new HotelObj();
            hotelList = hotelObj.GetAllHotels(context);
            RoomObj roomobj = new RoomObj();
            roomobj.AddRooms(context);
            var hotelAdapter = new HotelList_Adapter(context, hotelList);

            dbhelper = new DatabaseHelper(context);
            hotellistElement.SetAdapter(hotelAdapter);

            hotellistElement.ItemClick += myListViewEvent;

            hotelSearch.QueryTextChange += MySearchBar_QueryTextChange;

            Spinner myOptions;
            var spinnerValue = new[] { "All Hotels", "1-Star Hotels", "2-Star Hotels", "3-Star Hotels", "4-Star Hotels", "5-Star Hotels" };
            myOptions = viewHotelList.FindViewById<Spinner>(Resource.Id.hotelSpinner);

            var arrrayAdatperSpinner = new ArrayAdapter(context, Android.Resource.Layout.SimpleListItem1, spinnerValue);
            myOptions.Adapter = arrrayAdatperSpinner;

            myOptions.ItemSelected += MyOptions_ItemSelected;

            return viewHotelList;
        }

        void MyOptions_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;
            var spinnerValue = new[] { "All Hotels", "1-Star Hotels", "2-Star Hotels", "3-Star Hotels", "4-Star Hotels", "5-Star Hotels" };
            var value = spinnerValue[index];
            value = value.Substring(0, value.Length - 1);
            System.Console.WriteLine("Favorite Restaurant: " + value);
            HotelObj hobj = new HotelObj();
            if (value == "All Hotel")
                hotelList = hobj.GetAllHotels(context);
            else
                hotelList = dbhelper.GetSelectedHotels(value);
            var hotelAdapter = new HotelList_Adapter(context, hotelList);
            hotellistElement.SetAdapter(hotelAdapter);
        }

        void MySearchBar_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var value = e.NewText;
            System.Console.WriteLine("Search Value - " + value);
            List<HotelObj> filterList = new List<HotelObj>();
            foreach (HotelObj aObj in hotelList)
            {
                if (aObj.hotelname.ToLower().Contains(value.ToLower()))
                {
                    filterList.Add(aObj);
                }
            }
            var newFilter = new HotelList_Adapter(context, filterList);
            hotellistElement.SetAdapter(newFilter);
        }

        void myListViewEvent(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            HotelObj value = hotelList[index];
            System.Console.WriteLine("Hotel Name " + value.hotelname);

            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(context);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Favorites");
            alert.SetMessage("Do you want to add this hotel to your favorites list or view the details about the hotel?");
            alert.SetButton2("Add", (c, ev) =>
            {
                if(!dbhelper.AlreadyFavorite(useremail, value.hotelname))
                    dbhelper.InsertSingleFavorite(useremail, value.hotelimg, value.hotelname, value.hoteladdress, value.hotelcontact, value.hotelratings);
            });
            alert.SetButton("View Details", (c, ev) =>
            {
                Intent hotelDetailsScreen = new Intent(context, typeof(HotelDetails_Activity));
                hotelDetailsScreen.PutExtra("useremail", useremail);
                hotelDetailsScreen.PutExtra("hotelname", value.hotelname);
                StartActivity(hotelDetailsScreen);
            });
            alert.Show();
        }
    }
}