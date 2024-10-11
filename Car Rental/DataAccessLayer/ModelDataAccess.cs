﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ModelDataAccess
    {

        public static bool GetModelInfoByID(int? ModelID, ref int MakeID, ref string ModelName)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from Models where ModelID = @ModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", (object)ModelID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                MakeID = (int)reader["MakeID"];
                                ModelName = (string)reader["ModelName"];
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

        public static bool GetModelInfoByName(string ModelName, ref int? ModelID, ref int MakeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Models WHERE ModelName = @ModelName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelName", ModelName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                ModelID = (reader["ModelID"] != DBNull.Value) ? (int?)reader["ModelID"] : null;
                                MakeID = (int)reader["MakeID"];
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

        public static int? AddNewModel(int MakeID, string ModelName)
        {
            // This function will return the new person id if succeeded and null if not
            int? ModelID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"insert into Models (MakeID, ModelName)
values (@MakeID, @ModelName)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", MakeID);
                        command.Parameters.AddWithValue("@ModelName", ModelName);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            ModelID = InsertID;
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
            return ModelID;
        }

        public static bool UpdateModel(int? ModelID, int MakeID, string ModelName)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"Update Models
set MakeID = @MakeID,
ModelName = @ModelName
where ModelID = @ModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", (object)ModelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MakeID", MakeID);
                        command.Parameters.AddWithValue("@ModelName", ModelName);

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

        public static bool DeleteModel(int? ModelID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"delete Models where ModelID = @ModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", (object)ModelID ?? DBNull.Value);

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

        public static bool DoesModelExist(int? ModelID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select found = 1 from Models where ModelID = @ModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", (object)ModelID ?? DBNull.Value);

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

        public static DataTable GetAllModels()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from MakeModels";

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

        public static DataTable GetAllModelsName()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT ModelName FROM MakeModels ORDER BY ModelName";

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
