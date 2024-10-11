﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ?CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsCountry(int? CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;

            Mode = enMode.Update;
        }

        public static clsCountry Find(int? CountryID)
        {
            string CountryName = string.Empty;

            bool IsFound = clsCountryDataAccess.GetCountryInfoByID(CountryID, ref CountryName);

            if (IsFound)
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            bool IsFound = clsCountryDataAccess.GetCountryInfoByName(CountryName, ref CountryID);

            if (IsFound)
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }

        public static DataTable GetAllCountriesName()
        {
            return clsCountryDataAccess.GetAllCountriesName();
        }


    }
}
