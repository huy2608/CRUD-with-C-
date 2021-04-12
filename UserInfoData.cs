using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace CRUDWebForm
{
    public class UserInfoData
    {
        string connectionString = "server=****;database=****; UID=sa;PWD=****";

        public UserInfoData() { }

        public void InsertUserInfo(UserInfo newInfo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string SQLInsert = "Insert Account values (@username,@password,@fullname,@phone,@role)";
            SqlCommand cmd = new SqlCommand(SQLInsert, conn);
            cmd.Parameters.AddWithValue("@username", newInfo.username);
            cmd.Parameters.AddWithValue("@password", newInfo.password);
            cmd.Parameters.AddWithValue("@fullname", newInfo.fullname);
            cmd.Parameters.AddWithValue("@phone", newInfo.phone);
            cmd.Parameters.AddWithValue("@role", newInfo.role);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                throw new Exception("Error Insert: " + ex.Message); 
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateUserInfo(UserInfo updateInfo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string SQLUpdate = "Update Account set [password]=@password, [fullname]=@fullname, [phone]=@phone, [role]=@role where [username]=@username";
            SqlCommand cmd = new SqlCommand(SQLUpdate, conn);
            cmd.Parameters.AddWithValue("@username", updateInfo.username);
            cmd.Parameters.AddWithValue("@password", updateInfo.password);
            cmd.Parameters.AddWithValue("@fullname", updateInfo.fullname);
            cmd.Parameters.AddWithValue("@phone", updateInfo.phone);
            cmd.Parameters.AddWithValue("@role", updateInfo.role);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteUserInfo(UserInfo deleteInfo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string SQLDelete = "Delete Account where [username]=@username";
            SqlCommand cmd = new SqlCommand(SQLDelete, conn);
            cmd.Parameters.AddWithValue("@username", deleteInfo.username);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<UserInfo> getUserList()
        {
            List<UserInfo> data = new List<UserInfo>();
            SqlConnection conn = new SqlConnection(connectionString);
            string SQL = "Select username,password,fullname,phone,role from Account";
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    dynamic info = new UserInfo()
                    {
                        username = rd["username"].ToString(),
                        password = rd["password"].ToString(),
                        fullname = rd["fullname"].ToString(),
                        phone = rd["phone"].ToString(),
                        role = rd["role"].ToString(),
                    };
                    data.Add(info);
                }
            }
            return data;
        }
    }
}