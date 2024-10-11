using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   
        public class clsUser : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enPermissions
        {
            All = -1,
            ManageCustomers = 1,
            ManageUsers = 2,
            ManageVehicles = 4,
            ManageBooking = 8,
            ManageReturn = 16,
            ManageTransactions = 32
        }
        public int? UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = null;
            this.PersonID = null;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Permissions = -1;
            this.SecurityQuestion = null;
            this.SecurityAnswer = null;
            this.ImagePath = null;
            this.IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int? PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, enGender Gender, int? NationalityCountryID,
            DateTime CreatedAt, DateTime? UpdatedAt, int? UserID, string Username, string Password,
            int Permissions, string SecurityQuestion, string SecurityAnswer,
            string ImagePath, bool IsActive)
        {
            base.PersonID = PersonID;
            base.Name = Name;
            base.Address = Address;
            base.Phone = Phone;
            base.Email = Email;
            base.DateOfBirth = DateOfBirth;
            base.Gender = Gender;
            base.NationalityCountryID = NationalityCountryID;
            base.CreatedAt = CreatedAt;
            base.UpdatedAt = UpdatedAt;
            base.CountryInfo = clsCountry.Find(NationalityCountryID);

            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.SecurityQuestion = SecurityQuestion;
            this.SecurityAnswer = SecurityAnswer;
            this.ImagePath = ImagePath;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = UserDataAccess.AddNewUser(this.PersonID, this.Username, this.Password,
                this.Permissions, this.SecurityQuestion, this.SecurityAnswer, this.ImagePath,
                this.IsActive);

            return (this.UserID.HasValue);
        }

        private bool _UpdateUser()
        {
            return UserDataAccess.UpdateUser(this.UserID, this.PersonID, this.Username, this.Password,
                this.Permissions, this.SecurityQuestion, this.SecurityAnswer, this.ImagePath,
                this.IsActive);
        }

        public bool Save()
        {
            base.Mode = (clsPerson.enMode)Mode;

            if (!base.Save())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        private static int? _GetPersonIDByUserID(int? UserID)
        {
            return UserDataAccess.GetPersonIDByUserID(UserID);
        }

        public static clsUser Find(int? UserID)
        {
            int? PersonID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            int Permissions = -1;
            string SecurityQuestion = null;
            string SecurityAnswer = null;
            string ImagePath = null;
            bool IsActive = false;

            bool IsFound = UserDataAccess.GetUserInfoByID(UserID, ref PersonID, ref Username,
                ref Password, ref Permissions, ref SecurityQuestion, ref SecurityAnswer,
                ref ImagePath, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, UserID, Username, Password, Permissions,
                    SecurityQuestion, SecurityAnswer, ImagePath, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username)
        {
            int? UserID = null;
            int? PersonID = null;
            string Password = string.Empty;
            int Permissions = -1;
            string SecurityQuestion = null;
            string SecurityAnswer = null;
            string ImagePath = null;
            bool IsActive = false;

            bool IsFound = UserDataAccess.GetUserInfoByUsername(ref UserID, ref PersonID, Username,
                ref Password, ref Permissions, ref SecurityQuestion, ref SecurityAnswer,
                ref ImagePath, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, UserID, Username, Password, Permissions,
                    SecurityQuestion, SecurityAnswer, ImagePath, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username, string Password)
        {
            int? UserID = null;
            int? PersonID = null;
            int Permissions = -1;
            string SecurityQuestion = null;
            string SecurityAnswer = null;
            string ImagePath = null;
            bool IsActive = false;

            bool IsFound = UserDataAccess.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID,
                Username, Password, ref Permissions, ref SecurityQuestion, ref SecurityAnswer,
                ref ImagePath, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, UserID, Username, Password, Permissions,
                    SecurityQuestion, SecurityAnswer, ImagePath, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteUser(int? UserID)
        {
            int? PersonID = _GetPersonIDByUserID(UserID);

            if (!PersonID.HasValue)
            {
                return false;
            }

            if (UserDataAccess.DeleteUser(UserID))
            {
                return clsPerson.DeletePerson(PersonID);
            }

            return false;
        }

        public static bool DoesUserExist(int? UserID)
        {
            return UserDataAccess.DoesUserExist(UserID);
        }

        public static bool DoesUserExist(string Username)
        {
            return UserDataAccess.DoesUserExist(Username);
        }

        public static bool DoesUserExist(string Username, string Password)
        {
            return UserDataAccess.DoesUserExist(Username, Password);
        }

        public static DataTable GetAllUsers()
        {
            return UserDataAccess.GetAllUsers();
        }

        public static int GetUsersCount()
        {
            return UserDataAccess.GetUsersCount();
        }

        public bool ChangePassword(string NewPassword)
        {
            return ChangePassword(this.UserID, NewPassword);
        }

        public static bool ChangePassword(int? UserID, string NewPassword)
        {
            return UserDataAccess.ChangePassword(UserID, NewPassword);
        }
    }





















        //public enum enMode { AddNew = 0, Update = 1 };
        //public enMode Mode = enMode.AddNew;

        //public int UserID { set; get; }
        //public int PersonID { set; get; }
        //public clsPerson PersonInfo;
        //public string UserName { set; get; }
        //public string Password { set; get; }
        //public bool IsActive { set; get; }

        //public clsUser()

        //{
        //    this.UserID = -1;
        //    this.UserName = "";
        //    this.Password = "";
        //    this.IsActive = true;
        //    Mode = enMode.AddNew;
        //}

        //private clsUser(int UserID, int PersonID, string Username, string Password,
        //    bool IsActive)

        //{
        //    this.UserID = UserID;
        //    this.PersonID = PersonID;
        //    this.PersonInfo = clsPerson.FindByID(PersonID);
        //    this.UserName = Username;
        //    this.Password = Password;
        //    this.IsActive = IsActive;

        //    Mode = enMode.Update;
        //}

        //private bool _AddNewUser()
        //{
        //    //call DataAccess Layer 

        //    this.UserID = UserDataAccess.AddNewUser(this.PersonID, this.UserName,
        //        this.Password, this.IsActive);

        //    return (this.UserID != -1);
        //}
        //private bool _UpdateUser()
        //{
        //    //call DataAccess Layer 

        //    return UserDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName,
        //        this.Password, this.IsActive);
        //}
        //public static clsUser FindByUserID(int UserID)
        //{
        //    int PersonID = -1;
        //    string UserName = "", Password = "";
        //    bool IsActive = false;

        //    bool IsFound = UserDataAccess.GetUserInfoByUserID
        //                        (UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

        //    if (IsFound)
        //        //we return new object of that User with the right data
        //        return new clsUser(UserID, PersonID, UserName, Password, IsActive);
        //    else
        //        return null;
        //}
        //public static clsUser FindByPersonID(int PersonID)
        //{
        //    int UserID = -1;
        //    string UserName = "", Password = "";
        //    bool IsActive = false;

        //    bool IsFound = UserDataAccess.GetUserInfoByPersonID
        //                        (PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

        //    if (IsFound)
        //        //we return new object of that User with the right data
        //        return new clsUser(UserID, UserID, UserName, Password, IsActive);
        //    else
        //        return null;
        //}
        //public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        //{
        //    int UserID = -1;
        //    int PersonID = -1;

        //    bool IsActive = false;

        //    bool IsFound = UserDataAccess.GetUserInfoByUsernameAndPassword
        //                        (UserName, Password, ref UserID, ref PersonID, ref IsActive);

        //    if (IsFound)
        //        //we return new object of that User with the right data
        //        return new clsUser(UserID, PersonID, UserName, Password, IsActive);
        //    else
        //        return null;
        //}

        //public bool Save()
        //{

        //    switch (Mode)
        //    {
        //        case enMode.AddNew:
        //            if (_AddNewUser())
        //            {

        //                Mode = enMode.Update;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }

        //        case enMode.Update:

        //            return _UpdateUser();

        //    }

        //    return false;
        //}

        //public static DataTable GetAllUsers()
        //{
        //    return UserDataAccess.GetAllUsers();
        //}

        //public static bool DeleteUser(int UserID)
        //{
        //    return UserDataAccess.DeleteUser(UserID);
        //}

        //public static bool isUserExist(int UserID)
        //{
        //    return UserDataAccess.IsUserExist(UserID);
        //}

        //public static bool isUserExist(string UserName)
        //{
        //    return UserDataAccess.IsUserExist(UserName);
        //}

        //public static bool isUserExistForPersonID(int PersonID)
        //{
        //    return UserDataAccess.IsUserExistForPersonID(PersonID);
        //}



    }
