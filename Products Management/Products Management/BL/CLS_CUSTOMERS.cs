using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Management.BL
{
    class CLS_CUSTOMERS
    {
        //Method to Add new customer
        public void ADD_CUSTOMER(string First_Name, string Last_Name, string Tel, string Email, 
            byte[] Picture,string Criterion)
        {
            //create object from data access layer class
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();
            //create object from sqlparameter
            SqlParameter[] param = new SqlParameter[6];
            /*initialize the param with the parameters of 
             the stored procedure  created in the database*/
            param[0] = new SqlParameter("@First_Name", SqlDbType.VarChar,25);
            param[0].Value = First_Name;

            param[1] = new SqlParameter("@Last_Name", SqlDbType.VarChar, 25);
            param[1].Value = Last_Name;

            param[2] = new SqlParameter("@Tel", SqlDbType.VarChar, 15);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar,25);
            param[3].Value = Email;

            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = Picture;

            param[5] = new SqlParameter("@Criterion", SqlDbType.VarChar ,50);
            param[5].Value = Criterion;

            
            //execute command method created in data access layer to take the stored procedure name and its parameters
            DAL.ExecuteCommand("ADD_CUSTOMER", param);
            //close connection
            DAL.Close();
        }

        //Method to edite and update the existing customers
        public void EDIT_CUSTOMERS(string First_Name, string Last_Name, string Tel, string Email, byte[] Picture, string Criterion,int ID)
        {
            //create data access layer object to access its methods that retrieve data from database
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();
            //create sqlparameter object 
            /*initialize the param with the parameters of 
           the stored procedure  created in the database*/
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@First_Name", SqlDbType.VarChar, 25);
            param[0].Value = First_Name;

            param[1] = new SqlParameter("@Last_Name", SqlDbType.VarChar, 25);
            param[1].Value = Last_Name;

            param[2] = new SqlParameter("@Tel", SqlDbType.VarChar, 15);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 25);
            param[3].Value = Email;

            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = Picture;

            param[5] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[5].Value = Criterion;

            param[6] = new SqlParameter("@ID", SqlDbType.Int);
            param[6].Value = ID;
            //execute command take the stored procedure name created in the database and the  param object 
            //that  i initialized its objects in this method
            DAL.ExecuteCommand("EDIT_CUSTOMERS", param);
            //close the connection
            DAL.Close();

        }
        //Method to delete customers
        public void DELETE_CUSTOMER(int ID)
        {
            //creating dataaccesslayer object
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();
            //create sqlparameter object 
            /*initialize the param with the parameters of 
           the stored procedure  created in the database*/
            SqlParameter[] param = new SqlParameter[1];

     
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            //execute command take the stored procedure name created in the database and the  param object 
            //that  i initialized its objects in this method
            DAL.ExecuteCommand("DELETE_CUSTOMER", param);
            //close the connection

            DAL.Close();

        }

        public DataTable GET_ALL_CUSTOMERS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it
            //create datatable object which represent on table in the memory
            DataTable dt = new DataTable();
            //select data method created in the data access layer class to read data from the database
            dt = DAL.SelectData("GET_ALL_CUSTOMERS", null);

            DAL.Close();

            return dt;
        }

        public DataTable Search_Customer( string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;
            dt = DAL.SelectData("Search_Customer", param);

            DAL.Close();

            return dt;
        }
    }
}
