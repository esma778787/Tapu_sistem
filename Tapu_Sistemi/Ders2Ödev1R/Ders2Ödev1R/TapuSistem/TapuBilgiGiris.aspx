<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TapuBilgiGiris.aspx.cs" Inherits="Ders2Ödev1R.TapuBilgiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position:relative; height:700px; width:1000px;">
            <table>
                 <asp:Label runat="server" ID="TapuBilgi" Text="Tapu Bilgileri" Font-Underline="true" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:600px; left:650px;"></asp:Label>
                 <asp:Label runat="server" ID="Tapuİsmi" Text="Tapu İsmi:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:500px; left:500px;"></asp:Label>
                 <asp:Label runat="server" ID="TapuParsel" Text="Tapu Parsel Sayısı:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:400px; left:500px;"></asp:Label>
                 <asp:Label runat="server" ID="TapuEdinilmeMiktar" Text="Tapu Edinilme Miktarı:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:300px; left:500px;"></asp:Label>
                 <asp:Label runat="server" ID="TapuİlkEdinmeTarih" Text="Tapu İlk EdinmeTarih:" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" style="position:absolute; bottom:200px; left:500px;"></asp:Label>
                 <asp:TextBox runat="server" ID="TapuİsmiText" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Width="200px" Height="40px" style="position:absolute; bottom:500px; left:750px;"></asp:TextBox>
                 <asp:TextBox runat="server" ID="TapuParselText" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Width="200px" Height="40px" style="position:absolute; bottom:400px; left:750px;"></asp:TextBox>
                 <asp:TextBox runat="server" ID="TapuEdinilmeMiktarText" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" Font-Bold="true" Font-Size="X-Large" ForeColor="#ff3300" Width="200px" Height="40px" style="position:absolute; bottom:300px; left:750px;"></asp:TextBox>
                 <asp:DropDownList runat="server" ID="TapuİlkEdinmeTarihYıl" AutoPostBack="true" Width="100px" Font-Bold="true" Font-Size="X-Large" Height="40px" ForeColor="#ff3300" style="position:absolute; bottom:200px; left:750px;"></asp:DropDownList>
                 <asp:DropDownList runat="server" ID="TapuİlkEdinmeTarihAy" AutoPostBack="true"  Width="50px" Font-Bold="true" Font-Size="X-Large" Height="40px" ForeColor="#ff3300" style="position:absolute; bottom:200px; left:860px;"></asp:DropDownList>
                 <asp:DropDownList runat="server" ID="TapuİlkEdinmeTarihGün" AutoPostBack="true" Width="50px" Font-Bold="true" Font-Size="X-Large" Height="40px" ForeColor="#ff3300" style="position:absolute; bottom:200px; left:920px;"></asp:DropDownList>
                 <asp:Button runat="server" ID="TapuBilgiOnay" Width="150px" Height="40px" BorderStyle="Outset" BorderColor="#ff3300" BackColor="Black" ForeColor="Red" Font-Bold="true" Text="Onayla" Font-Size="X-Large" style="position:absolute; bottom:100px; left:650px;" />
                


            </table>
        </div>
    </form>
</body>
</html>
