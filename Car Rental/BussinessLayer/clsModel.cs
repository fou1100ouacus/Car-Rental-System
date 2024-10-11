using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsModel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ModelID { get; set; }
        public int MakeID { get; set; }
        public string ModelName { get; set; }

        public clsModel()
        {
            this.ModelID = null;
            this.MakeID = -1;
            this.ModelName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsModel(int? ModelID, int MakeID, string ModelName)
        {
            this.ModelID = ModelID;
            this.MakeID = MakeID;
            this.ModelName = ModelName;

            Mode = enMode.Update;
        }

        private bool _AddNewModel()
        {
            this.ModelID = ModelDataAccess.AddNewModel(this.MakeID, this.ModelName);

            return (this.ModelID.HasValue);
        }

        private bool _UpdateModel()
        {
            return ModelDataAccess.UpdateModel(this.ModelID, this.MakeID, this.ModelName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewModel())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateModel();
            }

            return false;
        }

        public static clsModel Find(int? ModelID)
        {
            int MakeID = -1;
            string ModelName = string.Empty;

            bool IsFound = ModelDataAccess.GetModelInfoByID(ModelID, ref MakeID, ref ModelName);

            if (IsFound)
            {
                return new clsModel(ModelID, MakeID, ModelName);
            }
            else
            {
                return null;
            }
        }

        public static clsModel Find(string ModelName)
        {
            int MakeID = -1;
            int? ModelID = null;

            bool IsFound = ModelDataAccess.GetModelInfoByName(ModelName, ref ModelID, ref MakeID);

            if (IsFound)
            {
                return new clsModel(ModelID, MakeID, ModelName);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteModel(int? ModelID)
        {
            return ModelDataAccess.DeleteModel(ModelID);
        }

        public static bool DoesModelExist(int? ModelID)
        {
            return ModelDataAccess.DoesModelExist(ModelID);
        }

        public static DataTable GetAllModels()
        {
            return ModelDataAccess.GetAllModels();
        }

        public static DataTable GetAllModelsNameAsync()
        {
            return ModelDataAccess.GetAllModelsName();
        }
    }
}
