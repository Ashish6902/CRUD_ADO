using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
    }
}