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
    public class UserObj
    {
        public string useremail;
        public string userpass;
        public string userage;
        public string userphone;

        public UserObj()
        {

        }

        public UserObj(string uemail, string upass, string uage, string uphone)
        {
            this.useremail = uemail;
            this.userpass = upass;
            this.userage = uage;
            this.userphone = uphone;
        }

        public UserObj(UserObj uobj)
        {
            this.useremail = uobj.useremail;
            this.userpass = uobj.userpass;
            this.userage = uobj.userage;
            this.userphone = uobj.userphone;
        }
    }
}