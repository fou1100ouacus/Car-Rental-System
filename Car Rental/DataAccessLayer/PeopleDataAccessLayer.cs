using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class PeopleDataAccessLayer
    {

       
            public static bool GetPersonInfoByID(int? PersonID, ref string Name, ref string Address,
                ref string Phone, ref string Email, ref DateTime DateOfBirth, ref byte Gender,
                ref int? NationalityCountryID, ref DateTime CreatedAt, ref DateTime? UpdatedAt)
            {
                bool IsFound = false;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select * from People where PersonID = @PersonID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // The record was found
                                    IsFound = true;

                                    Name = (string)reader["Name"];
                                    Address = (string)reader["Address"];
                                    Phone = (string)reader["Phone"];
                                    Email = (string)reader["Email"];
                                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                                    Gender = (byte)reader["Gender"];
                                    NationalityCountryID = (reader["NationalityCountryID"] != DBNull.Value) ? (int?)reader["NationalityCountryID"] : null;
                                    CreatedAt = (DateTime)reader["CreatedAt"];
                                    UpdatedAt = (reader["UpdatedAt"] != DBNull.Value) ? (DateTime?)reader["UpdatedAt"] : null;
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

            public static int? AddNewPerson(string Name, string Address, string Phone, string Email,
                DateTime DateOfBirth, byte Gender, int? NationalityCountryID)

            {
                // This function will return the new person id if succeeded and null if not
                int? PersonID = null;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"insert into People (Name, Address, Phone, Email, DateOfBirth, Gender, NationalityCountryID, CreatedAt, UpdatedAt)
values (@Name, @Address, @Phone, @Email, @DateOfBirth, @Gender, @NationalityCountryID, @CreatedAt, @UpdatedAt)
select scope_identity()";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Name", Name);
                            command.Parameters.AddWithValue("@Address", Address);
                            command.Parameters.AddWithValue("@Phone", Phone);
                            command.Parameters.AddWithValue("@Email", Email);
                            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                            command.Parameters.AddWithValue("@Gender", Gender);
                            command.Parameters.AddWithValue("@NationalityCountryID", (object)NationalityCountryID ?? DBNull.Value);
                            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                            command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);


                            object result = command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int InsertID))
                            {
                                PersonID = InsertID;
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

            public static bool UpdatePerson(int? PersonID, string Name, string Address, string Phone,
                string Email, DateTime DateOfBirth, byte Gender, int? NationalityCountryID,
                DateTime CreatedAt)
            {
                int RowAffected = 0;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"Update People
set Name = @Name,
Address = @Address,
Phone = @Phone,
Email = @Email,
DateOfBirth = @DateOfBirth,
Gender = @Gender,
NationalityCountryID = @NationalityCountryID,
CreatedAt = @CreatedAt,
UpdatedAt = @UpdatedAt
where PersonID = @PersonID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Name", Name);
                            command.Parameters.AddWithValue("@Address", Address);
                            command.Parameters.AddWithValue("@Phone", Phone);
                            command.Parameters.AddWithValue("@Email", Email);
                            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                            command.Parameters.AddWithValue("@Gender", Gender);
                            command.Parameters.AddWithValue("@NationalityCountryID", (object)NationalityCountryID ?? DBNull.Value);
                            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
                            command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);


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

            public static bool DeletePerson(int? PersonID)
            {
                int RowAffected = 0;

                try
                {
                        using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                        {
                        connection.Open();

                        string query = @"delete People where PersonID = @PersonID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

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

            public static bool DoesPersonExist(int? PersonID)
            {
                bool IsFound = false;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select found = 1 from People where PersonID = @PersonID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

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

            public static DataTable GetAllPeople()
            {
                DataTable dt = new DataTable();

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                    {
                        connection.Open();

                        string query = @"select * from People";

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












        //    public static bool Find_person_By_ID(int? personid, ref string NationalNo, ref string FirstName, ref string SecondName,
        //      ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref  byte Gender, ref string Address, ref string Phone, ref string Email,
        //     ref int NationalityCountryID, ref string ImagePath, ref DateTime createdAt, ref DateTime updatedAt)

        //    {

        //        bool result = false;
        //        using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
        //        {

        //            string query = "Select * from People where PersonID=@personid";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@PersonID", personid);
        //            try
        //            {
        //                connection.Open();
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.Read())
        //                {
        //                    result = true;
        //                    NationalNo = (string)(reader["NationalNo"]);
        //                    FirstName = (string)reader["FirstName"];
        //                    SecondName = (string)reader["SecondName"];
        //                    ThirdName = (string)reader["ThirdName"];
        //                    LastName = (string)reader["LastName"];
        //                    DateOfBirth = (DateTime)reader["DateOfBirth"];
        //                    Gender = (byte)(reader["Gender"]);
        //                    Address = (string)reader["Address"];
        //                    Phone = (string)reader["Phone"];
        //                    Email = (string)reader["Email"];
        //                    ImagePath = (string)reader["ImagePath"];
        //                    Gender = (byte)reader["Gender"];
        //                    NationalityCountryID = (int)((reader["NationalityCountryID"] != DBNull.Value) ? (int?)reader["NationalityCountryID"] : null);
        //                    createdAt = (DateTime)reader["CreatedAt"];
        //                    updatedAt = (DateTime)((reader["UpdatedAt"] != DBNull.Value) ? (DateTime?)reader["UpdatedAt"] : null);
        //                }
        //                reader.Close();

        //            }
        //            catch (Exception)
        //            {

        //                result = false;
        //            }


        //        }
        //        return result;






        //    }



        //    public static bool Find_person_By_Email(ref int personid, ref string NationalNo, ref string FirstName, ref string SecondName,
        //       ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, string Email,
        //   ref int NationalityCountryID, ref string ImagePath, ref DateTime createdAt, ref DateTime updatedAt)
        //    {
        //        bool result = false;
        //        using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
        //        {

        //            string query = "Select * from People where Email=@Email";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@Email", Email);
        //            try
        //            {
        //                connection.Open();
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.Read())
        //                {
        //                    result = true;
        //                    NationalNo = (string)(reader["NationalNo"]);
        //                    FirstName = (string)reader["FirstName"];
        //                    SecondName = (string)reader["SecondName"];
        //                    ThirdName = (string)reader["ThirdName"];
        //                    LastName = (string)reader["LastName"];
        //                    DateOfBirth = (DateTime)reader["DateOfBirth"];
        //                    Gender = Convert.ToByte(reader["Gender"]);

        //                    Address = (string)reader["Address"];
        //                    Phone = (string)reader["Phone"];

        //                    personid = (int)reader["PersonID"];
        //                    NationalityCountryID = (int)((reader["NationalityCountryID"] != DBNull.Value) ? (int?)reader["NationalityCountryID"] : null);
        //                    createdAt = (DateTime)reader["CreatedAt"];
        //                    updatedAt = (DateTime)((reader["UpdatedAt"] != DBNull.Value) ? (DateTime?)reader["UpdatedAt"] : null); ImagePath = (string)reader["ImagePath"];

        //                }
        //                reader.Close();

        //            }
        //            catch (Exception)
        //            {

        //                result = false;
        //            }


        //        }
        //        return result;
        //    }





        //    public static int Addnewperson(string NationalNo, string FirstName, string SecondName,
        //        string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
        //    int NationalityCountryID, string ImagePath, DateTime createdAt, DateTime updatedAt)
        //    {
        //        //using for  ==>Resource Management
        //        int PersonID = -1;


        //        try
        //        {
        //            using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
        //            {
        //                connection.Open();

        //                string query = "INSERT INTO [dbo].[People]\r\n  " +


        //                   " ([NationalNo] ,[FirstName]\r\n  ,[SecondName]\r\n  ,[ThirdName]\r\n   ,[LastName]\r\n  ,[DateOfBirth],[Gender]\r\n,[Address] ,[Phone],[Email],[NationalityCountryID],[ImagePath],CreatedAt,UpdatedAt)\r\n " +

        //                      "VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, " +
        //                      "@Address, @Phone, @Email, @NationalityCountryID, @ImagePath ,@CreatedAt,@UpdatedAt)" +
        //                                      "select top 1 SCOPE_IDENTITY() from People";
        //                using (SqlCommand command = new SqlCommand(query, connection))
        //                {


        //                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
        //                    command.Parameters.AddWithValue("@FirstName", FirstName);
        //                    command.Parameters.AddWithValue("@SecondName", SecondName);
        //                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
        //                    command.Parameters.AddWithValue("@LastName", LastName);
        //                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
        //                    command.Parameters.AddWithValue("@Gender", Gender);
        //                    command.Parameters.AddWithValue("@Address", Address);
        //                    command.Parameters.AddWithValue("@Phone", Phone);
        //                    command.Parameters.AddWithValue("@Email", Email);
        //                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
        //                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
        //                    command.Parameters.AddWithValue("@CreatedAt", createdAt);
        //                    command.Parameters.AddWithValue("@UpdatedAt", updatedAt);

        //                    object result = command.ExecuteScalar();

        //                    if (result != null && int.TryParse(result.ToString(), out int InsertID))
        //                    {
        //                        PersonID = InsertID;
        //                    }
        //                }

        //            }
        //        }


        //        catch (SqlException ex)
        //        {
        //            clsLogError.LogError("Database Exception", ex);
        //        }
        //        catch (Exception ex)
        //        {
        //            clsLogError.LogError("General Exception", ex);
        //        }

        //        return PersonID;


        //    } 



        //    public static bool Updateperson(int? personid, string NationalNo, string FirstName, string SecondName,
        //    string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
        //    int NationalityCountryID, string ImagePath,  DateTime createdAt,  DateTime updatedAt)
        //    {
        //        //using for  ==>Resource Management
        //        using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
        //        {


        //            string query = "\r\nUPDATE [dbo].[People]\r\n  " +
        //                " SET [NationalNo] =@NationalNo," +
        //                "     [FirstName]  =@FirstName ," +
        //                "     [SecondName]=@SecondName," +
        //                "     [ThirdName]=@ThirdName ," +
        //                "     [LastName]=@LastName  ," +
        //                "     [DateOfBirth]=@DateOfBirth," +
        //                "     [Gender] =@Gender \r\n " +
        //                "     ,[Address]=@Address   ," +
        //                "      [Phone]=@Phone  ," +
        //                "     [Email]=@Email ," +
        //                "     [NationalityCountryID] =@NationalityCountryID  ," +
        //                "     [ImagePath]=@ImagePath," +
        //                "CreatedAt=@CreatedAt,"+
        //                "UpdatedAt=@UpdatedAt" +
        //                "    WHERE PersonID=@personid";

        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("PersonID", personid);
        //            command.Parameters.AddWithValue("@NationalNo", NationalNo);
        //            command.Parameters.AddWithValue("@FirstName", FirstName);
        //            command.Parameters.AddWithValue("@SecondName", SecondName);
        //            command.Parameters.AddWithValue("@ThirdName", ThirdName);
        //            command.Parameters.AddWithValue("@LastName", LastName);
        //            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
        //            command.Parameters.AddWithValue("@Gender", Gender);
        //            command.Parameters.AddWithValue("@Address", Address);
        //            command.Parameters.AddWithValue("@Phone", Phone);
        //            command.Parameters.AddWithValue("@Email", Email);
        //            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
        //            command.Parameters.AddWithValue("@CreatedAt", createdAt);
        //            command.Parameters.AddWithValue("@UpdatedAt", updatedAt);

        //            command.Parameters.AddWithValue("@ImagePath", ImagePath);
        //            try
        //            {
        //                connection.Open();
        //                int rowAffected = command.ExecuteNonQuery();
        //                if (rowAffected > 0)
        //                {

        //                    return true;
        //                }


        //            }
        //            catch (Exception ex)
        //            {
        //                return false;

        //            }



        //        }



        //        return false;
        //    }

        //    //public static bool Find_person_By_FirstName(ref int personid, ref string NationalNo, string FirstName, ref string SecondName,
        //    //ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gender, ref string Address, ref string Phone, ref string Email,
        //    //ref int NationalityCountryID, ref string ImagePath, ref DateTime createdAt, ref DateTime updatedAt)
        //    //{
        //    //    bool result = false;
        //    //    using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
        //    //    {

        //    //        string query = "Select * from People where FirstName=@FirstName";
        //    //        SqlCommand command = new SqlCommand(query, connection);
        //    //        command.Parameters.AddWithValue("@FirstName", FirstName);
        //    //        try
        //    //        {
        //    //            connection.Open();
        //    //            SqlDataReader reader = command.ExecuteReader();
        //    //            if (reader.Read())
        //    //            {
        //    //                result = true;
        //    //                NationalNo = (string)(reader["NationalNo"]);
        //    //                FirstName = (string)reader["FirstName"];
        //    //                SecondName = (string)reader["SecondName"];
        //    //                ThirdName = (string)reader["ThirdName"];
        //    //                LastName = (string)reader["LastName"];
        //    //                DateOfBirth = (DateTime)reader["DateOfBirth"];
        //    //                Gender = Convert.ToInt16(reader["Gendor"]);
        //    //                personid = (int)reader["PersonID"];
        //    //                Address = (string)reader["Address"];
        //    //                Phone = (string)reader["Phone"];
        //    //                Email = (string)reader["Email"];
        //    //                personid = (int)reader["PersonID"];
        //    //                NationalityCountryID = (int)reader["NationalityCountryID"];
        //    //                ImagePath = (string)reader["ImagePath"];

        //    //            }
        //    //            reader.Close();

        //    //        }
        //    //        catch (Exception)
        //    //        {

        //    //            result = false;
        //    //        }


        //    //    }
        //    //    return result;
        //    //}


        //    public static bool Find_person_By_NationalNo(ref int personid, string NationalNo, ref string FirstName, ref string SecondName,
        //    ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email,
        //    ref int NationalityCountryID, ref string ImagePath, ref DateTime createdAt, ref DateTime updatedAt)
        //    {
        //        bool result = false;
        //        using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
        //        {

        //            string query = "Select * from People where NationalNo=@NationalNo";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@NationalNo", NationalNo);
        //            try
        //            {
        //                connection.Open();
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.Read())
        //                {
        //                    result = true;
        //                    // NationalNo = (string)(reader["NationalNo"]);
        //                    FirstName = (string)reader["FirstName"];
        //                    SecondName = (string)reader["SecondName"];
        //                    ThirdName = (string)reader["ThirdName"];
        //                    LastName = (string)reader["LastName"];
        //                    DateOfBirth = (DateTime)reader["DateOfBirth"];
        //                    Gender = Convert.ToByte(reader["Gender"]);
        //                    personid = (int)reader["PersonID"];
        //                    Address = (string)reader["Address"];
        //                    Phone = (string)reader["Phone"];
        //                    Email = (string)reader["Email"];
        //                    personid = (int)reader["PersonID"];
        //                    NationalityCountryID = (int)reader["NationalityCountryID"];
        //                    ImagePath = (string)reader["ImagePath"];
        //                    createdAt = (DateTime)reader["CreatedAt"];
        //                    updatedAt = (DateTime)((reader["UpdatedAt"] != DBNull.Value) ? (DateTime?)reader["UpdatedAt"] : null); 


        //                }
        //                reader.Close();

        //            }
        //            catch (Exception)
        //            {

        //                result = false;
        //            }


        //        }
        //        return result;
        //    }

        //    public static bool Delete_Person(int ?personid)
        //    {
        //        //using for  ==>Resource Management
        //        using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
        //        {


        //            string query = " Delete from People WHERE PersonID=@personid";

        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@PersonID", personid);

        //            try
        //            {
        //                connection.Open();
        //                int rowAffected = command.ExecuteNonQuery();
        //                if (rowAffected > 0)
        //                {

        //                    return true;
        //                }


        //            }
        //            catch (Exception ex)
        //            {
        //                return false;

        //            }



        //        }



        //        return false;
        //    }



        //    public static DataTable GETlist()
        //    {
        //        DataTable table = new DataTable();

        //        SqlConnection connection = new SqlConnection(DataAccessSetting.Connection);
        //        string query = "SELECT * FROM People";

        //        SqlCommand command = new SqlCommand(query, connection);

        //        try
        //        {
        //            connection.Open();

        //            SqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                table.Load(reader);
        //            }

        //            reader.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        return table;

        //    }



        //}


    
