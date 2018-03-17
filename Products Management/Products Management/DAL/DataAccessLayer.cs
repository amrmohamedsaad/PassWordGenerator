using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Products_Management.DAL
{
    class DataAccessLayer
    {

        // Declare sqlconnection that will be initialized in the methods
        SqlConnection sqlconnection;
        //we will make the new object data inside the constructor because
        //the constructor is the first thing that executed when the object of the class created
        public DataAccessLayer()
        {
            //initialize the sql connection immediately after initializing object from Dataaccesslayer class
            string mode = Properties.Settings.Default.Mode;
            if (mode == "SQL")
            {
                try
                {
                    //MessageBox.Show("Server=" + Application.StartupPath + "\\DataBase\\Product_DB.mdf; Integrated Security =true; User ID=sa;Password=123");
                    //sqlconnection = new SqlConnection("Server="+ Application.StartupPath + "\\Product_DB.mdf; Integrated Security =true; User ID=sa;Password=123");
                    sqlconnection = new SqlConnection("Server=" + Properties.Settings.Default.Server + "; Database=" +
                    Properties.Settings.Default.Database + "; Integrated Security=true");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                  
                }

            }
            else
            {
                try
                {
                        sqlconnection = new SqlConnection("Server=" + Properties.Settings.Default.Server + "; Database=" +
                        Properties.Settings.Default.Database + "; Integrated Security=true");
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message.ToString());
                }
        
               
            }
        }

        //Method to open the connection
        public void Open()
        {
            //check if the connection is not open first
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        //method to close the connection
        public void Close()
        {
            //check if the connection is open then close it 
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        //method to read data from database
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            //initialize sqlcommand
            SqlCommand sqlcmd = new SqlCommand();
            //set the command type that initialized
            sqlcmd.CommandType = CommandType.StoredProcedure;
            // sets the Transact-SQL statement and in this case is stored procedure 
            //to execute at the data source
            sqlcmd.CommandText = stored_procedure;
            //set the connection name to the sqlcommand
            sqlcmd.Connection = sqlconnection;
            //if the stored procedure contains parameters
            if (param != null)
            {
                // because i dont know thier count
                //go for all the parameters with loop
                for (int i = 0; i < param.Length; i++)
                {
                    //write these parameters to the sqlcommand which is stored procedure
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            //Represents a set of data commands that we made above  and a database connection 
            //that are used to fill the DataSet 
            //represents an intermediary between the database and the dataset
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            //represents table that saves the information that cmes from the query statements
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Method to insert , update and delete data from database
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                //add an array of sqlparameter values rather then making for loop
                sqlcmd.Parameters.AddRange(param);


            }

            //enter the data without return anything
            sqlcmd.ExecuteNonQuery();
        }
    }
}
