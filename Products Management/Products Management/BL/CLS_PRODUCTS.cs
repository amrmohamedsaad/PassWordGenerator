using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Products_Management.BL
{
    class CLS_PRODUCTS
    {
        public DataTable GET_ALL_CATEGORIES()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            dt = DAL.SelectData("GET_ALL_CATEGORIES", null);

            DAL.Close();

            return dt;
        }
      

        
        public void ADD_PRODUCT(int ID_cat, string Label_product, string ID_product, int Qte, string Price, byte[] img)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_cat;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[1].Value = ID_product;

            param[2] = new SqlParameter("@LABEL", SqlDbType.VarChar, 30);
            param[2].Value = Label_product;

            param[3] = new SqlParameter("@QTE", SqlDbType.Int);
            param[3].Value = Qte;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[4].Value = Price;

            param[5] = new SqlParameter("@Img", SqlDbType.Image);
            param[5].Value = img;

            DAL.ExecuteCommand("ADD_PRODUCT", param);
            DAL.Close();
        }


        public DataTable VerifyProductID(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);

            param[0].Value = ID;

            dt = DAL.SelectData("VerifyProductID", param);

            DAL.Close();

            return dt;
        }

        public DataTable GET_ALL_PRODUCTS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            dt = DAL.SelectData("GET_ALL_PRODUCTS", null);

            DAL.Close();

            return dt;
        }

        public DataTable SearchProduct(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);

            param[0].Value = ID;

            dt = DAL.SelectData("SearchProduct", param);

            DAL.Close();

            return dt;
        }

        public void DeleteProduct(string ID)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;


            DAL.ExecuteCommand("DeleteProduct", param);
            DAL.Close();
        }

        public DataTable GET_IMAGE_PRODUCT(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);

            param[0].Value = ID;

            dt = DAL.SelectData("GET_IMAGE_PRODUCT", param);

            DAL.Close();

            return dt;
        }

        public void UPDATE_PRODUCT(int ID_cat, string Label_product, string ID_product, int Qte, string Price, byte[] img)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_cat;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[1].Value = ID_product;

            param[2] = new SqlParameter("@LABEL", SqlDbType.VarChar, 30);
            param[2].Value = Label_product;

            param[3] = new SqlParameter("@QTE", SqlDbType.Int);
            param[3].Value = Qte;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[4].Value = Price;

            param[5] = new SqlParameter("@Img", SqlDbType.Image);
            param[5].Value = img;

            DAL.ExecuteCommand("UPDATE_PRODUCT", param);
            DAL.Close();
        }
    }

}
