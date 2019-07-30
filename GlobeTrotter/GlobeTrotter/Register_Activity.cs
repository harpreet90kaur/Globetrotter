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
    [Activity(Label = "Register_Activity")]
    public class Register_Activity : Activity
    {
        Button btn_login;
        Button btn_register;
        Button btn_home;
        EditText txt_email;
        EditText txt_pass;
        EditText txt_age;
        EditText txt_phone;
        DatabaseHelper dbhelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_layout);
            dbhelper = new DatabaseHelper(this);
            // Create your application here
            btn_login = FindViewById<Button>(Resource.Id.btn_reg_login);
            btn_register = FindViewById<Button>(Resource.Id.btn_reg_register);
            btn_home = FindViewById<Button>(Resource.Id.btn_reg_home);

            txt_email = FindViewById<EditText>(Resource.Id.txt_reg_email);
            txt_pass = FindViewById<EditText>(Resource.Id.txt_reg_pass);
            txt_age = FindViewById<EditText>(Resource.Id.txt_reg_age);
            txt_phone = FindViewById<EditText>(Resource.Id.txt_reg_contact);

            btn_login.Click += delegate
            {
                Intent loginpage = new Intent(this, typeof(Login_Activity));
                StartActivity(loginpage);
                this.Finish();
            };

            btn_register.Click += delegate
            {
                if(txt_email.Text.Equals("") ||
                    txt_pass.Text.Equals("") ||
                    txt_age.Text.Equals("") || 
                    txt_phone.Text.Equals(""))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Fields Empty Error");
                    alert.SetMessage("Fields cannot be empty. Fill in all the details to register");
                    alert.SetButton("OK", (c, ev) => { });
                    alert.Show();
                } else
                {
                    if (dbhelper.CheckExistingUser(txt_email.Text))
                    {
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Existing User");
                        alert.SetMessage("Email you've entered is already being used. Please select different email.");
                        alert.SetButton("OK", (c, ev) => { });
                        alert.Show();
                    }
                    else
                    {
                        dbhelper.UserRegistration(txt_email.Text, txt_pass.Text, txt_age.Text, txt_phone.Text);
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Registration Complete");
                        alert.SetMessage("You have been successfully registered. Please login to continue.");
                        alert.SetButton("OK", (c, ev) =>
                        {
                            Intent loginpage = new Intent(this, typeof(Login_Activity));
                            StartActivity(loginpage);
                            this.Finish();
                        });
                        alert.Show();
                    }
                }
            };

            btn_home.Click += delegate
            {
                Intent homepage = new Intent(this, typeof(MainActivity));
                StartActivity(homepage);
                this.Finish();
            };
        }
    }
}