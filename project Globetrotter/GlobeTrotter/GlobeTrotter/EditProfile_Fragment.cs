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
    public class EditProfile_Fragment : Fragment
    {
        Button editButton;
        EditText useremail;
        EditText userpass;
        EditText userage;
        EditText userphone;
        Activity context;
        DatabaseHelper dbhelper;
        string uemail;
        
        public EditProfile_Fragment(Activity actContext, Bundle savedInstanceState)
        {
            this.context = actContext;
            uemail = savedInstanceState.GetString("useremail");
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            LayoutInflater themedInflator = inflater.CloneInContext(wrapContextTheme(context, Resource.Style.AppTheme));
            ViewGroup viewEditProfile = (ViewGroup)themedInflator.Inflate(Resource.Layout.editprofile_frag_layout, container, false);
            dbhelper = new DatabaseHelper(context);

            UserObj user = new UserObj(dbhelper.SearchUser(uemail));

            useremail = viewEditProfile.FindViewById<EditText>(Resource.Id.txt_edit_email);
            userpass = viewEditProfile.FindViewById<EditText>(Resource.Id.txt_edit_pass);
            userage = viewEditProfile.FindViewById<EditText>(Resource.Id.txt_edit_age);
            userphone = viewEditProfile.FindViewById<EditText>(Resource.Id.txt_edit_contact);
            editButton = viewEditProfile.FindViewById<Button>(Resource.Id.btn_edit);

            useremail.Text = user.useremail;
            userpass.Text = user.userpass;
            userage.Text = user.userage;
            userphone.Text = user.userphone;
            string custAdd = user.useremail;

            useremail.Enabled = false;

            editButton.Click += delegate
            {
                user.useremail = useremail.Text.Trim();
                user.userpass = userpass.Text.Trim();
                user.userage = userage.Text.Trim();
                user.userphone = userphone.Text.Trim();

                dbhelper.UpdateUserDetails(user);

                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(context);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Profile Updated");
                alert.SetMessage("Your profile has been updated successfully.");
                alert.SetButton("OK", (c, ev) =>
                {
                    // Ok button clicked
                });
                alert.Show();
            };

            return viewEditProfile;
        }

        private Context wrapContextTheme(Activity activity, int styleRes)
        {
            ContextThemeWrapper contextThemeWrapper = new ContextThemeWrapper(activity, styleRes);
            return contextThemeWrapper;
        }
    }
}