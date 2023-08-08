using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace CRUD_ADO.Models
{
    public class DBcontext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Student> GetData()
        {
            List<Student> students_data = new List<Student>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("GetData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Student stu = new Student();
                stu.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                stu.FirstName = dr.GetValue(1).ToString();
                stu.LastName = dr.GetValue(2).ToString();
                stu.Stream = dr.GetValue(3).ToString();
                stu.Marks = Convert.ToInt32(dr.GetValue(4).ToString());
                students_data.Add(stu);
            }
            conn.Close();
            return students_data;
        }
        public bool createData(Student stu)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("InsertData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fname", stu.FirstName);
            cmd.Parameters.AddWithValue("@Lname", stu.LastName);
            cmd.Parameters.AddWithValue("@stream", stu.Stream);
            cmd.Parameters.AddWithValue("@marks", stu.Marks);
            conn.Open();
            int i =cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
        public bool UpdateData(Student stu)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("updateData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", stu.ID);
            cmd.Parameters.AddWithValue("@Fname", stu.FirstName);
            cmd.Parameters.AddWithValue("@Lname", stu.LastName);
            cmd.Parameters.AddWithValue("@stream", stu.Stream);
            cmd.Parameters.AddWithValue("@marks", stu.Marks);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeletData(Student stu)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("DeletData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stid", stu.ID);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Student> SearchData(int id)
        {
            List<Student> students_data = new List<Student>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SearchData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Student stu = new Student();
                stu.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                stu.FirstName = dr.GetValue(1).ToString();
                stu.LastName = dr.GetValue(2).ToString();
                stu.Stream = dr.GetValue(3).ToString();
                stu.Marks = Convert.ToInt32(dr.GetValue(4).ToString());
                students_data.Add(stu);
            }
            conn.Close();
            return students_data;
        }
    }
}