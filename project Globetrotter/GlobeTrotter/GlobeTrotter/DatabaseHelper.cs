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

        private const string Table_Hotel = "hotels";
        private const string Col_HotelImg = "hotelimg";
        private const string Col_HotelName = "hotelname";
        private const string Col_HotelAddress = "hoteladdress";
        private const string Col_HotelContact = "hotelphone";
        private const string Col_HotelRating = "hotelrating";

        private const string Table_Room = "rooms";
        private const string Col_RoomImg = "roomimg";
        private const string Col_RoomHotel = "roomhotel";
        private const string Col_RoomName = "roomname";
        private const string Col_RoomPeople = "roompeople";
        private const string Col_RoomDetails = "roomdetails";
        private const string Col_RoomFacilities = "roomfacilities";
        private const string Col_RoomPrice = "roomprice";

        private const string Table_Favorite = "favorites";
        private const string Col_FavUser = "favoriteuser";
        private const string Col_FavImg = "favoriteimg";
        private const string Col_FavHotel = "favoritehotel";
        private const string Col_FavAddress = "favoriteaddress";
        private const string Col_FavPhone = "favoritephone";
        private const string Col_FavRating = "favoriterating";

        private const string Table_Booking = "bookings";
        private const string Col_BookUser = "bookinguser";
        private const string Col_BookHotel = "bookinghotel";
        private const string Col_BookRoom = "bookingroom";
        private const string Col_BookRoomImg = "bookingroomimg";
        private const string Col_BookCost = "bookingcost";
        private const string Col_BookCheckin = "bookingcheckindate";
        private const string Col_BookCheckout = "bookingcheckoutdate";

        public const string CreateCustomerTableQuery = "CREATE TABLE " + Table_Customer + " (" +
            Col_CustEmail + " TEXT, " +
            Col_CustPass + " TEXT, " +
            Col_CustAge + " TEXT, " +
            Col_CustPhone + " TEXT)";

        public const string DeleteCustomerTableQuery = "DROP TABLE IF EXISTS " + Table_Customer;

        public const string CreateHotelTableQuery = "CREATE TABLE " + Table_Hotel + " (" +
            Col_HotelImg + " INTEGER, " +
            Col_HotelName + " TEXT, " +
            Col_HotelAddress + " TEXT, " +
            Col_HotelContact + " TEXT, " +
            Col_HotelRating + " TEXT)";

        public const string DeleteHotelTableQuery = "DROP TABLE IF EXISTS " + Table_Hotel;

        public const string CreateRoomTableQuery = "CREATE TABLE " + Table_Room + " (" +
            Col_RoomImg + " INTEGER, " +
            Col_RoomHotel + " TEXT, " +
            Col_RoomName + " TEXT, " +
            Col_RoomPeople + " TEXT, " +
            Col_RoomDetails + " TEXT, " +
            Col_RoomFacilities + " TEXT, " +
            Col_RoomPrice + " TEXT)";

        public const string DeleteRoomTableQuery = "DROP TABLE IF EXISTS " + Table_Room;

        public const string CreateFavoriteTableQuery = "CREATE TABLE " + Table_Favorite + " (" +
            Col_FavUser + " TEXT, " +
            Col_FavImg + " INTEGER, " +
            Col_FavHotel + " TEXT, " +
            Col_FavAddress + " TEXT, " +
            Col_FavPhone + " TEXT, " +
            Col_FavRating + " TEXT)";

        public const string DeleteFavoriteTableQuery = "DROP TABLE IF EXISTS " + Table_Favorite;

        public const string CreateBookingTableQuery = "CREATE TABLE " + Table_Booking + " (" +
            Col_BookUser + " TEXT, " +
            Col_BookHotel + " TEXT, " +
            Col_BookRoom + " TEXT, " +
            Col_BookRoomImg + " INTEGER, " +
            Col_BookCost + " TEXT, " +
            Col_BookCheckin + " TEXT, " +
            Col_BookCheckout + " TEXT)";
        
        public const string DeleteBookingTableQuery = "DROP TABLE IF EXISTS " + Table_Booking;

        SQLiteDatabase dbWritablObject;
        public DatabaseHelper(Context context) :
        base(context, name: _DatabaseName, factory: null, version: 1)
        {
            dbWritablObject = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CreateCustomerTableQuery);
            db.ExecSQL(CreateHotelTableQuery);
            db.ExecSQL(CreateRoomTableQuery);
            db.ExecSQL(CreateFavoriteTableQuery);
            db.ExecSQL(CreateBookingTableQuery);
            System.Console.WriteLine("OnCreate() Called. Tables have been prepared.");
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(DeleteCustomerTableQuery);
            db.ExecSQL(DeleteHotelTableQuery);
            db.ExecSQL(DeleteRoomTableQuery);
            db.ExecSQL(DeleteFavoriteTableQuery);
            db.ExecSQL(DeleteBookingTableQuery);
            System.Console.WriteLine("OnUpgrade() Called. Tables have been deleted.");
        }
        
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

        public void InsertSingleHotel(int hotelimg, string hotelname, string hoteladdress, string hotelphone, string hotelrating)
        {
            var insertQuery = "INSERT INTO " + Table_Hotel +
            " VALUES(" + 
            hotelimg + ",'" +
            hotelname + "','" +
            hoteladdress + "','" +
            hotelphone + "','" +
            hotelrating + "')";

            System.Console.WriteLine("[Table_Hotel] Insert Query - " + insertQuery);
            dbWritablObject.ExecSQL(insertQuery);
        }

        public void InsertSingleRoom(int roomimg, string roomhotel, string roomname, string roompeople, string roomdetails, string roomfacilities, string roomprice)
        {
            var insertQuery = "INSERT INTO " + Table_Room +
            " VALUES(" +
            roomimg + ",'" +
            roomhotel + "','" +
            roomname + "','" +
            roompeople + "','" +
            roomdetails + "','" +
            roomfacilities + "','" +
            roomprice + "')";

            System.Console.WriteLine("[Table_Room] Insert Query - " + insertQuery);
            dbWritablObject.ExecSQL(insertQuery);
        }

        public void InsertSingleFavorite(string fuser, int fimg, string fhotel, string faddress, string fphone, string frating)
        {
            var insertQuery = "INSERT INTO " + Table_Favorite +
            " VALUES('" +
            fuser + "', " +
            fimg + ",'" +
            fhotel + "','" +
            faddress + "','" +
            fphone + "','" +
            frating + "')";

            System.Console.WriteLine("[Table_Favorite] Insert Query - " + insertQuery);
            dbWritablObject.ExecSQL(insertQuery);
        }

        public void InsertSingleFavoriteObj(FavoriteObj fobj)
        {
            var insertQuery = "INSERT INTO " + Table_Favorite +
            " VALUES('" +
            fobj.favEmail + "', " +
            fobj.favImg + ",'" +
            fobj.favHotel + "','" +
            fobj.favAddress + "','" +
            fobj.favPhone + "','" +
            fobj.favRatings + "')";

            System.Console.WriteLine("[Table_Favorite] Insert Query - " + insertQuery);
            dbWritablObject.ExecSQL(insertQuery);
        }

        public void RemoveSingleFavorite(string fuser, string fhotel)
        {
            var deleteQuery = "DELETE FROM " + Table_Favorite +
            " WHERE " + Col_FavUser + "='" + fuser + "' AND " + Col_FavHotel + "='" + fhotel + "'";

            System.Console.WriteLine("[Table_Favorite] Delete Query - " + deleteQuery);
            dbWritablObject.ExecSQL(deleteQuery);
        }

        public void InsertHotelList(List<HotelObj> hotels)
        {
            for (int i = 0; i < hotels.Count; i++)
            {
                var insertQuery = "INSERT INTO " + Table_Hotel +
                    " VALUES(" +
                    hotels[i].hotelimg + ",'" +
                    hotels[i].hotelname + "','" +
                    hotels[i].hoteladdress + "','" +
                    hotels[i].hotelcontact + "','" +
                    hotels[i].hotelratings + "')";

                System.Console.WriteLine("[Table_Hotel] Insert List Query - " + insertQuery);
                dbWritablObject.ExecSQL(insertQuery);
            }
        }

        public void InsertRoomList(List<RoomObj> rooms)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                var insertQuery = "INSERT INTO " + Table_Room +
                    " VALUES(" +
                    rooms[i].roomImg + ",'" +
                    rooms[i].roomHotel + "','" +
                    rooms[i].roomName + "','" +
                    rooms[i].roomPeople + "','" +
                    rooms[i].roomDetails + "','" +
                    rooms[i].roomFacilities + "','" +
                    rooms[i].roomPrice + "')";

                System.Console.WriteLine("[Table_Room] Insert List Query - " + insertQuery);
                dbWritablObject.ExecSQL(insertQuery);
            }
        }

        public void InsertBooking(string bookuser, string bookhotel, string bookroom, int bookroomimg, string bookcost, string bookcheckin, string bookcheckout)
        {
            var insertQuery = "INSERT INTO " + Table_Booking +
            " VALUES('" +
            bookuser + "','" +
            bookhotel + "','" +
            bookroom + "'," +
            bookroomimg + ",'" +
            bookcost + "','" +
            bookcheckin + "','" +
            bookcheckout + "')";

            System.Console.WriteLine("[Table_Booking] Insert Query - " + insertQuery);
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

        public bool DoesHotelTableExist()
        {
            var selectquery = "SELECT * FROM " + Table_Hotel;
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
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

        public bool DoesRoomTableExist()
        {
            var selectquery = "SELECT * FROM " + Table_Room;
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
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

        public bool DoesFavoriteTableExist()
        {
            var selectquery = "SELECT * FROM " + Table_Favorite;
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
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

        public List<HotelObj> GetSelectedHotels(string ratings)
        {
            List<HotelObj> hotellist = new List<HotelObj>();
            var selectquery = "SELECT * FROM " + Table_Hotel + " WHERE " + Col_HotelRating + "='" + ratings + "'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
            while (cursor.MoveToNext())
            {
                int img = cursor.GetInt(cursor.GetColumnIndexOrThrow(Col_HotelImg));
                string hotel = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelName));
                string add = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelAddress));
                string phone = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelContact));
                string rating = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelRating));
                hotellist.Add(new HotelObj(img, hotel, add, phone, rating));
            }
            return hotellist;
        }

        public HotelObj GetSingleHotel(string hotelname)
        {
            HotelObj hotel = new HotelObj();
            var selectquery = "SELECT * FROM " + Table_Hotel + " WHERE " + Col_HotelName + "='" + hotelname + "'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
            while (cursor.MoveToNext())
            {
                int img = cursor.GetInt(cursor.GetColumnIndexOrThrow(Col_HotelImg));
                string hname = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelName));
                string add = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelAddress));
                string phone = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelContact));
                string rating = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelRating));
                hotel.hotelimg = img;
                hotel.hotelname = hname;
                hotel.hoteladdress = add;
                hotel.hotelcontact = phone;
                hotel.hotelratings = rating;
            }
            return hotel;
        }

        public RoomObj GetSingleRoom(string hotelname, string roomname)
        {
            RoomObj room = new RoomObj();
            var selectquery = "SELECT * FROM " + Table_Room + " WHERE " + Col_RoomHotel + "='" + hotelname + "' AND " + Col_RoomName + "='" + roomname +"'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
            while (cursor.MoveToNext())
            {
                int img = cursor.GetInt(cursor.GetColumnIndexOrThrow(Col_RoomImg));
                string hname = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomHotel));
                string rname = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomName));
                string details = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomDetails));
                string facilities = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomFacilities));
                string people = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomPeople));
                string price = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomPrice));
                room.roomImg = img;
                room.roomHotel = hname;
                room.roomName = rname;
                room.roomDetails = details;
                room.roomFacilities = facilities;
                room.roomPeople = people;
                room.roomPrice = price;
            }
            return room;
        }

        public List<HotelObj> GetAllHotels()
        {
            List<HotelObj> hotellist = new List<HotelObj>();
            var selectquery = "SELECT * FROM " + Table_Hotel;
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
            while (cursor.MoveToNext())
            {
                int img = cursor.GetInt(cursor.GetColumnIndexOrThrow(Col_HotelImg));
                string hotel = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelName));
                string add = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelAddress));
                string phone = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelContact));
                string rating = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_HotelRating));
                hotellist.Add(new HotelObj(img, hotel, add, phone, rating));
            }
            return hotellist;
        }

        public List<RoomObj> GetAllRooms(string hotelname)
        {
            List<RoomObj> roomlist = new List<RoomObj>();
            var selectquery = "SELECT * FROM " + Table_Room + " WHERE " + Col_RoomHotel + "='" + hotelname + "'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
            while (cursor.MoveToNext())
            {
                int img = cursor.GetInt(cursor.GetColumnIndexOrThrow(Col_RoomImg));
                string hotel = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomHotel));
                string details = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomDetails));
                string facilities = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomFacilities));
                string roomname = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomName));
                string people = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomPeople));
                string price = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_RoomPrice));
                roomlist.Add(new RoomObj(img, hotel, roomname, people, details, facilities, price));
            }
            return roomlist;
        }

        public List<FavoriteObj> GetFavoriteHotels(string useremail)
        {
            List<FavoriteObj> hotellist = new List<FavoriteObj>();
            var selectquery = "SELECT * FROM " + Table_Favorite + " WHERE " + Col_FavUser + "='" + useremail + "'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
            while (cursor.MoveToNext())
            {
                int img = cursor.GetInt(cursor.GetColumnIndexOrThrow(Col_FavImg));
                string hotel = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_FavHotel));
                string add = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_FavAddress));
                string phone = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_FavPhone));
                string rating = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_FavRating));
                hotellist.Add(new FavoriteObj(useremail, img, hotel, add, phone, rating));
            }
            return hotellist;
        }

        public List<BookingObj> GetUserBookings(string useremail)
        {
            List<BookingObj> bookings = new List<BookingObj>();
            var selectquery = "SELECT * FROM " + Table_Booking + " WHERE " + Col_BookUser + "='" + useremail + "'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
            while (cursor.MoveToNext())
            {
                int img = cursor.GetInt(cursor.GetColumnIndexOrThrow(Col_BookRoomImg));
                string hotel = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_BookHotel));
                string room = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_BookRoom));
                string cost = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_BookCost));
                string checkin = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_BookCheckin));
                string checkout = cursor.GetString(cursor.GetColumnIndexOrThrow(Col_BookCheckout));
                bookings.Add(new BookingObj(Col_BookUser, hotel, room, img, cost, checkin, checkout));
                System.Console.Write("Bookings - " + hotel + " " + room + " " + cost + " " + checkin + " " + checkout);
            }
            return bookings;
        }

        public UserObj SearchUser(string useremail)
        {
            UserObj user = new UserObj();
            var selectQuery = "SELECT * FROM " + Table_Customer + " WHERE " + Col_CustEmail + " = '" + useremail + "'";
            ICursor cur = dbWritablObject.RawQuery(selectQuery, null);
            if (cur.MoveToNext())
            {
                user.useremail = cur.GetString(cur.GetColumnIndexOrThrow(Col_CustEmail));
                user.userpass = cur.GetString(cur.GetColumnIndexOrThrow(Col_CustPass));
                user.userage = cur.GetString(cur.GetColumnIndexOrThrow(Col_CustAge));
                user.userphone = cur.GetString(cur.GetColumnIndexOrThrow(Col_CustPhone));
            }
            else
            {
                System.Console.WriteLine("Cannot find the user with that email address");
            }
            return user;
        }

        public bool UpdateUserDetails(UserObj user)
        {
            var updateQuery = "UPDATE " + Table_Customer + " SET " +
                Col_CustPass + " ='" + user.userpass +
                "', " +
                Col_CustAge + " = '" + user.userage +
                "', " +
                Col_CustPhone + " = '" + user.userphone +
                "' WHERE " +
                Col_CustEmail + " = '" + user.useremail + "'";

            dbWritablObject.ExecSQL(updateQuery);
            return true;
        }

        public bool AlreadyFavorite(string useremail, string hotelname)
        {
            var selectquery = "SELECT * FROM " + Table_Favorite + " WHERE " + Col_FavUser + "='" + useremail + "' AND " + Col_FavHotel + "='" + hotelname + "'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
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

        public bool AnyBookingsPresent(string useremail)
        {
            var selectquery = "SELECT * FROM " + Table_Booking + " WHERE " + Col_BookUser + "='" + useremail + "'";
            ICursor cursor = dbWritablObject.RawQuery(selectquery, null);
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

        public bool MatchUserPassword(string useremail, string upass)
        {
            var selectQuery = "SELECT * FROM " + Table_Customer + " WHERE " +
                Col_CustEmail + " = '" + useremail +
                "' AND " +
                Col_CustPass + " = '" + upass + "'";

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

        public void ChangeUserPass(string useremail, string newpass)
        {
            var updateQuery = "UPDATE " + Table_Customer + " SET " +
                Col_CustPass + " ='" + newpass +
                "' WHERE " +
                Col_CustEmail + " = '" + useremail + "'";

            dbWritablObject.ExecSQL(updateQuery);
        }
    }
}