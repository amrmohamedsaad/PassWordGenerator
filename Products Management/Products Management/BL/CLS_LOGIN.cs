using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Management.BL
{
    //class contains methods to login / add / edit / delete  and search  users
    class CLS_LOGIN
    {
        //method to take the username and password 
        //with the selectdata method created in the DAL
        //Wich take SP_login stored procedure created in the database and its parameters 
        public DataTable LOGIN(String ID, String PWD)
        { //create object from data access layer class
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            //initialize new object from sqlparameter class
            SqlParameter[] param = new SqlParameter[2];
            //initialize the first parameter (ID)
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            //initialize the secound parameter (PWD)
            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;

            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            dt = DAL.SelectData("SP_LOGIN", param);

            DAL.Close();

            return dt;
        }
        //Method to add new user
        public void ADD_USER(string ID, string FullName, string PWD, string UserType)
       
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@FULLNAME", SqlDbType.VarChar, 50);
            param[1].Value = FullName;
            
            param[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[2].Value = PWD;

            param[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            param[3].Value = UserType;

            DAL.ExecuteCommand("ADD_USER", param);

            DAL.Close();
        }
        //Method to Edite existing user
        public void Edit_USER(string ID, string FullName, string PWD, string UserType)

        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@FULLNAME", SqlDbType.VarChar, 50);
            param[1].Value = FullName;

            param[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[2].Value = PWD;

            param[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            param[3].Value = UserType;

            DAL.ExecuteCommand("Edit_USER", param);
            DAL.Close();
        }
        //method to Delete existing user
        public void Delete_USER(string ID)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            DAL.ExecuteCommand("Delete_USER", param);
            DAL.Close();
        }
        //Method to find users
        public DataTable SearchUsers(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);

            param[0].Value = Criterion;

            dt = DAL.SelectData("SearchUsers", param);

            DAL.Close();

            return dt;
        }
    }
}
