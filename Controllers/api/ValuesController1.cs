using CollageWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace CollageWebApi.Controllers.api
{
    public class ValuesController : ApiController
    {
        string stringConnection = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=CollegeDB;Integrated Security=True;Pooling=False";
        List<Student> studentList = new List<Student>();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = @"SELECT * FROM Student";
                    SqlCommand command = new SqlCommand(qury, connection);
                    SqlDataReader execute = command.ExecuteReader();
                    if (execute.HasRows)
                    {
                        while (execute.Read())
                        {
                            studentList.Add(new Student(execute.GetString(1), execute.GetString(2), execute.GetDateTime(3), execute.GetString(4), execute.GetInt32(5)));
                        }
                        connection.Close();
                        return Ok(new { studentList });
                    }
                    else
                    {
                        connection.Close();
                        return Ok("the table empty");
                    }
                }
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = @"SELECT * FROM Student";
                    SqlCommand command = new SqlCommand(qury, connection);
                    SqlDataReader execute = command.ExecuteReader();
                    while (execute.Read())
                    {
                        if (execute.GetInt32(0) == id)
                        {                           
                            return Ok((execute.GetString(1), execute.GetString(2), execute.GetDateTime(3), execute.GetString(4), execute.GetInt32(5)));
                            connection.Close();
                        }
                    }
                    connection.Close();
                    return Ok("the student not exist in system");
                }
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        // POST api/<controller>
        public IHttpActionResult Post(Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = $@"INSERT INTO Student(FirstName,LastName,Birthday,Email,SchoolYear)
                   VALUES('{student.firstName}','{student.lastName}','{student.birthday}','{student.email}',{student.schoolYear})";
                    SqlCommand command = new SqlCommand(qury, connection);
                    int execute = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(execute);
                }
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        // PUT api/<controller>/5
        public IHttpActionResult Put(int id,Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = $@"UPDATE Student
                                     SET FirstName ='{student.firstName}',
                                         LastName ='{student.lastName}',
                                         Birthday = '{student.birthday}',
                                         Email = '{student.email}',
                                         SchoolYear = {student.schoolYear}
                                      WHERE Id={id}";
                    SqlCommand command = new SqlCommand(qury, connection);
                    int execute = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(execute);
                }
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = $@"DELETE FROM Student WHERE Id={id}";
                    SqlCommand command = new SqlCommand(qury, connection);
                    int execute = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(execute);
                }
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
               return Ok(ex.Message);
            }
            
        }
    }
}