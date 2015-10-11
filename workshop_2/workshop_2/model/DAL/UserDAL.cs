using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using workshop_2.model;
using System.Configuration;

namespace workshop_2.model.DAL
{
    class UserDAL
    {
        private static readonly string _connectionString;

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        static UserDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BoatClubConnection"].ConnectionString;
        }

        public List<User> GetUsers(int UserID = 0)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    List<User> rtnUsers = new List<User>(100);

                    SqlCommand sqlCmd = new SqlCommand("applicationSchema.usp_GetMembers", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Value = UserID;

                    conn.Open();

                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        var usrUserID = reader.GetOrdinal("MemberID");
                        var usrName = reader.GetOrdinal("Name");
                        var usrPersonalKey = reader.GetOrdinal("Personalnumber");

                        while (reader.Read())
                        {
                            rtnUsers.Add(new User
                            {
                                MemberID = reader.GetInt32(usrUserID),
                                Name = reader.GetString(usrName),
                                PersonalNumber = reader.GetInt32(usrPersonalKey),
                            });
                        }
                    }
                    rtnUsers.TrimExcess();
                    return rtnUsers;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error when the datas was retrived");
            }
        }

        public List<Boat> GetBoats(int BoatID = 0)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    List<Boat> rtnBoat = new List<Boat>(100);

                    SqlCommand sqlCmd = new SqlCommand("applicationSchema.usp_GetBoats", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@BoatID", SqlDbType.Int, 4).Value = BoatID;

                    conn.Open();

                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        var BoatBoatID = reader.GetOrdinal("BoatID");
                        var BoatPersonalKey = reader.GetOrdinal("Personalnumber");
                        var BoatType = reader.GetOrdinal("BoatType");
                        var BoatLenght = reader.GetOrdinal("BoatLenght");

                        while (reader.Read())
                        {
                            rtnBoat.Add(new Boat
                            {
                                BoatID = reader.GetInt32(BoatBoatID),
                                Personalnumber = reader.GetInt32(BoatPersonalKey),
                                BoatType = reader.GetString(BoatType),
                                BoatLenght = reader.GetInt32(BoatLenght)
                            });
                        }
                    }
                    rtnBoat.TrimExcess();
                    return rtnBoat;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error when the datas was retrived");
            }
        }
        public List<Boat> GetMembersBoats(int PersonalNumber = 0)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    List<Boat> rtnBoat = new List<Boat>(100);

                    SqlCommand sqlCmd = new SqlCommand("applicationSchema.usp_GetMembersBoats", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@Personalnumber", SqlDbType.Int, 4).Value = PersonalNumber;

                    conn.Open();

                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        var BoatBoatID = reader.GetOrdinal("BoatID");
                        var BoatPersonalKey = reader.GetOrdinal("Personalnumber");
                        var BoatType = reader.GetOrdinal("BoatType");
                        var BoatLenght = reader.GetOrdinal("BoatLenght");

                        while (reader.Read())
                        {
                            rtnBoat.Add(new Boat
                            {
                                BoatID = reader.GetInt32(BoatBoatID),
                                Personalnumber = reader.GetInt32(BoatPersonalKey),
                                BoatType = reader.GetString(BoatType),
                                BoatLenght = reader.GetInt32(BoatLenght)
                            });
                        }
                        rtnBoat.TrimExcess();
                        return rtnBoat;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error when the datas was retrived");
            }
        }

        public void AddMember(User user)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand sqlCmd = new SqlCommand("applicationSchema.usp_AddMember", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = user.Name;
                    sqlCmd.Parameters.Add("@Personalnumber", SqlDbType.Int, 4).Value = user.PersonalNumber;

                    conn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Error when the data was going to be saved");
            }
        }

        public void AddBoat(Boat newBoat)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand sqlCmd = new SqlCommand("applicationSchema.usp_AddBoat", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@Personalnumber", SqlDbType.Int, 4).Value = newBoat.Personalnumber;
                    sqlCmd.Parameters.Add("@BoatType", SqlDbType.VarChar, 50).Value = newBoat.BoatType;
                    sqlCmd.Parameters.Add("@BoatLenght", SqlDbType.Float, 4).Value = newBoat.BoatLenght;

                    conn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Error when the data was going to be saved");
            }
        }

        public void UpdateMember(User user, int userPersonalNumber)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand sqlCmd = new SqlCommand("applicationSchema.usp_UpdateMember", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@Personalnumberold", SqlDbType.Int, 4).Value = userPersonalNumber;
                    sqlCmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = user.Name;
                    sqlCmd.Parameters.Add("@Personalnumber", SqlDbType.Int, 4).Value = user.PersonalNumber;

                    conn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Error when the data was going to be saved");
            }
        }

        public void UpdateBoat(Boat boat)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand sqlCmd = new SqlCommand("applicationSchema.usp_UpdateBoat", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@BoatID", SqlDbType.Int, 4).Value = boat.BoatID;
                    sqlCmd.Parameters.Add("@Personalnumber", SqlDbType.VarChar, 50).Value = boat.Personalnumber;
                    sqlCmd.Parameters.Add("@BoatType", SqlDbType.VarChar, 50).Value = boat.BoatType;
                    sqlCmd.Parameters.Add("@BoatLenght", SqlDbType.VarChar, 50).Value = boat.BoatLenght;

                    conn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Error when the data was going to be saved");
            }
        }



        public void DeleteMember(int p)
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var sqlCmd = new SqlCommand("applicationSchema.usp_DeleteMember", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@Personalnumber", SqlDbType.Int, 4).Value = p;

                    conn.Open();

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error when deleting member");
            }
        }

        public void DeleteBoat(int boatID)
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var sqlCmd = new SqlCommand("applicationSchema.usp_DeleteBoat", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@BoatID", SqlDbType.Int, 4).Value = boatID;

                    conn.Open();

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error when deleting boat");
            }
        }
    }
}
