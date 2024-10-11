using BussinessLayer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class Program
    {
        //public static bool addnewperson()
        //{
        //    clsPerson person = new clsPerson();

        //    person.Email = "ali@gmail.com";
        //    person.Address = "cairo";
        //    person.FirstName = "ALi";
        //    person.LastName = "mohamedd";
        //    person.SecondName = "moh";
        //    person.ThirdName = "ahmed";
        //    person.ImagePath = "nnone";
        //    person.Gender = 1;
        //    person.DateOfBirth = DateTime.Now;
        //    person.NationalityCountryID = 2;
        //    person.Phone = "093322233";
        //    person.NationalNo = "N03";
        //    person.CreatedAt = DateTime.Now;
        //    person.UpdatedAt = DateTime.Now;


        //    if (person.Save())
        //    {
        //        return true;

        //    }
        //    return false;
        //}
   
       
        public static bool ADDUser()
        {
            clsUser user = new clsUser();
            user.Username = "user021";
            user.IsActive = true;
            user.Password = "1324";
            user.Address = "hksdfi";
            user .NationalityCountryID = 0;
         //   user.CountryInfo.CountryName="smah";
            user.CreatedAt = DateTime.Now;
            user.Permissions = -1;
            user.DateOfBirth = DateTime.UtcNow;
            user.Name = "almalllllllllam";
            user.Email = "@gmail.com";
            user.Gender = 0;
            user.Phone = "43434";
            user.ImagePath = "jsdklfjsklfjs";
            if (user.Save())
            {
                return true;

            }
            return false;
        }
        public static bool Updateuser()
        {
            clsUser user = clsUser.Find("user021");
            if (user != null)
            {
                user.Password = "00340";
                if (user.Save())
                {
                    return true;
                }
            }
            return false;
        }

        //public static void AddNewCustomer()
        //{
        //    clsCustomer customer = new clsCustomer();



        //    customer.PersonID = 23;
        //    customer.DriverLicenseNumber = "002";


        //    if (customer.Save())
        //    {

        //        Console.WriteLine("Added Successfuly");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Not added");
        //    }

        //}

        public static bool FindCustomer()
        {
            clsCustomer customer = clsCustomer.Find(3);
            if (customer!=null)
            {
                return true;

            }
            return false;

        }

        public static bool AddNewMake()
        {
            clsMake make = new clsMake();
            make.Make = "toyouta";
            if(make.Save()) { return true; }
            return false;



        }

        public static bool addnewmodel()
        {
            clsModel model = new clsModel();
            model.MakeID = 1;
            model.ModelName = "nononono";

            if(model.Save())
            {
                return true;
            }
            return false;
        }

        public static void AddNewVehical()
        {
            clsVehicle vehical=new clsVehicle();
            vehical.BodyID = 2;
            vehical.Year = 5644;
            vehical.DriveTypeID = 2;
            vehical.NumberDoors = 4;
            vehical.VehicleName = "toyta";
            vehical.Engine = "sdjklf";
            vehical.RentalPricePerDay = 2;
            vehical.FuelTypeID= 2;
            vehical.IsAvailableForRent =true;
            vehical.MakeID = 2;
            vehical.SubModelID = 2;
            vehical.Mileage = 3;
            vehical.PlateNumber = "7687";
            vehical.ModelID = 3;

            if(vehical.Save())
            {
                Console.WriteLine("added"); ; 
            }
            else
            {
                Console.WriteLine("failed");
            }

        }





        static void Main(string[] args)
        {
           // AddNewVehical();








            //Console.WriteLine(addnewmodel ());
            //         Console.WriteLine(AddNewMake());
            //         Console.WriteLine(FindCustomer());
            //        Console.WriteLine(Updateuser());
            //      clsCustomer customer= new clsCustomer();
            //      customer.Name = "Customer1";
            //      customer.Phone = "10003";
            //      customer.PersonID = 24;
            //      customer.DriverLicenseNumber = "1000";
            //      customer.Address = "dsjfl";
            ////      customer.CountryInfo.CountryName = "cairo";
            //      customer.Gender = 0;
            //      customer.CreatedAt = DateTime.Now;
            //      customer.NationalityCountryID = 2;
            //      if(customer.Save())
            //      {
            //          Console.WriteLine("added");
            //      }
            //      else
            //      {
            //          Console.WriteLine("failed");

            //      }


        }
    }
}
