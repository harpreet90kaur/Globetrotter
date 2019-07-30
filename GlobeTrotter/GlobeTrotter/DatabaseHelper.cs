using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GlobeTrotter
{
    class DatabaseHelper : SQLiteOpenHelper
    {
        private static string _DatabaseName = "globetrotter.db";
        private const string Table_Customer = "customers";
        private const string Col_CustEmail = "cust_email";
        private const string Col_CustPass = "cust_pass";
        private const string Col_CustAge = "cust_age";
        private const string Col_CustPhone = "cust_phone";
        
        public const string CreateCustomerTableQuery = "CREATE TABLE " + Table_Customer + " (" +
            Col_CustEmail + " TEXT, " +
            Col_CustPass + " TEXT, " +
            Col_CustAge + " TEXT, " +
            Col_CustPhone + " TEXT)";

        public const string DeleteCustomerTableQuery = "DROP TABLE IF EXISTS " + Table_Customer;
        
        SQLiteDatabase dbWritablObject;
        public DatabaseHelper(Context context) :
        base(context, name: _DatabaseName, factory: null, version: 1)
        {
            dbWritablObject = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CreateCustomerTableQuery);
            System.Console.WriteLine("OnCreate() Called. Tables have been prepared.");
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(DeleteCustomerTableQuery);
            System.Console.WriteLine("OnUpgrade() Called. Tables have been deleted.");
        }
        //create a insert function
        public void UserRegistration(string custEmail, string custPass, string custAge, string custPhone)
        {
            var insertQuery = "INSERT INTO " + Table_Customer +
            " VALUES('" +
            custEmail + "','" +
            custPass + "','" +
            custAge + "','" +
            custPhone + "')";

            System.Console.WriteLine("[Table_Customer] Insert Query - " + insertQuery);
            dbWritablObject.ExecSQL(insertQuery);
        }

       
        public bool UserLogin(string custEmail, string custPass)
        {
            var selectQuery = "SELECT * FROM " + Table_Customer + " WHERE " +
                Col_CustEmail + " = '" + custEmail +
                "' AND " +
                Col_CustPass + " = '" + custPass + "'";

            ICursor cursor = dbWritablObject.RawQuery(selectQuery, null);
            if (cursor.MoveToFirst())
            {
                cursor.Close();
                return true;
            }
            else
            {
                cursor.Close();
                return false;
            }
        }

        public bool CheckExistingUser(string custEmail)
        {
            var selectQuery = "SELECT * FROM " + Table_Customer + " WHERE " +
                Col_CustEmail + " = '" + custEmail + "'";

            ICursor cursor = dbWritablObject.RawQuery(selectQuery, null);
            if (cursor.MoveToFirst())
            {
                cursor.Close();
                return true;
            }
            else
            {
                cursor.Close();
                return false;
            }
        }
    }
}