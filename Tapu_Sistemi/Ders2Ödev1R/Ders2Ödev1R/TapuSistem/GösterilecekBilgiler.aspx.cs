using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography.X509Certificates;

namespace Ders2Ödev1R.TapuSistem
{
    public partial class GösterilecekBilgiler : System.Web.UI.Page
    {      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {               
                GrdBilgiÇekme grd = new GrdBilgiÇekme();               
                grd.SqlBilgiÇek(GrdTapuBilgi);
                grd.SqlBilgiÇek2(GrdTapuİsimParsel);
               
            }           
        }
        public class GrdBilgiÇekme
        {
            public string Connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Ders2Ödev1;Integrated Security=True";
            public void SqlBilgiÇek(GridView grdname)
            {
                SqlConnection con = new SqlConnection(Connection);
                using (SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM TapuGösterilecekBilgiler", con))
                {

                    con.Open();
                    DataSet dataset = new DataSet();
                    Adapter.Fill(dataset);
                    grdname.DataSource = dataset.Tables[0];
                    grdname.DataBind();
                    con.Close();
                }
            }
            public void SqlBilgiÇek2(GridView grdname)
            {
                SqlConnection con = new SqlConnection(Connection);
                using (SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM TapuBilgileri", con))
                {
                    con.Open();
                    DataSet dataset = new DataSet();
                    Adapter.Fill(dataset);
                    grdname.DataSource = dataset.Tables[0];
                    grdname.DataBind();
                    con.Close();
                }
            }
        }
        
    }
}