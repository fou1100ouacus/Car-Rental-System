﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class clsMake
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

      public  int? MakeID { get; set; }
        public string Make { get; set; }
        public clsMake()
        {
            this.MakeID = null;
            this.Make = string.Empty;

            Mode = enMode.AddNew;
        }
        private clsMake(int ? MakeID,string Make) 
        {
            this.MakeID = MakeID;
            this.Make = Make;

            Mode = enMode.Update;
        }




        private bool _AddNewMake()
        {
            this.MakeID =MakeDataAccess.addNewMake(this.Make);

            return (this.MakeID.HasValue);
        }


        private bool _UpdateMake()
        {
            return MakeDataAccess.UpdateMake(this.MakeID, this.Make);
        }
        public static bool DoesMakeExist(int? MakeID)
        {
            return MakeDataAccess.DoesMakeExist(MakeID);
        }

        public static DataTable GetAllMakes()
        {
            return MakeDataAccess.GetAllMakes();
        }

        public static DataTable GetAllMakesName()
        {
            return MakeDataAccess.GetAllMakesName();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMake())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMake();
            }

            return false;
        }

        public static clsMake Find(int? MakeID)
        {
            string Make = string.Empty;

            bool IsFound = MakeDataAccess.GetMakeInfoByid(MakeID, ref Make);

            if (IsFound)
            {
                return new clsMake(MakeID, Make);
            }
            else
            {
                return null;
            }
        }

        public static clsMake Find(string MakeName)
        {
            int? MakeID = null;

            bool IsFound = MakeDataAccess.GetMakeInfoByName(MakeName, ref MakeID);

            if (IsFound)
            {
                return new clsMake(MakeID, MakeName);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteMake(int? MakeID)
        {
            return MakeDataAccess.DeleteMake(MakeID);
        }

      
    }
}
