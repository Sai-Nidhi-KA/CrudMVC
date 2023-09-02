using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplicationmvc.Models;
using System.Drawing;

namespace WebApplicationmvc.DataAccess
{
    public class DataAccessLayer
    {
        string connString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();
        
        public List<EmployeeModel>GetEmployees()
        {
            List<EmployeeModel> employeesList = new List<EmployeeModel>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Employee_Details";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtable = new DataTable();

                connection.Open();
                adapter.Fill(dtable);
                connection.Close();

                foreach(DataRow row in dtable.Rows)
                {
                    employeesList.Add(new EmployeeModel
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["Name"].ToString(),
                        City = row["City"].ToString(),
                        Address= row["Address"].ToString(),

                    }); 
                }
            }
            return employeesList;
        }
        //Insertion
        public bool InsertDetails(EmployeeModel employeeModel)
        {
            
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("Insertdata", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", employeeModel.Name);
                command.Parameters.AddWithValue("@City", employeeModel.City);
                command.Parameters.AddWithValue("@Address", employeeModel.Address);

                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
            
        }
        //Update employee by Id
        public List<EmployeeModel> GetEmployeeById(int Id)
        {
            List<EmployeeModel> employeesList = new List<EmployeeModel>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetEmployeeById";
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtable = new DataTable();

                connection.Open();
                adapter.Fill(dtable);
                connection.Close();

                foreach (DataRow row in dtable.Rows)
                {
                    employeesList.Add(new EmployeeModel
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["Name"].ToString(),
                        City = row["City"].ToString(),
                        Address = row["Address"].ToString(),

                    });
                }
            }
            return employeesList;
        }

        //Update
        public bool UpdateDetails(EmployeeModel employeeModel)
        {

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("UpdateEmpDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",employeeModel.Id);
                command.Parameters.AddWithValue("@Name", employeeModel.Name);
                command.Parameters.AddWithValue("@City", employeeModel.City);
                command.Parameters.AddWithValue("@Address", employeeModel.Address);

                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }

        }
        public bool DeleteDetail(int Id)
        {
            

            using (SqlConnection connection = new SqlConnection(connString))
            {

                SqlCommand command = new SqlCommand("DeleteDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);

                connection.Open();
                int i =command.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
                
        }
    }
}