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
    [Activity(Label = "Welcome_Activity")]
    public class Welcome_Activity : Activity
    {
        Fragment[] _fragments;
        DatabaseHelper dbhelper;
        string useremail;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            base.OnCreate(savedInstanceState);
            useremail = Intent.GetStringExtra("useremail");
            Bundle bundle = new Bundle();
            bundle.PutString("useremail", useremail);
            // Create your application here
            dbhelper = new DatabaseHelper(this);

            SetContentView(Resource.Layout.tabs_layout);
            _fragments = new Fragment[]
             {
                new HotelList_Fragment(this, bundle),
                new FavoriteHotel_Fragment(this, bundle),
                new EditProfile_Fragment(this, bundle)
             };

            AddNewTab("", Resource.Drawable.icon1);
            AddNewTab("", Resource.Drawable.icon2);
            AddNewTab("", Resource.Drawable.icon3);
        }

        void AddNewTab(string tabTitle, int ImageId)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetIcon(ImageId);
            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;
            Fragment frag = _fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.framelayoutelement, frag);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.item1:
                    {

                        return true;
                    }
                case Resource.Id.item2:
                    {
                        Intent bookingScreen = new Intent(this, typeof(Bookings_Activity));
                        bookingScreen.PutExtra("useremail", useremail);
                        StartActivity(bookingScreen);
                        return true;
                    }
                case Resource.Id.item3:
                    {
                        Intent changePasswordScreen = new Intent(this, typeof(ChangePassword_Activity));
                        changePasswordScreen.PutExtra("useremail", useremail);
                        StartActivity(changePasswordScreen);
                        return true;
                    }
                case Resource.Id.item4:
                    {
                        Intent homeScreen = new Intent(this, typeof(MainActivity));
                        StartActivity(homeScreen);
                        this.Finish();
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}