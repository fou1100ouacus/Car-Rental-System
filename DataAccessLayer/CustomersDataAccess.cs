﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomersDataAccess
    {
       
            public static bool GetCustomerInfoByID(int? CustomerID, ref int? PersonID,
                ref string DriverLicenseNumber)
            {
                bool IsFound = false;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select * from Customerrs where CustomerID = @CustomerID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // The record was found
                                    IsFound = true;

                                    PersonID = (int)reader["PersonID"];
                                    DriverLicenseNumber = (string)reader["DriverLicenseNumber"];
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

            public static int? AddNewCustomer(int? PersonID, string DriverLicenseNumber)
            {
                // This function will return the new person id if succeeded and null if not
                int? CustomerID = null;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"insert into Customerrs (PersonID, DriverLicenseNumber)
values (@PersonID, @DriverLicenseNumber)
select scope_identity()";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);
                            command.Parameters.AddWithValue("@DriverLicenseNumber", DriverLicenseNumber);

                            object result = command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int InsertID))
                            {
                                CustomerID = InsertID;
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

                return CustomerID;
            }

            public static bool UpdateCustomer(int? CustomerID, int? PersonID, string DriverLicenseNumber)
            {
                int RowAffected = 0;

                try
                {
                        using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                        {
                        connection.Open();

                        string query = @"Update Customerrs
set PersonID = @PersonID,
DriverLicenseNumber = @DriverLicenseNumber
where CustomerID = @CustomerID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                            command.Parameters.AddWithValue("@PersonID", PersonID);
                            command.Parameters.AddWithValue("@DriverLicenseNumber", DriverLicenseNumber);

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

            public static bool DeleteCustomer(int? CustomerID)
            {
                int RowAffected = 0;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"delete Customers where CustomerID = @CustomerID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);

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

            public static bool DoesCustomerExist(int? CustomerID)
            {
                bool IsFound = false;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select found = 1 from Customerrs where CustomerID = @CustomerID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);

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

            public static bool DoesDriverLicenseNumberExist(string DriverLicenseNumber)
            {
                bool IsFound = false;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select found = 1 from Customerrs where DriverLicenseNumber = @DriverLicenseNumber";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DriverLicenseNumber", DriverLicenseNumber);

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

            public static DataTable GetAllCustomers()
            {
                DataTable dt = new DataTable();

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select * from CustomersDetails_View order by CreatedAt desc";

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

            public static int GetCustomersCount()
            {
                int Count = 0;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select count(*) from Customerrs";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            object result = command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int Value))
                            {
                                Count = Value;
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

                return Count;
            }

            public static int? GetPersonIDByCustomerID(int? CustomerID)
            {
                int? PersonID = null;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select PersonID from Customerrs where CustomerID = @CustomerID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);

                            object result = command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int ID))
                            {
                                PersonID = ID;
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

                return PersonID;
            }
        }


    }










