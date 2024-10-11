﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{



    public class clsCustomer : clsPerson
    {
        
        public int? CustomerID { get; set; }
        public string DriverLicenseNumber { get; set; }
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsCustomer()
        {
            this.CustomerID = null;
            this.PersonID = null;
            this.DriverLicenseNumber = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsCustomer(int? PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, enGender Gender, int? NationalityCountryID,
            DateTime CreatedAt, DateTime? UpdatedAt, int? CustomerID, string DriverLicenseNumber)
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

            this.CustomerID = CustomerID;
            this.DriverLicenseNumber = DriverLicenseNumber;

            Mode = enMode.Update;
        }


        private bool _AddNewCustomer()
        {
            this.CustomerID = CustomersDataAccess.AddNewCustomer(this.PersonID,
                this.DriverLicenseNumber);

            return (this.CustomerID.HasValue);
        }

        private bool _UpdateCustomer()
        {
            return CustomersDataAccess.UpdateCustomer(this.CustomerID,
                this.PersonID, this.DriverLicenseNumber);
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
                    if (_AddNewCustomer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCustomer();
            }

            return false;
        }

        private static int? _GetPersonIDByCustomerID(int? CustomerID)
        {
            return CustomersDataAccess.GetPersonIDByCustomerID(CustomerID);
        }

        public static clsCustomer Find(int? CustomerID)
        {
            int? PersonID = null;
            string DriverLicenseNumber = string.Empty;

            bool IsFound = CustomersDataAccess.GetCustomerInfoByID
                (CustomerID, ref PersonID, ref DriverLicenseNumber);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsCustomer(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, CustomerID, DriverLicenseNumber);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteCustomer(int? CustomerID)
        {
            int? PersonID = _GetPersonIDByCustomerID(CustomerID);

            if (!PersonID.HasValue)
            {
                return false;
            }

            if (CustomersDataAccess.DeleteCustomer(CustomerID))
            {
                return clsPerson.DeletePerson(PersonID);
            }

            return false;
        }

        public static bool DoesCustomerExist(int? CustomerID)
        {
            return CustomersDataAccess.DoesCustomerExist(CustomerID);
        }

        public static bool DoesDriverLicenseNumberExist(string DriverLicenseNumber)
        {
            return CustomersDataAccess.DoesDriverLicenseNumberExist(DriverLicenseNumber);
        }

        public static DataTable GetAllCustomers()
        {
            return CustomersDataAccess.GetAllCustomers();
        }

        public static int GetCustomersCount()
        {
            return CustomersDataAccess.GetCustomersCount();
        }

        //public DataTable GetBookingHistory()
        //{
        //    return clsBooking.GetBookingHistoryByCustomerID(this.CustomerID);
        //}

        //public DataTable GetTransactionHistory()
        //{
        //    return clsTransaction.GetAllRentalTransactionByCustomerID(this.CustomerID);
        //}
    }





}
