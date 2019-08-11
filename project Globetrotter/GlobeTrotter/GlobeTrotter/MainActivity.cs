using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace GlobeTrotter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button btn_login;
        Button btn_register;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btn_login = FindViewById<Button>(Resource.Id.btn_login);
            btn_register = FindViewById<Button>(Resource.Id.btn_register);

            btn_login.Click += delegate
            {
                Intent loginpage = new Intent(this, typeof(Login_Activity));
                StartActivity(loginpage);
                this.Finish();
            };

            btn_register.Click += delegate
            {
                Intent registerpage = new Intent(this, typeof(Register_Activity));
                StartActivity(registerpage);
                this.Finish();
            };
        }
    }
}