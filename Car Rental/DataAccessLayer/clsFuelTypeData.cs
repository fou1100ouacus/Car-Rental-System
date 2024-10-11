﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsFuelTypeData
    {
        private static object clsDataAccessSettings;

        public static bool GetFuelTypeInfoByID(int? FuelTypeID, ref string FuelTypeName)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from FuelTypes where FuelTypeID = @FuelTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FuelTypeID", (object)FuelTypeID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                FuelTypeName = (string)reader["FuelTypeName"];
                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static bool GetFuelTypeInfoByName(string FuelTypeName, ref int? FuelTypeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from FuelTypes where FuelTypeName = @FuelTypeName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FuelTypeName", FuelTypeName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;
                                FuelTypeID = (reader["FuelTypeID"] != DBNull.Value) ? (int?)reader["FuelTypeID"] : null;
                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static int? AddNewFuelType(string FuelTypeName)
        {
            // This function will return the new person id if succeeded and null if not
            int? FuelTypeID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"insert into FuelTypes (FuelTypeName)
values (@FuelTypeName)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FuelTypeName", FuelTypeName);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            FuelTypeID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }
            return FuelTypeID;
        }

        public static bool UpdateFuelType(int? FuelTypeID, string FuelTypeName)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"Update FuelTypes
set FuelTypeName = @FuelTypeName
where FuelTypeID = @FuelTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FuelTypeID", (object)FuelTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FuelTypeName", FuelTypeName);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DeleteFuelType(int? FuelTypeID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"delete FuelTypes where FuelTypeID = @FuelTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FuelTypeID", (object)FuelTypeID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DoesFuelTypeExist(int? FuelTypeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select found = 1 from FuelTypes where FuelTypeID = @FuelTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FuelTypeID", (object)FuelTypeID ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static DataTable GetAllFuelTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from FuelTypes";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return dt;
        }

        public static DataTable GetAllFuelTypesName()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select distinct FuelTypeName from FuelTypes order by FuelTypeName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return dt;
        }

    }
}
