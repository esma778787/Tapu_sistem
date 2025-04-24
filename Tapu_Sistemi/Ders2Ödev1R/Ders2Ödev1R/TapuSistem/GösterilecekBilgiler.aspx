<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GösterilecekBilgiler.aspx.cs" Inherits="Ders2Ödev1R.TapuSistem.GösterilecekBilgiler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position:relative; height:700px; width:1000px;">
            
            <asp:GridView runat="server" ID="GrdTapuİsimParsel" AutoGenerateColumns="true" style="position:absolute; bottom:500px; left:270px;"></asp:GridView>
            <asp:GridView runat="server" ID="GrdTapuBilgi" AutoGenerateColumns="true" style="position:absolute; bottom:100px; left:270px;"></asp:GridView>
        </div>
    </form>
</body>
</html>
