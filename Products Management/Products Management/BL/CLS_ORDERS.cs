using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Products_Management.BL
{
    class CLS_ORDERS
    {
        public DataTable GET_LAST_ORDER_ID()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            dt = DAL.SelectData("GET_LAST_ORDER_ID", null);

            DAL.Close();

            return dt;
        }
        public DataTable GET_LAST_ORDER_FOR_PRINT()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            dt = DAL.SelectData("GET_LAST_ORDER_FOR_PRINT", null);

            DAL.Close();

            return dt;
        }
        public void ADD_ORDER(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID,
            string DESCRIPTION_ORDER, string SALESMAN)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[0].Value = ID_ORDER;

            param[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            param[1].Value = DATE_ORDER;

            param[2] = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int);
            param[2].Value = CUSTOMER_ID;

            param[3] = new SqlParameter("@DESCRIPTION_ORDER", SqlDbType.VarChar,250);
            param[3].Value = DESCRIPTION_ORDER;

            param[4] = new SqlParameter("@SALESMAN", SqlDbType.VarChar,75);
            param[4].Value = SALESMAN;

          



            DAL.ExecuteCommand("ADD_ORDER", param);
            DAL.Close();
        }

        public void ADD_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTY,
           string PRICE, float DISCOUNT , string AMOUNT,string TOTAL_AMOUNT)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            // because execute command needs to open the connection because it doesnt open it itself
            DAL.Open();

            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar,30);
            param[0].Value = ID_PRODUCT;

            param[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[1].Value = ID_ORDER;

            param[2] = new SqlParameter("@QTY", SqlDbType.Int);
            param[2].Value = QTY;

            param[3] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[3].Value = PRICE;

            param[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            param[4].Value = DISCOUNT;

            param[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar,50);
            param[5].Value = AMOUNT;

            param[6] = new SqlParameter("@TOTAL_AMOUNT", SqlDbType.VarChar, 50);
            param[6].Value = TOTAL_AMOUNT;

            DAL.ExecuteCommand("ADD_ORDER", param);
            DAL.Close();
        }

        public DataTable VerifyQty(string ID_PRODUCT ,int Qty_Entered)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);

            param[0].Value = ID_PRODUCT;

            param[1] = new SqlParameter("@Qty_Entered", SqlDbType.Int);
            param[1].Value = Qty_Entered;

            dt = DAL.SelectData("VerifyQty", param);

            DAL.Close();

            return dt;
        }

        public DataTable GetOrderDetails(int ID_PRODUCT)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID_ORDERS", SqlDbType.Int);

            param[0].Value = ID_PRODUCT;

            dt = DAL.SelectData("GetOrderDetails", param);

            DAL.Close();

            return dt;
        }
        public DataTable SearchOrders(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();


            //dnt need to DAL.OPEN() because data adapter will open it

            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar,50);

            param[0].Value = Criterion;

            dt = DAL.SelectData("SearchOrders", param);

            DAL.Close();

            return dt;
        }
    }
}
