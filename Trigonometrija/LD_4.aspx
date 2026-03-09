<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LD_4.aspx.cs" Inherits="Trigonometrija.App_Code.LD_4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Apskaičiuoti" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Stačiakampiai kurių viduje yra viena trikampio viršūnė:"></asp:Label>
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Stačiakampiai kurių viduje yra po vieną trikampį:"></asp:Label>
        <asp:GridView ID="GridView4" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Surastas didžiausias stačiakampis ir trikampis:"></asp:Label>
        <asp:GridView ID="GridView5" runat="server">
        </asp:GridView>
        <asp:TextBox ID="TextBox1" runat="server" Width="184px">Kokį trikampį panaikinti</asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Panaikinti" OnClick="Button2_Click"/>
        <br />
    </form>
</body>
</html>
