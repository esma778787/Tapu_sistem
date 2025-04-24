<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KisiTapuBilgiGiris.aspx.cs" Inherits="Ders2Ödev1R.TapuSistem.KisiTapuBilgiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position:relative; height:700px; width:1000px;">
            <table>
                <asp:Label ID="ŞahısBilgi" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Text="Şahıs Bilgileri" Font-Underline="true" style="position:absolute; bottom:675px; left:100px;"></asp:Label>
                <asp:Label ID="Şahısİsim" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Text="İsim:" style="position:absolute; bottom:520px;"></asp:Label>
                <asp:TextBox ID="ŞahısİsimText" runat="server" Width="250px" Height="30px" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" ForeColor="Red" Font-Bold="true" Font-Size="Large" Style="position:absolute; bottom:520px; left:160px;" AutoPostBack="False"></asp:TextBox>

                <asp:Label ID="ŞahısSoyisim" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Text="Soyadı:" style="position:absolute; bottom:420px;"></asp:Label>
                <asp:TextBox ID="ŞahısSoyisimText" runat="server" Width="250px" Height="30px" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" ForeColor="Red" Font-Bold="true" Font-Size="Large" Style="position:absolute; bottom:420px; left:160px;"></asp:TextBox>

                <asp:Label ID="ŞahısDoğumyıl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Text="Doğum Yılı:" style="position:absolute; bottom:320px;"></asp:Label>
                <asp:TextBox ID="ŞahısDoğumyılText" runat="server" Width="250px" Height="30px" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" ForeColor="Red" Font-Bold="true" Font-Size="Large" Style="position:absolute; bottom:320px; left:160px;"></asp:TextBox>

                <asp:Label ID="ŞahısTC" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Text="T.C.KimlikNo:" style="position:absolute; bottom:220px;"></asp:Label>
                <asp:TextBox ID="ŞahısTCText" runat="server" Width="250px" Height="30px" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" ForeColor="Red" Font-Bold="true" Font-Size="Large" Style="position:absolute; bottom:220px; left:160px;"></asp:TextBox>

                <asp:Button ID="ŞahısTapuBilgiOnay" runat="server" Width="150px" Height="40px" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" ForeColor="Red" Font-Bold="true" Text="Onayla" Font-Size="X-Large" style="position:absolute; bottom:100px; left:500px;" />


                <asp:Label ID="TapuEdinmeBilgi" runat="server" Font-Bold="true" Width="300px" Font-Size="X-Large" ForeColor="#ff3300" Text="Tapu Edinme Bilgileri" Font-Underline="true" style="position:absolute; bottom:675px; left:900px;"></asp:Label>
                <asp:Label ID="Tapuİsim" runat="server" Text="Tapu İsmini Seçiniz:" Font-Bold="true" Font-Size="X-Large" Width="300px" ForeColor="#ff3300" style="position:absolute; bottom:600px; left:350px"></asp:Label>
                <asp:DropDownList ID="TapuİsimSecim" AutoPostBack="true" runat="server" Width="200px" Font-Bold="true" Font-Size="X-Large" Height="40px" ForeColor="#ff3300" style="position:absolute; bottom:600px; left:570px;"></asp:DropDownList>



                <asp:Label runat="server" ID="TapuKacinciSahip" Text="Kaçıncı Sahibi:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:520px; left:700px;"></asp:Label>
                <asp:Label runat="server" ID="TapuEdinmeYolu" Text="Tapuyu Edinme Yolu:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:420px; left:700px;"></asp:Label>
                <asp:Label runat="server" ID="TapuEdinmeNedeni" Text="Tapuyu Edinme Nedeni:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:320px; left:700px;"></asp:Label>
                <asp:Label runat="server" ID="TapuEdinmeTarihi" Text="Tapuyu Edinme Tarihi:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:220px; left:700px;"></asp:Label>
                <asp:DropDownList runat="server" ID="TapuKacinciSahipText" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Width="200px" Height="40px" style="position:absolute; bottom:520px; left:970px;" AutoPostBack="true"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="TapuEdinmeYoluSecim" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Width="300px" Height="40px" style="position:absolute; bottom:420px; left:970px;"></asp:DropDownList>
                <asp:TextBox runat="server" ID="TapuEdinmeNedeniText" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Width="200px" Height="40px" style="position:absolute; bottom:320px; left:970px;"></asp:TextBox>
                <asp:DropDownList runat="server" ID="TapuEdinmeTarihiYıl" AutoPostBack="true" Width="100px" Font-Bold="true" Font-Size="X-Large" Height="40px" ForeColor="#ff3300" style="position:absolute; bottom:220px; left:970px;"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="TapuEdinmeTarihiAy" AutoPostBack="true" Width="50px" Font-Bold="true" Font-Size="X-Large" Height="40px" ForeColor="#ff3300" style="position:absolute; bottom:220px; left:1080px;"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="TapuEdinmeTarihiGün" AutoPostBack="true" Width="50px" Font-Bold="true" Font-Size="X-Large" Height="40px" ForeColor="#ff3300" style="position:absolute; bottom:220px; left:1140px;"></asp:DropDownList>


                <asp:ImageButton runat="server" BorderStyle="None" ID="GeriDön" Width="100px" Height="100px" ImageUrl="~/TapuSistem/geridön.png" style="position:absolute; left:-20px; bottom:620px;" />
                <asp:Button runat="server" Text="Tapu Edinme Bilgi Girişi İçin Tıklayın" BackColor="White" BorderStyle="None" ForeColor="Red" Font-Bold="true" Font-Size="Large" style="position:absolute; bottom:680px; left:1200px;"/>
                <asp:Button runat="server" ID="TapuBilgileriGöster" Text="Tapu Bilgilerini Göster" BackColor="White" BorderStyle="None" ForeColor="Red" Font-Bold="true" Font-Size="Large" style="position:absolute; bottom:630px; left:1200px;"/>
     
            </table>
        </div>
    </form>
</body>
</html>
