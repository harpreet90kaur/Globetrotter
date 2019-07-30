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
    [Activity(Label = "Login_Activity")]
    public class Login_Activity : Activity
    {
        Button btn_login;
        Button btn_register;
        Button btn_cancel;
        EditText txt_email;
        EditText txt_pass;
        DatabaseHelper dbhelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_layout);
            dbhelper = new DatabaseHelper(this);
            // Create your application here
            btn_login = FindViewById<Button>(Resource.Id.btn_page_login);
            btn_register = FindViewById<Button>(Resource.Id.btn_page_register);
            btn_cancel = FindViewById<Button>(Resource.Id.btn_page_home);
            txt_email = FindViewById<EditText>(Resource.Id.txt_email);
            txt_pass = FindViewById<EditText>(Resource.Id.txt_pass);

            btn_login.Click += delegate
            {
                if(txt_email.Text.Equals("") || txt_pass.Text.Equals(""))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Fields Empty Error");
                    alert.SetMessage("Fields cannot be empty. Fill in all the details to login");
                    alert.SetButton("OK", (c, ev) => { });
                    alert.Show();
                }
                else
                {
                    if(dbhelper.UserLogin(txt_email.Text, txt_pass.Text))
                    {
                        Intent welcomepage = new Intent(this, typeof(Welcome_Activity));
                        StartActivity(welcomepage);
                        this.Finish();
                    }
                    else
                    {
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Login Failure");
                        alert.SetMessage("Incorrect Email/Password. Please try again.");
                        alert.SetButton("OK", (c, ev) => { });
                        alert.Show();
                    }
                }
            };

            btn_register.Click += delegate
            {
                Intent registerpage = new Intent(this, typeof(Register_Activity));
                StartActivity(registerpage);
                this.Finish();
            };

            btn_cancel.Click += delegate
            {
                Intent homepage = new Intent(this, typeof(MainActivity));
                StartActivity(homepage);
                this.Finish();
            };
        }
    }
}