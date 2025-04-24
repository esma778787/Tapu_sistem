using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ders2Ödev1R.TapuSistem
{
    public partial class KisiTapuBilgiGiris : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            KisiTapuBilgiGirme ktbg = new KisiTapuBilgiGirme();
            ktbg.deneme(TapuEdinmeTarihiGün, TapuEdinmeTarihiAy, TapuEdinmeTarihiYıl, TapuEdinmeYoluSecim, TapuİsimSecim, TapuKacinciSahipText, ŞahısİsimText, ŞahısSoyisimText, ŞahısDoğumyılText, ŞahısTCText, TapuEdinmeNedeniText, TapuEdinmeYoluSecim, TapuEdinmeTarihi);
            if (!Page.IsPostBack)
            {
                ktbg.YılVeAy();
                ktbg.Bilgiler();
            }    
            // HERHANGİ BİR BUTTON VEYA DROPDOWNLİST'İN ONXXX'İNİ(ONCLİCK) CLASS'A ALMAK VE ÇALIŞTIRMAK İÇİN YAPTIM
            this.TapuİsimSecim.SelectedIndexChanged += new System.EventHandler(ktbg.TapuİsimSecim_SelectedIndexChanged);
            this.ŞahısTapuBilgiOnay.Click += new System.EventHandler(ktbg.ŞahısTapuBilgiOnay_Click);
            this.GeriDön.Click += new ImageClickEventHandler(ktbg.GeriDön_Click);
            this.TapuEdinmeTarihiAy.SelectedIndexChanged += new System.EventHandler(ktbg.TapuEdinmeTarihiAy_SelectedIndexChanged);
            this.TapuKacinciSahipText.SelectedIndexChanged += new System.EventHandler(ktbg.TapuKacinciSahipText_SelectedIndexChanged);
            this.TapuBilgileriGöster.Click += new System.EventHandler(ktbg.TapuBilgileriGöster_Click);
        }
        public class KisiTapuBilgiGirme
        {
            DropDownList day;
            DropDownList month;
            DropDownList year;
            DropDownList tapuedinmeyolus;
            DropDownList Tapuİsimsecim;
            DropDownList TapuKacinciSahip;
            TextBox Şahısİsim;
            TextBox ŞahısSoyisim;
            TextBox ŞahısDogumYili;
            TextBox ŞahısTC;
            TextBox TapuEdinmeNedeni;
            DropDownList TapuEdinmeYolu;
            Label TapuEdinmeTarihi;
            string Connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Ders2Ödev1;Integrated Security=True";
            public void deneme(DropDownList Day, DropDownList Month, DropDownList Year, DropDownList TapuEdinmeYoluSecim, DropDownList TapuİsimSeç, DropDownList TapuKacinciSah, TextBox Şİ, TextBox ŞS, TextBox ŞDY, TextBox ŞTC, TextBox TEN, DropDownList TEY,Label TET)
            {
                day = Day;
                month = Month;
                year = Year;
                tapuedinmeyolus = TapuEdinmeYoluSecim;
                Tapuİsimsecim = TapuİsimSeç;
                TapuKacinciSahip = TapuKacinciSah;
                Şahısİsim = Şİ;
                ŞahısSoyisim = ŞS;
                ŞahısDogumYili = ŞDY;
                ŞahısTC = ŞTC;
                TapuEdinmeNedeni = TEN;
                TapuEdinmeYolu = TEY;
                TapuEdinmeTarihi = TET;
                
            }
            public void YılVeAy()
            {
                //Tapunun hangi yıl ve ayda alınacağının girilmesi için bulunan yıl ve aylar
                for (int i = 1900; i < 2022; i++)
                {
                    year.Items.Add(i.ToString());
                }
                for (int i = 1; i < 13; i++)
                {
                    month.Items.Add(i.ToString());
                }
            }
            public void Bilgiler()
            {                
                //Tapu alma yolları
                tapuedinmeyolus.Items.Clear();
                tapuedinmeyolus.Items.Add("Babadan miras kaldı.");
                tapuedinmeyolus.Items.Add("Para ile alındı.");
                
                //Tapu isimlerini ekledim
                string sessionDeger1 = HttpContext.Current.Session["Tapuİsim"].ToString();
                Tapuİsimsecim.Items.Add(sessionDeger1);

                int sessionDeger2 = Convert.ToInt32(HttpContext.Current.Session["TapuEdinmeMiktarı"]);
                for (int i = 1; i < sessionDeger2 + 1; i++)
                {
                    TapuKacinciSahip.Items.Add(i.ToString());
                }
                Tapuİsimsecim.Items.Clear();

                //İLK TAPU BİLGİLERİNİ GİRDİĞİMİZ YERDE TAPU ADININ İKİNCİ SAYFADA GÖSTERİLMESİ
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * FROM TapuBilgileri", con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Tapuİsimsecim.Items.Add(dr["Tapuisim"].ToString());
                    }
                    con.Close();
                }
            }
            public void TapuEdinmeTarihiAy_SelectedIndexChanged(object sender, EventArgs e)
            {
                //Aylara göre gün dağılımını yaptım. --> Şubatın 28 çekmesi gibi
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
            public void TapuİsimSecim_SelectedIndexChanged(object sender, EventArgs e)
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TapuEdinilmeMiktarı FROM TapuBilgileri WHERE Tapuisim=" + "'" + Tapuİsimsecim.Text + "'", con);
                    int TapuEdinilmeMiktar = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd = new SqlCommand("SELECT KaçıncıSahip FROM TapuGösterilecekBilgiler WHERE Tapuİsmi=" + "'" + Tapuİsimsecim.Text + "'", con);
                    int TapuSıralamaAyarı = Convert.ToInt32(cmd.ExecuteScalar());
                    TapuKacinciSahip.Items.Clear();
                    for (int i = 1; i < TapuEdinilmeMiktar + 1; i++)
                    {
                        TapuKacinciSahip.Items.Add(i.ToString());
                    }
                    TapuKacinciSahip.Items.Remove(TapuSıralamaAyarı.ToString());

                    //KaçıncıSahip dropdownlist'te ekli olan elemanları silme
                    ArrayList ar = new ArrayList();
                    cmd = new SqlCommand("SELECT KaçıncıSahip FROM TapuGösterilecekBilgiler WHERE Tapuİsmi=" + "'" + Tapuİsimsecim.Text + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ar.Add(Convert.ToInt32(dr["KaçıncıSahip"]));
                    }
                    dr.Close();
                    ar.Sort();
                    for (int i = 0; i < ar.Count; i++)
                    {
                        TapuKacinciSahip.Items.Remove(ar[i].ToString());
                    }

                    //İlkEdinmeTarihini ilk Sahibinin tarihine eşitledim
                    cmd = new SqlCommand("SELECT TapuİlkEdinmeYıl FROM TapuBilgileri WHERE Tapuisim='" + Tapuİsimsecim.Text + "'", con);
                    int İlkEdinmeYıl = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd = new SqlCommand("SELECT TapuİlkEdinmeAy FROM TapuBilgileri WHERE Tapuisim='" + Tapuİsimsecim.Text + "'", con);
                    int İlkEdinmeAy = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd = new SqlCommand("SELECT TapuİlkEdinmeGün FROM TapuBilgileri WHERE Tapuisim='" + Tapuİsimsecim.Text + "'", con);
                    int İlkEdinmeGün = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd = new SqlCommand("UPDATE TapuGösterilecekBilgiler SET EdinmeTarihiYıl=" + İlkEdinmeYıl + "WHERE Tapuİsmi='" + Tapuİsimsecim.Text + "'and KaçıncıSahip=" + 1.ToString(), con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE TapuGösterilecekBilgiler SET EdinmeTarihiAy=" + İlkEdinmeAy + "WHERE Tapuİsmi='" + Tapuİsimsecim.Text + "'and KaçıncıSahip=" + 1.ToString(), con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE TapuGösterilecekBilgiler SET EdinmeTarihiGün=" + İlkEdinmeGün + "WHERE Tapuİsmi='" + Tapuİsimsecim.Text + "'and KaçıncıSahip=" + 1.ToString(), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            public void TapuKacinciSahipText_SelectedIndexChanged(object sender, EventArgs e)
            {
                //Tapu ilk edinme tarihi belli olduğu için tapunun ilk sahibini girerken günü ayı ve yılı kilitledim.
                if (TapuKacinciSahip.Text == 1.ToString())
                {
                    year.Visible = false;
                    month.Visible = false;
                    day.Visible = false;
                    TapuEdinmeTarihi.Visible = false;
                }
                else
                {
                    year.Visible = true;
                    month.Visible = true;
                    day.Visible = true;
                    TapuEdinmeTarihi.Visible = true;
                }
            }
            public void ŞahısTapuBilgiOnay_Click(object sender, EventArgs e)
            {
                //İsmi X****X şeklinde gösterme (Gizleme)
                int x = 0;
                string ilkHarf = "";
                x = Şahısİsim.Text.Length;
                ilkHarf = Şahısİsim.Text.Substring(0, 1);
                var sonharf = Şahısİsim.Text[Şahısİsim.Text.Length - 1];
                x = (x - 2);
                string Gizliİsim = new string('*', x);
                Gizliİsim = ilkHarf + Gizliİsim + sonharf;


                //Soyismi X****X şeklinde gösterme (Gizleme)
                x = ŞahısSoyisim.Text.Length;
                ilkHarf = ŞahısSoyisim.Text.Substring(0, 1);
                sonharf = ŞahısSoyisim.Text[ŞahısSoyisim.Text.Length - 1];
                x = x - 2;
                string GizliSoyisim = new string('*', x);
                GizliSoyisim = ilkHarf + GizliSoyisim + sonharf;

                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into KişiselBilgiler (İsim, Soyisim, DoğumYıl, [T.C]) Values ('" + Şahısİsim.Text + "','" + ŞahısSoyisim.Text + "'," + ŞahısDogumYili.Text + "," + ŞahısTC.Text + ")";
                    cmd.ExecuteNonQuery();
                    if (TapuKacinciSahip.Text != 1.ToString())
                    {
                        cmd.CommandText = "insert into TapuKişi (KaçıncıSahip, TapuyuEdinmeYolu, TapuyuEdinmeNedeni, TapuyuEdinmeTarihiYıl, TapuyuEdinmeTarihiAy, TapuyuEdinmeTarihiGün)" +
                       "Values (" + TapuKacinciSahip.Text + ",'" + TapuEdinmeYolu.Text + "','" + TapuEdinmeNedeni.Text + "'," + year.Text + "," + month.Text + "," + day.Text + ")";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "insert into TapuGösterilecekBilgiler (Tapuİsmi, İsim, Soyisim, KaçıncıSahip, EdinmeTarihiYıl, EdinmeTarihiAy, EdinmeTarihiGün, EdinmeSebebi)" +
                        "Values ('" + Tapuİsimsecim.Text + "','" + Gizliİsim + "','" + GizliSoyisim + "'," + TapuKacinciSahip.Text + "," + year.Text + "," + month.Text + "," + day.Text + ",'" + TapuEdinmeNedeni.Text + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "insert into TapuKişi (KaçıncıSahip, TapuyuEdinmeYolu, TapuyuEdinmeNedeni)" +
                       "Values (" + TapuKacinciSahip.Text + ",'" + TapuEdinmeYolu.Text + "','" + TapuEdinmeNedeni.Text + "'" + ")";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "insert into TapuGösterilecekBilgiler (Tapuİsmi, İsim, Soyisim, KaçıncıSahip, EdinmeSebebi)" +
                        "Values ('" + Tapuİsimsecim.Text + "','" + Gizliİsim + "','" + GizliSoyisim + "'," + TapuKacinciSahip.Text + ",'" + TapuEdinmeNedeni.Text + "')";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            public void GeriDön_Click(object sender, ImageClickEventArgs e)
            {
                HttpContext.Current.Response.Redirect("~/TapuSistem/TapuBilgiGiris.aspx");
            }

            public void TapuBilgileriGöster_Click(object sender, EventArgs e)
            {
                //Tapu Bilgilerinde Önceki Sahibi ayarladım.
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    ArrayList ar = new ArrayList();
                    SqlCommand cmd = new SqlCommand("SELECT KaçıncıSahip FROM TapuGösterilecekBilgiler WHERE Tapuİsmi=" + "'" + Tapuİsimsecim.Text + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ar.Add(Convert.ToInt32(dr["KaçıncıSahip"]));
                    }
                    dr.Close();
                    ar.Sort();
                    for (int i = 0; i < ar.Count - 1; i++)
                    {
                        cmd = new SqlCommand("SELECT İsim FROM TapuGösterilecekBilgiler WHERE KaçıncıSahip='" + ar[i].ToString() + "'and Tapuİsmi='" + Tapuİsimsecim.Text + "'", con);
                        string isim = cmd.ExecuteScalar().ToString();
                        cmd = new SqlCommand("UPDATE TapuGösterilecekBilgiler SET ÖncekiSahip= '" + isim + "'" + "WHERE KaçıncıSahip=" + ar[i + 1].ToString() + "and Tapuİsmi='" + Tapuİsimsecim.Text + "'", con);
                        cmd.ExecuteNonQuery();
                    }
                    ar.Clear();
                    con.Close();
                }
                HttpContext.Current.Response.Redirect("~/TapuSistem/GösterilecekBilgiler.aspx");
            }
        }                                         
        
    }
}