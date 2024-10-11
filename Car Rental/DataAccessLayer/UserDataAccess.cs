using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDataAccess
    {
        public static bool GetUserInfoByID(int? UserID, ref int? PersonID, ref string Username,
            ref string Password, ref int Permissions, ref string SecurityQuestion,
            ref string SecurityAnswer, ref string ImagePath, ref bool IsActive)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from Users where UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                Permissions = (int)reader["Permissions"];
                                SecurityQuestion = (reader["SecurityQuestion"] != DBNull.Value) ? (string)reader["SecurityQuestion"] : null;
                                SecurityAnswer = (reader["SecurityAnswer"] != DBNull.Value) ? (string)reader["SecurityAnswer"] : null;
                                ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : null;
                                IsActive = (bool)reader["IsActive"];
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

        public static bool GetUserInfoByUsername(ref int? UserID, ref int? PersonID, string Username,
            ref string Password, ref int Permissions, ref string SecurityQuestion,
            ref string SecurityAnswer, ref string ImagePath, ref bool IsActive)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from Users where Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                UserID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                Password = (string)reader["Password"];
                                Permissions = (int)reader["Permissions"];
                                SecurityQuestion = (reader["SecurityQuestion"] != DBNull.Value) ? (string)reader["SecurityQuestion"] : null;
                                SecurityAnswer = (reader["SecurityAnswer"] != DBNull.Value) ? (string)reader["SecurityAnswer"] : null;
                                ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : null;
                                IsActive = (bool)reader["IsActive"];
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

        public static bool GetUserInfoByUsernameAndPassword(ref int? UserID, ref int? PersonID,
            string Username, string Password, ref int Permissions, ref string SecurityQuestion,
            ref string SecurityAnswer, ref string ImagePath, ref bool IsActive)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from Users where Username = @Username AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                UserID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                PersonID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                Permissions = (int)reader["Permissions"];
                                SecurityQuestion = (reader["SecurityQuestion"] != DBNull.Value) ? (string)reader["SecurityQuestion"] : null;
                                SecurityAnswer = (reader["SecurityAnswer"] != DBNull.Value) ? (string)reader["SecurityAnswer"] : null;
                                ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : null;
                                IsActive = (bool)reader["IsActive"];
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

        public static int? AddNewUser(int? PersonID, string Username, string Password,
            int Permissions, string SecurityQuestion, string SecurityAnswer, string ImagePath,
            bool IsActive)
        {
            // This function will return the new person id if succeeded and null if not
            int? UserID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"if not Exists (select found = 1 from Users where Username = @Username)
    begin
    insert into Users (PersonID, Username, Password, Permissions, SecurityQuestion, SecurityAnswer, ImagePath, IsActive)
    values (@PersonID, @Username, @Password, @Permissions, @SecurityQuestion, @SecurityAnswer, @ImagePath, @IsActive)
    select scope_identity()
    end";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@SecurityQuestion", (object)SecurityQuestion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SecurityAnswer", (object)SecurityAnswer ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            UserID = InsertID;
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

            return UserID;
        }

        public static bool UpdateUser(int? UserID, int? PersonID, string Username, string Password,
            int Permissions, string SecurityQuestion, string SecurityAnswer, string ImagePath,
            bool IsActive)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"Update Users
    set PersonID = @PersonID,
    Username = @Username,
    Password = @Password,
    Permissions = @Permissions,
    SecurityQuestion = @SecurityQuestion,
    SecurityAnswer = @SecurityAnswer,
    ImagePath = @ImagePath,
    IsActive = @IsActive
    where UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@SecurityQuestion", (object)SecurityQuestion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SecurityAnswer", (object)SecurityAnswer ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool DeleteUser(int? UserID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"delete Users where UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

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

        public static bool DoesUserExist(int? UserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select found = 1 from Users where UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
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

            return IsFound;
        }

        public static bool DoesUserExist(string Username)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select found = 1 from Users where Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);

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

        public static bool DoesUserExist(string Username, string Password)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select found = 1 from Users where Username = @Username and Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);

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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from UsersDetails_View order by UserID desc";

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

        public static int GetUsersCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select count(*) from Users";

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

        public static int? GetPersonIDByUserID(int? UserID)
        {
            int? PersonID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select PersonID from Users where UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

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

        public static bool ChangePassword(int? UserID, string NewPassword)
        {
            int AffectedRows = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"update users 
                         set Password = @Password
                         where UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", NewPassword);
                        command.Parameters.AddWithValue("UserID", (object)UserID ?? DBNull.Value);

                        AffectedRows = command.ExecuteNonQuery();
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

            return (AffectedRows > 0);
        }
    }


     
        // public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName,
        //ref string Password, ref bool IsActive)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = "SELECT * FROM Users WHERE UserID = @UserID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@UserID", UserID);

        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         if (reader.Read())
        //         {
        //             // The record was found
        //             isFound = true;

        //             PersonID = (int)reader["PersonID"];
        //             UserName = (string)reader["UserName"];
        //             Password = (string)reader["Password"];
        //             IsActive = (bool)reader["IsActive"];


        //         }
        //         else
        //         {
        //             // The record was not found
        //             isFound = false;
        //         }

        //         reader.Close();


        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);

        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }


        // public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName,
        //   ref string Password, ref bool IsActive)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@PersonID", PersonID);

        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         if (reader.Read())
        //         {
        //             // The record was found
        //             isFound = true;

        //             UserID = (int)reader["UserID"];
        //             UserName = (string)reader["UserName"];
        //             Password = (string)reader["Password"];
        //             IsActive = (bool)reader["IsActive"];


        //         }
        //         else
        //         {
        //             // The record was not found
        //             isFound = false;
        //         }

        //         reader.Close();

        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);

        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }

        // public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
        //     ref int UserID, ref int PersonID, ref bool IsActive)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@Username", UserName);
        //     command.Parameters.AddWithValue("@Password", Password);


        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         if (reader.Read())
        //         {
        //             // The record was found
        //             isFound = true;
        //             UserID = (int)reader["UserID"];
        //             PersonID = (int)reader["PersonID"];
        //             UserName = (string)reader["UserName"];
        //             Password = (string)reader["Password"];
        //             IsActive = (bool)reader["IsActive"];


        //         }
        //         else
        //         {
        //             // The record was not found
        //             isFound = false;
        //         }

        //         reader.Close();


        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);

        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }

        // public static int AddNewUser(int PersonID, string UserName,
        //      string Password, bool IsActive)
        // {
        //     //this function will return the new person id if succeeded and -1 if not.
        //     int UserID = -1;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = @"INSERT INTO Users (PersonID,UserName,Password,IsActive)
        //                      VALUES (@PersonID, @UserName,@Password,@IsActive);
        //                      SELECT SCOPE_IDENTITY();";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@PersonID", PersonID);
        //     command.Parameters.AddWithValue("@UserName", UserName);
        //     command.Parameters.AddWithValue("@Password", Password);
        //     command.Parameters.AddWithValue("@IsActive", IsActive);

        //     try
        //     {
        //         connection.Open();

        //         object result = command.ExecuteScalar();

        //         if (result != null && int.TryParse(result.ToString(), out int insertedID))
        //         {
        //             UserID = insertedID;
        //         }
        //     }

        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);

        //     }

        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return UserID;
        // }


        // public static bool UpdateUser(int UserID, int PersonID, string UserName,
        //      string Password, bool IsActive)
        // {

        //     int rowsAffected = 0;
        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = @"Update  Users  
        //                     set PersonID = @PersonID,
        //                         UserName = @UserName,
        //                         Password = @Password,
        //                         IsActive = @IsActive
        //                         where UserID = @UserID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@PersonID", PersonID);
        //     command.Parameters.AddWithValue("@UserName", UserName);
        //     command.Parameters.AddWithValue("@Password", Password);
        //     command.Parameters.AddWithValue("@IsActive", IsActive);
        //     command.Parameters.AddWithValue("@UserID", UserID);


        //     try
        //     {
        //         connection.Open();
        //         rowsAffected = command.ExecuteNonQuery();

        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         return false;
        //     }

        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return (rowsAffected > 0);
        // }


        // public static DataTable GetAllUsers()
        // {

        //     DataTable dt = new DataTable();
        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = @"SELECT  Users.UserID, Users.PersonID,
        //                     FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
        //                      Users.UserName, Users.IsActive
        //                      FROM  Users INNER JOIN
        //                             People ON Users.PersonID = People.PersonID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     try
        //     {
        //         connection.Open();

        //         SqlDataReader reader = command.ExecuteReader();

        //         if (reader.HasRows)

        //         {
        //             dt.Load(reader);
        //         }

        //         reader.Close();


        //     }

        //     catch (Exception ex)
        //     {
        //         // Console.WriteLine("Error: " + ex.Message);
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return dt;

        // }

        // public static bool DeleteUser(int UserID)
        // {

        //     int rowsAffected = 0;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = @"Delete Users 
        //                         where UserID = @UserID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@UserID", UserID);

        //     try
        //     {
        //         connection.Open();

        //         rowsAffected = command.ExecuteNonQuery();

        //     }
        //     catch (Exception ex)
        //     {
        //         // Console.WriteLine("Error: " + ex.Message);
        //     }
        //     finally
        //     {

        //         connection.Close();

        //     }

        //     return (rowsAffected > 0);

        // }

        // public static bool IsUserExist(int UserID)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@UserID", UserID);

        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         isFound = reader.HasRows;

        //         reader.Close();
        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }

        // public static bool IsUserExist(string UserName)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@UserName", UserName);

        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         isFound = reader.HasRows;

        //         reader.Close();
        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }

        // public static bool IsUserExistForPersonID(int PersonID)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@PersonID", PersonID);

        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         isFound = reader.HasRows;

        //         reader.Close();
        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }

        // public static bool DoesPersonHaveUser44(int PersonID)
        // {
        //     bool isFound = false;

        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@PersonID", PersonID);

        //     try
        //     {
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();

        //         isFound = reader.HasRows;

        //         reader.Close();
        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         isFound = false;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return isFound;
        // }

        // public static bool ChangePassword(int UserID, string NewPassword)
        // {

        //     int rowsAffected = 0;
        //     SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);

        //     string query = @"Update  Users  
        //                     set Password = @Password
        //                     where UserID = @UserID";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@UserID", UserID);

        //     try
        //     {
        //         connection.Open();
        //         rowsAffected = command.ExecuteNonQuery();

        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         return false;
        //     }

        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return (rowsAffected > 0);
        // }





    
}
