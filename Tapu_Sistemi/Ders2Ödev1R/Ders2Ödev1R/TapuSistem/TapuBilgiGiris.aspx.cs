using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ders2Ödev1R
{
    public partial class TapuBilgiGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TapuBilgiGirme tbg = new TapuBilgiGirme();
            tbg.deneme(TapuİlkEdinmeTarihGün, TapuİlkEdinmeTarihAy, TapuİlkEdinmeTarihYıl, TapuİsmiText, TapuParselText, TapuEdinilmeMiktarText);
            if (!IsPostBack)
            {
                tbg.YılVeAy();
            }           
            this.TapuİlkEdinmeTarihAy.SelectedIndexChanged += new System.EventHandler(tbg.TapuİlkEdinmeTarihAy_SelectedIndexChanged);
            this.TapuBilgiOnay.Click += new System.EventHandler(tbg.TapuBilgiOnay_Click);
        }
        public class TapuBilgiGirme
        {
            DropDownList day;
            DropDownList month;
            DropDownList year;
            TextBox tapui;
            TextBox tapup;
            TextBox tapuem;
            public void deneme(DropDownList Day, DropDownList Month, DropDownList Year, TextBox Tapuİ, TextBox TapuP, TextBox TapuEM)
            {
                day = Day;
                month = Month;
                year = Year;
                tapui = Tapuİ;
                tapup = TapuP;
                tapuem = TapuEM;
            }
            public void YılVeAy()
            {
                year.Items.Clear();
                month.Items.Clear();
                for (int i = 1900; i < 2022; i++)
                {
                    year.Items.Add(i.ToString());
                }
                for (int i = 1; i < 13; i++)
                {
                    month.Items.Add(i.ToString());
                }
            }
            string Connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Ders2Ödev1;Integrated Security=True";
            public void TapuİlkEdinmeTarihAy_SelectedIndexChanged(object sender, EventArgs e)
            {               
                day.Items.Clear();
                if (month.SelectedIndex == 1)
                {
                    for (int i = 1; i < 29; i++)
                    {
                        day.Items.Add(i.ToString());
                    }

                }
                else if (month.SelectedIndex == 3 || month.SelectedIndex == 5 || month.SelectedIndex == 8 || month.SelectedIndex == 10)
                {
                    for (int i = 1; i < 31; i++)
                    {
                        day.Items.Add(i.ToString());
                    }

                }
                else if (month.SelectedIndex == 0 || month.SelectedIndex == 2 || month.SelectedIndex == 4 || month.SelectedIndex == 6 || month.SelectedIndex == 7 || month.SelectedIndex == 9 || month.SelectedIndex == 11)
                {
                    for (int i = 1; i < 32; i++)
                    {
                        day.Items.Add(i.ToString());
                    }

                }
            }
            public void TapuBilgiOnay_Click(object sender, EventArgs e)
            {
                HttpContext.Current.Session["Tapuİsim"] = tapui.Text;
                HttpContext.Current.Session["TapuEdinmeMiktarı"] = tapuem.Text;               

                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into TapuBilgileri (Tapuisim, TapuilkEdinmeYıl, TapuilkEdinmeAy, TapuilkEdinmeGün, TapuEdinilmeMiktarı, TapuParselSayısı) Values ('" + tapui.Text + "'," + year.Text + "," + month.Text + "," + day.Text + "," + tapuem.Text + "," + tapup.Text + ")";
                    cmd.ExecuteNonQuery();
                }
                HttpContext.Current.Response.Redirect("~/TapuSistem/KisiTapuBilgiGiris.aspx");
            }          
        }       
    }
}