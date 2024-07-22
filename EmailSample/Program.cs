using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data.SqlClient;
namespace EmailSample
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Student s = new Student();
            List<Student> stu = new List<Student>();
            stu.Add(new Student { Name = "Jaffersha", RollNo = 101, Mailid = "jaffersha786@gmail.com",Message="Hello" });
            stu.Add(new Student { Name = "Harish", RollNo = 102, Mailid = "harish12ser@gmail.com" ,Message="Hello"});
            stu.Add(new Student { Name = "Rexalan", RollNo = 103, Mailid = "rexalan1174@gmail.com", Message = "Hello" });
            stu.Add(new Student { Name = "Nilofar Nisha", RollNo = 104, Mailid = "nilofarnisha464@gmail.com", Message = "Hello" });

            foreach (Student S in stu)
            {

                try
                {
                    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Cs))
                    {
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        bool Demo = CheckedCondition(S.RollNo);
                        if (Demo == false)
                        {

                            bool demo1 = s.Mail(S.Mailid, S.Message, S.Name, S.RollNo);
                            if (demo1 == true)
                            {
                                cmd.CommandText = "insert into Sample values('" + S.RollNo + "','" + 1 + "')";
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = "insert into Sample values('" + S.RollNo + "','" + 0 + "')";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            cmd.CommandText = "select Checked from Sample where RollNo='" + S.RollNo + "'";
                            int str = Convert.ToInt32(cmd.ExecuteScalar());
                            if (str == 0)
                            {

                                bool demo1 = s.Mail(S.Mailid, S.Message, S.Name, S.RollNo);
                                if (demo1 == true)
                                {
                                    cmd.CommandText = "update Sample set Checked='" + 1 + "' where RollNo='" + S.RollNo + "'";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                
            }
        }

        public static bool CheckedCondition(int RN)
        {
            
                    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.Cs))
                    {
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "select count(*) from Sample where RollNo='" + RN + "'";
                        int str = Convert.ToInt32(cmd.ExecuteScalar());
                        if (str == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                     }
              
        }

     }
}
           
           
       
    


