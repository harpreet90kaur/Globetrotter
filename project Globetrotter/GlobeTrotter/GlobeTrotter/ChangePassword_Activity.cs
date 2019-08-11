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
    [Activity(Label = "ChangePassword_Activity")]
    public class ChangePassword_Activity : Activity
    {
        EditText currentpass;
        EditText newpass;
        EditText repeatnewpass;
        Button changebtn;
        DatabaseHelper dbhelper;
        string useremail;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.changepassword_layout);
            useremail = Intent.GetStringExtra("useremail");
            // Create your application here
            currentpass = FindViewById<EditText>(Resource.Id.txt_currentPass);
            newpass = FindViewById<EditText>(Resource.Id.txt_newPass);
            repeatnewpass = FindViewById<EditText>(Resource.Id.txt_repeatNewPass);
            changebtn = FindViewById<Button>(Resource.Id.btn_changePassword);
            dbhelper = new DatabaseHelper(this);

            changebtn.Click += delegate
            {
                if(currentpass.Text.Equals("") ||
                    newpass.Text.Equals("") ||
                    repeatnewpass.Text.Equals(""))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Fields Empty Error");
                    alert.SetMessage("Fields cannot be empty. Fill in all the details to change your password.");
                    alert.SetButton("OK", (c, ev) => { });
                    alert.Show();
                }
                else
                {
                    if(newpass.Text.Trim() != repeatnewpass.Text.Trim())
                    {
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Mismatched Passwords");
                        alert.SetMessage("New Password and Repeat New Password do not match. Please enter correct value in both fields");
                        alert.SetButton("OK", (c, ev) => { });
                        alert.Show();
                    }
                    else
                    {
                        if(dbhelper.MatchUserPassword(useremail, currentpass.Text.Trim()))
                        {
                            dbhelper.ChangeUserPass(useremail, newpass.Text.Trim());
                            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                            Android.App.AlertDialog alert = dialog.Create();
                            alert.SetTitle("Password Updated");
                            alert.SetMessage("Your password has been changed.");
                            alert.SetButton("OK", (c, ev) => {
                                this.Finish();
                            });
                            alert.Show();
                        }
                        else
                        {
                            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                            Android.App.AlertDialog alert = dialog.Create();
                            alert.SetTitle("Incorrect Password");
                            alert.SetMessage("The password you entered in current password field doesn't match with your password. Please enter correct password");
                            alert.SetButton("OK", (c, ev) => { });
                            alert.Show();
                        }
                    }
                }
            };
        }
    }
}