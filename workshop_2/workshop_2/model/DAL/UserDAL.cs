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

        public void GetUsers(int UserID = 0)
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
                        var usrPersonalKey = reader.GetOrdinal("PersonalNumber");

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
                }
            }
            catch (Exception)
            {
                throw new Exception("Fel när datan skulle hämtas");
            }
        }
    }
}
