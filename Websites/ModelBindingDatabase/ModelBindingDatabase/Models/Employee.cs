using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace ModelBindingDatabase.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        //public static List<Employee> GetAllEmployees()
        //{
        //    List<Employee> list = new List<Employee>();
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;";
        //    try
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select * from Employees";

        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            Employee emp = new Employee();

        //            emp.EmpNo = dr.GetInt32("EmpNo");
        //            emp.Name = dr.GetString("Name");
        //            emp.DeptNo = dr.GetInt32("DeptNo");
        //            emp.Basic = dr.GetDecimal("Basic");

        //            list.Add(emp);
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //    return list;
        //}

        //public static Employee GetSingleEmployee(int EmpNo)
        //{
        //    Employee emp = new Employee();

        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;";
        //    try
        //    {
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select * from Employees where EmpNo =@EmpNo";
        //        cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            emp.EmpNo = dr.GetInt32("EmpNo");
        //            emp.Name = dr.GetString("Name");
        //            emp.DeptNo = dr.GetInt32("DeptNo");
        //            emp.Basic = dr.GetDecimal("Basic");
        //        }
        //        else
        //            emp = null;
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //    return emp;
        //}

        //public static void Insert(Employee obj)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;";
        //    try
        //    {
        //        cn.Open();
        //        SqlCommand cmdInsert = new SqlCommand();
        //        cmdInsert.Connection = cn;
        //        cmdInsert.CommandType = CommandType.Text;
        //        cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

        //        cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
        //        cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
        //        cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
        //        cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

        //        cmdInsert.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //}
        //public static void Update(Employee obj)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;";
        //    try
        //    {
        //        cn.Open();
        //        SqlCommand cmdUpdate = new SqlCommand();
        //        cmdUpdate.Connection = cn;
        //        cmdUpdate.CommandType = CommandType.Text;
        //        cmdUpdate.CommandText = "update Employees set Name=@Name,Basic=@Basic,DeptNo=@DeptNo where EmpNo=@empNo";

        //        cmdUpdate.Parameters.AddWithValue("@Name", obj.Name);
        //        cmdUpdate.Parameters.AddWithValue("@Basic", obj.Basic);
        //        cmdUpdate.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
        //        cmdUpdate.Parameters.AddWithValue("@EmpNo", obj.EmpNo);

        //        cmdUpdate.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //}
        //public static void Delete(int EmpNo)
        //{
        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;";
        //    try
        //    {
        //        cn.Open();
        //        SqlCommand cmdDelete = new SqlCommand();
        //        cmdDelete.Connection = cn;
        //        cmdDelete.CommandType = CommandType.Text;
        //        cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

        //        cmdDelete.Parameters.AddWithValue("@EmpNo", EmpNo);

        //        cmdDelete.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //}


        /*With Stored procedure*/
        private static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True";
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> emplist = new List<Employee>();

            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("GetAllEmployees", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");
                    emp.DeptNo = dr.GetInt32("DeptNo");
                    emp.Basic = dr.GetDecimal("Basic");

                    emplist.Add(emp);
                }
                dr.Close();
                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        employees.Add(new Employee
                //        {
                //            EmpNo = reader.GetInt32(0),
                //            Name = reader.GetString(1),
                //            Basic = reader.GetDecimal(2),
                //            DeptNo = reader.GetInt32(3)
                //        });
                //    }
                //    reader.Close();
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return emplist;
        }
        public static Employee GetSingleEmployee(int empNo)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("GetEmployeeById", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure

                };
                cmd.Parameters.AddWithValue("@EmpNo", empNo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Employee
                        {
                            EmpNo = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Basic = reader.GetDecimal(2),
                            DeptNo = reader.GetInt32(3)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { cn.Close(); }
        }
        public static void Insert(Employee obj)
        {
        SqlConnection cn = new SqlConnection(ConnectionString);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("InsertEmployee");
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Basic", obj.Basic);
            cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally { cn.Close(); }
        }
        public static void Update(Employee obj)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand("UpdateEmployee", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Update successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
        public static void Delete(int empNo)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand("DeleteEmployee", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmdDelete.Parameters.AddWithValue("@EmpNo", empNo);

                cmdDelete.ExecuteNonQuery();
                Console.WriteLine("Delete successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

        
    }
}
