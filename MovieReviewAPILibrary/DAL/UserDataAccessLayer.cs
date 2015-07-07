using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewAPILibrary.DAL
{
    public class UserDataAccessLayer
    {
        public bool Create(string username,string pwd,string email)
        {
            bool retVal = false;
            SqlCommand sqlCmd = new SqlCommand("CreateUser");
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Username", username);
            sqlCmd.Parameters.AddWithValue("@Pwd", pwd);
            sqlCmd.Parameters.AddWithValue("@Email", email);
            int result = new DatabaseAccess.DatabaseLayer().ExecuteNonQuery(sqlCmd);
            if (result != Int32.MaxValue)
                retVal = true;

            return retVal;
        }

        public bool Create(string username, string pwd, string email,int roleId)
        {
            bool retVal = false;
            SqlCommand sqlCmd = new SqlCommand("CreateUser");
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Username", username);
            sqlCmd.Parameters.AddWithValue("@Pwd", pwd);
            sqlCmd.Parameters.AddWithValue("@Email", email);
            sqlCmd.Parameters.AddWithValue("@RoleId", roleId);
            int result = new DatabaseAccess.DatabaseLayer().ExecuteNonQuery(sqlCmd);
            if (result != Int32.MaxValue)
                retVal = true;

            return retVal;
        }

        public User GetUserInfo(string username, string pwd)
        {
            User user = null;
            using (DatabaseAccess.DatabaseLayer dbLayer = new DatabaseAccess.DatabaseLayer())
            {
                SqlCommand sqlCmd = new SqlCommand("GetUserInfo");
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Username", username);
                sqlCmd.Parameters.AddWithValue("@Pwd", pwd);
                user = dbLayer.GetEntityList<User>(sqlCmd).FirstOrDefault();
            }
            return user;
        }
    }
}
