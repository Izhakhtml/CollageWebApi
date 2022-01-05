using CollageWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollageWebApi.Controllers.api
{
    public class LecturesController : ApiController
    {
        string stringConnection = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=CollegeDB;Integrated Security=True;Pooling=False";
        List<Lecturer> lecturesList = new List<Lecturer>();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = @"SELECT * FROM Lecture";
                    SqlCommand command = new SqlCommand(qury, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lecturesList.Add(new Lecturer(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
                        }
                        connection.Close();
                        return Ok(new { lecturesList });
                    }
                    else
                    {
                        connection.Close();
                        return Ok("llllll");
                    }
                }
            }
            catch (SqlException ex) { return Ok(ex.Message); }
            catch (Exception ex) { return Ok(ex.Message); }
        }
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = $@"SELECT * FROM Lecture WHERE Id={id}";
                    SqlCommand command = new SqlCommand(qury, connection);
                    SqlDataReader execute = command.ExecuteReader();
                    while (execute.Read())
                    {
                        if (execute.GetInt32(0) == id)
                        {   
                            return Ok((execute.GetString(1), execute.GetString(2), execute.GetString(3), execute.GetString(4), execute.GetInt32(5)));
                            connection.Close();
                        }

                    }
                    connection.Close();
                    return Ok("Not exist lecture in system");
                }
            }
            catch (SqlException ex) { return Ok(ex.Message); }
            catch (Exception ex) { return Ok(ex.Message); }
        }
        // POST api/<controller>
        public IHttpActionResult Post(Lecturer lecturer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = $@"INSERT INTO Lecture(FirstName,LastName,Domain,Email,Salary)
                                 VALUES('{lecturer.firstName}','{lecturer.lastName}','{lecturer.domain}','{lecturer.email}',{lecturer.salary})";
                    SqlCommand command = new SqlCommand(qury, connection);
                    int execute = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(execute);
                }
            }
            catch (SqlException ex) { return Ok(ex.Message); }
            catch (Exception ex) { return Ok(ex.Message); }
        }
        // PUT api/<controller>/5
        public IHttpActionResult Put(int id,Lecturer lecturer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = $@"UPDATE Lecture
                                 SET FirstName = '{lecturer.firstName}',
                                     LastName = '{lecturer.lastName}',
                                     Domain = '{lecturer.domain}',
                                     Email = '{lecturer.email}' ,
                                     Salary = {lecturer.salary}
                                WHERE Id={id} ";
                    SqlCommand command = new SqlCommand(qury, connection);
                    int execute = command.ExecuteNonQuery();  
                    connection.Close();
                    return Ok(execute);  
                }
            }
            catch (SqlException ex) { return Ok(ex.Message); }
            catch (Exception ex) { return Ok(ex.Message); }
        }
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string qury = $@"DELETE FROM Lecture WHERE Id={id}";
                    SqlCommand command = new SqlCommand(qury, connection);
                    int execute = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(execute);

                }
            }
            catch (SqlException ex) { return Ok(ex.Message); }
            catch (Exception ex) { return Ok(ex.Message); }
        }
    }
}