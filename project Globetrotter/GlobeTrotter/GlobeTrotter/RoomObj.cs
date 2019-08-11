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
    class RoomObj
    {
        public int roomImg;
        public string roomHotel;
        public string roomName;
        public string roomPeople;
        public string roomDetails;
        public string roomFacilities;
        public string roomPrice;
        DatabaseHelper dbhelper;

        public RoomObj()
        {

        }

        public RoomObj(int rimg, string rhotel, string rname, string rpeople, string rdetails, string rfacilities, string rprice)
        {
            this.roomImg = rimg;
            this.roomHotel = rhotel;
            this.roomName = rname;
            this.roomPeople = rpeople;
            this.roomDetails = rdetails;
            this.roomFacilities = rfacilities;
            this.roomPrice = rprice;
        }

        public void AddRooms(Activity activity)
        {
            dbhelper = new DatabaseHelper(activity);
            if(!dbhelper.DoesRoomTableExist())
            {
                List<RoomObj> robj = new List<RoomObj>();
                robj.Add(new RoomObj(Resource.Drawable.r1_h1, "Bond Place Hotel Toronto", "Premium Queen Room", "2", "Room with one large double bed. Breakfast not included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator", "174"));
                robj.Add(new RoomObj(Resource.Drawable.r2_h1, "Bond Place Hotel Toronto", "Standard Twin Room", "2", "Room with twin beds. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Shower Kit:4. Refrigerator", "144"));
                robj.Add(new RoomObj(Resource.Drawable.r3_h1, "Bond Place Hotel Toronto", "Room Selected at Check-In", "2", "Room to be selected at checkin. Guaranteed best prices", "Select your room facilities at check-in time.", "156"));
                robj.Add(new RoomObj(Resource.Drawable.r4_h1, "Bond Place Hotel Toronto", "Deluxe Twin Room", "4", "Room with extended capacity. Two twin beds to accommodate guests.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator", "230"));

                robj.Add(new RoomObj(Resource.Drawable.r1_h2, "The Westin Harbour Castle", "King Suit", "3", "Room, 1 King Bed, on the Corner. Breakfast not included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Free Cancellation:8. Pet Friendly", "157"));
                robj.Add(new RoomObj(Resource.Drawable.r2_h2, "The Westin Harbour Castle", "Queen Suit", "2", "Room, 1 Queen Bed, Lake facing balcony view. Breakfast included..", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Free Cancellation:8. Pet Friendly", "192"));

                robj.Add(new RoomObj(Resource.Drawable.r1_h3, "Chelsea Hotel", "Deluxe Room", "2", "Deluxe Room, 1 King Bed. It can accommodate up to 3 guests. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Room with the view", "213"));
                robj.Add(new RoomObj(Resource.Drawable.r2_h3, "Chelsea Hotel", "Premium Deluxe Room", "4", "Room with two large double beds. Appropriate for a family of four. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Value deal", "290"));
                robj.Add(new RoomObj(Resource.Drawable.r3_h3, "Chelsea Hotel", "Club Deluxe Room", "2", "Room with one large king size bed. Breakfast not included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator", "210"));
            
                robj.Add(new RoomObj(Resource.Drawable.r1_h4, "The Strathcona Hotel", "Smart Queen Room", "2", "Room with one double bed. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Wake up services:8. Wardrobe or Closet", "169"));
                robj.Add(new RoomObj(Resource.Drawable.r2_h4, "The Strathcona Hotel", "Queen Room", "2", "Room with one large double bed. Breakfast not included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Wake up Services", "177"));
                robj.Add(new RoomObj(Resource.Drawable.r3_h4, "The Strathcona Hotel", "Executive King Room", "2", "Room with one extra large king size bed. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Pay-per-view Channels:8. Coffee Machine", "210"));

                robj.Add(new RoomObj(Resource.Drawable.r1_h5, "Hotel Fairmont Royal York", "Standard King Room", "2", "Room with one extra-large king size bed. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Wake up services:8. Safety Deposit Box", "234"));
                robj.Add(new RoomObj(Resource.Drawable.r2_h5, "Hotel Fairmont Royal York", "Luxury King Room", "2", "Room with one extra-large double bed. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Wake up Services:8. Hairdryer:9. Minibar", "310"));
                robj.Add(new RoomObj(Resource.Drawable.r3_h5, "Hotel Fairmont Royal York", "Signature King", "2", "Room with one extra large double bed. Breakfast included.", "1. Air conditioning:2. Private Bathroom:3. Flat-screen TV:4. Shower Kit:5. Ironing/Laundry Kit:6. Refrigerator:7. Pay-per-view Channels:8. Coffee Machine:9. Sofa: 10. Seating Area", "334"));

                dbhelper.InsertRoomList(robj);
            }
        }
    }
}