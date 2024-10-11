using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enGender { Male = 0, Female = 1 };

        public int? PersonID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public int? NationalityCountryID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string GenderName => (this.Gender == enGender.Male) ? "Male" : "Female";
        public clsCountry CountryInfo { get; set; }

        public clsPerson()
        {
            this.PersonID = null;
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.NationalityCountryID = null;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = null;

            Mode = enMode.AddNew;
        }

        private clsPerson(int? PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, enGender Gender, int? NationalityCountryID,
            DateTime CreatedAt, DateTime? UpdatedAt)
        {
            this.PersonID = PersonID;
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.NationalityCountryID = NationalityCountryID;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = PeopleDataAccessLayer.AddNewPerson(this.Name, this.Address, this.Phone,
                this.Email, this.DateOfBirth, (byte)this.Gender, this.NationalityCountryID);

            return (this.PersonID.HasValue);
        }

        private bool _UpdatePerson()
        {
            return PeopleDataAccessLayer.UpdatePerson(this.PersonID, this.Name, this.Address,
                this.Phone, this.Email, this.DateOfBirth, (byte)this.Gender, this.NationalityCountryID,
                this.CreatedAt);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static clsPerson Find(int? PersonID)
        {
            string Name = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int? NationalityCountryID = null;
            DateTime CreatedAt = DateTime.Now;
            DateTime? UpdatedAt = null;

            bool IsFound = PeopleDataAccessLayer.GetPersonInfoByID(PersonID, ref Name, ref Address,
                ref Phone, ref Email, ref DateOfBirth, ref Gender, ref NationalityCountryID,
                ref CreatedAt, ref UpdatedAt);

            if (IsFound)
            {
                return new clsPerson(PersonID, Name, Address, Phone, Email,
                    DateOfBirth, (enGender)Gender, NationalityCountryID, CreatedAt, UpdatedAt);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePerson(int? PersonID)
        {
            return PeopleDataAccessLayer.DeletePerson(PersonID);
        }

        public static bool DoesPersonExist(int? PersonID)
        {
            return PeopleDataAccessLayer.DoesPersonExist(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return PeopleDataAccessLayer.GetAllPeople();
        }
    }
    //public class clsPerson
    //{


    //    public int ? Person_ID { get; set; }
    //    public string NationalNo { get; set; }
    //    public string FirstName { get; set; }
    //    public string SecondName
    //    {
    //        get; set;
    //    }
    //    public string FullName
    //    {
    //        get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

    //    }

    //    public clsCountry CountryInfo { get; set; }

    //    public string ThirdName { get; set; }
    //    public string LastName { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //    public enum enGender { Male = 0, Female = 1 };
    //    public enGender Gender { get; set; }

    //    public string GenderName => (this.Gender == enGender.Male) ? "Male" : "Female";

    //  //  public int Gender { get; set; }

    //    public string Address { get; set; }
    //    public string Phone { get; set; }
    //    public string Email { get; set; }
    //    public int NationalityCountryID { get; set; }
    //    public string ImagePath { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime UpdatedAt { get; set; }

    //    private clsPerson(int? id, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
    //        DateTime dateOfBirth, enGender gender, string address, string phone, string email, int nationalityCountryID, string imagePath,DateTime createdat,DateTime  updatedat)
    //    {
    //        Person_ID = id;
    //        NationalNo = nationalNo;
    //        FirstName = firstName;
    //        SecondName = secondName;
    //        ThirdName = thirdName;
    //        LastName = lastName;
    //        DateOfBirth = dateOfBirth;
    //        Gender = gender;
    //        Address = address;
    //        Phone = phone;
    //        Email = email;
    //        NationalityCountryID = nationalityCountryID;
    //        ImagePath = imagePath;
    //        UpdatedAt = updatedat;
    //        CreatedAt = createdat;

    //        Mode = enMode.enUpdate;

    //    }

    //    // Additional constructors, methods, or validations can be added as needed
    //    // Constructor with empty/default values
    //    public clsPerson()
    //    {
    //        // Set properties to empty or default values
    //        NationalNo = "";
    //        Person_ID = -1;
    //        FirstName = string.Empty;
    //        SecondName = string.Empty;
    //        ThirdName = string.Empty;
    //        LastName = string.Empty;
    //        DateOfBirth = DateTime.MinValue;
    //        Gender = 0;
    //        Address = string.Empty;
    //        Phone = string.Empty;
    //        Email = string.Empty;
    //        NationalityCountryID = -1;
    //        ImagePath = string.Empty;
    //        CreatedAt = DateTime.Now;
    //        UpdatedAt = DateTime.Now;
    //        Mode = enMode.enAdd;

    //    }
    //    public enum enMode { enUpdate = 0, enAdd = 1 }
    //    public enMode Mode { get; set; }
    //    private bool ADD_Person()
    //    {

    //        int personid = PeopleDataAccessLayer.Addnewperson(NationalNo, FirstName, SecondName,
    //         ThirdName, LastName, DateOfBirth, (byte)Gender, Address, Phone, Email,
    //        NationalityCountryID, ImagePath, CreatedAt, UpdatedAt)  ;
    //        return personid != -1;



    //    }

    //    private bool Update_Person()
    //    {
    //        return (PeopleDataAccessLayer.Updateperson(Person_ID, NationalNo, FirstName, SecondName,
    //         ThirdName, LastName, DateOfBirth, (byte)Gender, Address, Phone, Email,
    //        NationalityCountryID, ImagePath, CreatedAt, UpdatedAt));

    //    }
    //    public bool Save()
    //    {
    //        switch (this.Mode)
    //        {
    //            case enMode.enAdd:
    //                return ADD_Person();
    //                Mode = enMode.enUpdate;

    //            case enMode.enUpdate:
    //                return Update_Person();
    //            default:

    //                return false;

    //        }

    //    }



    //    public static clsPerson FindByID(int? id)
    //    {
    //        string NationalNo = "";
    //        string FirstName = string.Empty;
    //        string SecondName = string.Empty;
    //        string ThirdName = string.Empty;
    //        string LastName = string.Empty;
    //        DateTime DateOfBirth = DateTime.MinValue;
    //        byte Gender = 0;
    //        string Address = string.Empty;
    //        string Phone = string.Empty;
    //        string Email = string.Empty;
    //        int  NationalityCountryID =-1;
    //        string ImagePath = string.Empty;
    //        DateTime createdat = DateTime.Now;
    //        DateTime updatedat=DateTime.Now;    
    //        clsPerson person = null;
    //        if (PeopleDataAccessLayer.Find_person_By_ID(id, ref NationalNo, ref FirstName, ref SecondName,
    //        ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
    //        ref NationalityCountryID, ref ImagePath  ,ref createdat,ref updatedat))
    //        {
    //            person = new clsPerson(id, NationalNo, FirstName, SecondName,
    //         ThirdName, LastName, DateOfBirth,(enGender) Gender, Address, Phone, Email,
    //        NationalityCountryID, ImagePath,createdat,updatedat);
    //        }
    //        else
    //        {
    //            person = null;
    //        }

    //        return person;

    //    }
    //    public static clsPerson FindByEmail(string Email)
    //    {
    //        string NationalNo = "";
    //        string FirstName = string.Empty;
    //        string SecondName = string.Empty;
    //        string ThirdName = string.Empty;
    //        string LastName = string.Empty;
    //        DateTime DateOfBirth = DateTime.MinValue;
    //        byte Gender = 0;
    //        string Address = string.Empty;
    //        string Phone = string.Empty;

    //        int NationalityCountryID = 0;
    //        string ImagePath = string.Empty;
    //        int id = 0;
    //        DateTime updatedat = DateTime.Now;
    //        DateTime createdat = DateTime.Now;
    //        clsPerson person = null;
    //        if (PeopleDataAccessLayer.Find_person_By_Email(ref id, ref NationalNo, ref FirstName, ref SecondName,
    //        ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, Email,
    //        ref NationalityCountryID, ref ImagePath, ref createdat, ref updatedat))
    //        {
    //            person = new clsPerson(id, NationalNo, FirstName, SecondName,
    //         ThirdName, LastName, DateOfBirth,(enGender) Gender, Address, Phone, Email,
    //        NationalityCountryID, ImagePath,createdat,updatedat);
    //        }
    //        else
    //        {
    //            person = null;
    //        }

    //        return person;

    //    }

    //    //public static clsPerson FindByFirstName(string FirstName)
    //    //{
    //    //    string NationalNo = "";
    //    //    string Email = "";
    //    //    string SecondName = string.Empty;
    //    //    string ThirdName = string.Empty;
    //    //    string LastName = string.Empty;
    //    //    DateTime DateOfBirth = DateTime.MinValue;
    //    //    int Gender = 0;
    //    //    string Address = string.Empty;
    //    //    string Phone = string.Empty;

    //    //    int NationalityCountryID = 0;
    //    //    string ImagePath = string.Empty;
    //    //    int id = 0;
    //    //    clsPerson person = null;
    //    //    if (PeopleDataAccessLayer.Find_person_By_FirstName(ref id, ref NationalNo, FirstName, ref SecondName,
    //    //    ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
    //    //    ref NationalityCountryID, ref ImagePath))
    //    //    {
    //    //        person = new clsPerson(id, NationalNo, FirstName, SecondName,
    //    //     ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email,
    //    //    NationalityCountryID, ImagePath);
    //    //    }
    //    //    else
    //    //    {
    //    //        person = null;
    //    //    }

    //    //    return person;

    //    //}

    //    public static clsPerson FindByNationalNum(string NationalNo)
    //    {
    //        // string NationalNo = "";
    //        string Email = "";
    //        string SecondName = string.Empty;
    //        string ThirdName = string.Empty;
    //        string LastName = string.Empty;
    //        string FirstName = "";
    //        DateTime DateOfBirth = DateTime.MinValue;
    //        byte Gender = 0;
    //        string Address = string.Empty;
    //        string Phone = string.Empty;

    //        int NationalityCountryID = 0;
    //        string ImagePath = string.Empty;
    //        int id = 0;
    //        clsPerson person = null;
    //        DateTime updatedat = DateTime.Now;
    //        DateTime createdat = DateTime.Now;
    //        if (PeopleDataAccessLayer.Find_person_By_NationalNo(ref id, NationalNo, ref FirstName, ref SecondName,
    //        ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
    //        ref NationalityCountryID, ref ImagePath,ref createdat,ref updatedat ))
    //        {
    //            person = new clsPerson(id, NationalNo, FirstName, SecondName,
    //         ThirdName, LastName, DateOfBirth,(enGender) Gender, Address, Phone, Email,
    //        NationalityCountryID, ImagePath,createdat,updatedat);
    //        }
    //        else
    //        {
    //            person = null;
    //        }

    //        return person;

    //    }

    //    public static bool isPersonExist(string NationlNo)
    //    {
    //        return FindByNationalNum(NationlNo) != null;
    //    }


    //    public static bool IsDeleted(int? id)
    //    {
    //        return PeopleDataAccessLayer.Delete_Person(id);
    //    }

    //    public static DataTable PeoplesList()
    //    {
    //        return PeopleDataAccessLayer.GETlist();
    //    }



    //}
}
