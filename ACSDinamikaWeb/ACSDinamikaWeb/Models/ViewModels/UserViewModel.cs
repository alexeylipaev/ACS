using ACSDinamikaWeb.Models.EF.CFFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACSDinamikaWeb.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            this.User = user;
            this._Id = user.Id;
        }
        public UserViewModel(int userId)
        {
            this._Id = userId;
            ACSContext db = new EF.CFFromDB.ACSContext();

            this.User = db.Users.Find(userId);

        }
        User User;
        int? _Id;
        public int? Id { get { return _Id; }}
        public string FName { get { return User.FName; } set { User.FName = value; } }
        public string LName { get { return User.LName; } set { User.LName = value; } }
        public string MName { get { return User.MName; } set { User.MName = value; } }
        //public string EMail { get { return User.EMail; } set { User.EMail = value; } }
        public Nullable<int> PersonnelNumber { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string IssuedBy { get; set; }
        public string UnitCode { get; set; }
        public Nullable<System.DateTime> DateOfIssue { get; set; }
        public string SID { get; set; }
        public System.Guid Guid1C { get; set; }
        public void SaveToDB()
        {
            
        }
    }
}