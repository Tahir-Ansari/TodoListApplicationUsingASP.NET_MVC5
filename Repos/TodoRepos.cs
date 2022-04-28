using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoList.Models;

namespace TodoList.Repos
{
    public class TodoRepos
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TodoDB"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddTodo(Todo todo)
        {

            connection();
            SqlCommand com = new SqlCommand("AddTodo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Description", todo.Description);
            com.Parameters.AddWithValue("@MarkedDone", todo.MarkedDone);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        public List<Todo> GetAllTodo()
        {
            connection();
            List<Todo> TodoList = new List<Todo>();
            SqlCommand com = new SqlCommand("GetTodo", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();


            TodoList = (from DataRow dr in dt.Rows

                        select new Todo()
                        {
                            ID = Convert.ToInt32(dr["Id"]),
                            Description = Convert.ToString(dr["Description"]),
                            MarkedDone = Convert.ToBoolean(dr["MarkedDone"])
                        }).ToList();


            return TodoList;


        }

        public List<Todo> GetActiveTodo()
        {
            connection();
            List<Todo> TodoList = new List<Todo>();
            SqlCommand com = new SqlCommand("GetActiveTodo", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();


            TodoList = (from DataRow dr in dt.Rows

                        select new Todo()
                        {
                            ID = Convert.ToInt32(dr["Id"]),
                            Description = Convert.ToString(dr["Description"]),
                            MarkedDone = Convert.ToBoolean(dr["MarkedDone"])
                        }).ToList();


            return TodoList;


        }


        public List<History> GetAllHistory()
        {
            connection();
            List<History> TodoList = new List<History>();
            SqlCommand com = new SqlCommand("GetHistory", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();


            TodoList = (from DataRow dr in dt.Rows

                        select new History()
                        {
                            ID = Convert.ToInt32(dr["Id"]),
                            Description = Convert.ToString(dr["Description"]),
                            MarkedDone = Convert.ToBoolean(dr["MarkedDone"])
                        }).ToList();


            return TodoList;
        }


        public bool UpdateTodos(Todo todo)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateTodo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", todo.ID);
            com.Parameters.AddWithValue("@Description", todo.Description);
            com.Parameters.AddWithValue("@MarkedDone", todo.MarkedDone);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }

        public bool UpdateTodo(int id)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateTodoCompleted", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTodo(int ID)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteTodoById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", ID);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
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