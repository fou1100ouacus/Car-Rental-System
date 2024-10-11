using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MakeDataAccess
    {
        public static bool GetMakeInfoByid(int ? MakeID, ref string Make)
        {
            bool IsExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();
                    string query = "select * from Makes where MakeID=@MakeID";
                    using(SqlCommand command = new SqlCommand (query,connection))
                    {
                        command.Parameters.AddWithValue("@MakeID",MakeID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsExist = true;
                                Make = (string)reader["Make"];
                            }
                        }

                    }

                }
            }
            catch (SqlException ex)
            {
                IsExist = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsExist = false;

                clsLogError.LogError("General Exception", ex);
            }


            return IsExist;

        }

        public static bool GetMakeInfoByName(string Make, ref int? MakeID)
        {
            bool IsExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from Makes where Make =@Make";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Make", Make);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsExist = true;
                                MakeID = (reader["MakeID"] != DBNull.Value) ? (int?)reader["MakeID"] : null;
                            }
                    
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsExist = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsExist = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsExist;
        }

        public static int ? addNewMake(string Make)
        {
           int ? MakeID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();
                    string query = @"insert into Makes (Make)values (@Make) select scope_identity()";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Make", Make);

                        object newID = command.ExecuteScalar();
                        if(newID != null&&int.TryParse(newID.ToString(),out int insertedid ))
                        {
                            MakeID = insertedid;

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


                clsLogError.LogError("General  Exception", ex);
            }


            return MakeID;


        }

        public static bool UpdateMake(int? MakeID, string Make)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"Update Makes
set Make = @Make
where MakeID = @MakeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", (object)MakeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Make", Make);

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

        public static bool DeleteMake(int? MakeID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"delete Makes where MakeID = @MakeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", (object)MakeID ?? DBNull.Value);

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

        public static bool DoesMakeExist(int? MakeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select found = 1 from Makes where MakeID = @MakeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", (object)MakeID ?? DBNull.Value);

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

        public static DataTable GetAllMakes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"select * from Makes";

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

        public static DataTable GetAllMakesName()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSetting.Connection))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT Make FROM Makes ORDER BY Make";

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
