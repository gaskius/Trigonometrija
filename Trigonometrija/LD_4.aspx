<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LD_4.aspx.cs" 
    Inherits="Trigonometrija.App_Code.LD_4" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trigonometrijos LD4</title>
    <style>
        body { font-family: Calibri, sans-serif; padding: 20px; line-height: 1.4; }
        h2 { color: #333; border-bottom: 2px solid #ccc; padding-bottom: 5px; }
        .gv {
            border-collapse: collapse;
            margin: 10px 0 25px 0;
            font-size: 14px;
            min-width: 300px;
        }
        .gv th {
            background-color: #f0f0f0;
            color: #333;
            border: 1px solid #bbb;
            padding: 5px 12px;
            text-align: left;
        }
        .gv td {
            border: 1px solid #ccc;
            padding: 4px 12px;
        }
        .gv tr:hover { background-color: #f9f9f9; }
        
        .label-title { font-weight: bold; display: block;
                       margin-top: 15px; color: #444; }
        .result-msg { color: #0056b3; font-weight: bold; 
                      margin: 10px 0; display: block; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Pradiniai duomenys</h2>
            
            <asp:Label ID="Label6" runat="server" Text="Stačiakampiai:" 
                CssClass="label-title"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="false" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Pavadinimas" />
                    <asp:BoundField DataField="X1" HeaderText="X1" />
                    <asp:BoundField DataField="Y1" HeaderText="Y1" />
                    <asp:BoundField DataField="X2" HeaderText="X2" />
                    <asp:BoundField DataField="Y2" HeaderText="Y2" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="Label7" runat="server" Text="Trikampiai:" 
                CssClass="label-title"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" 
                CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Pavadinimas" />
                    <asp:BoundField DataField="X1" HeaderText="X1" />
                    <asp:BoundField DataField="Y1" HeaderText="Y1" />
                    <asp:BoundField DataField="X2" HeaderText="X2" />
                    <asp:BoundField DataField="Y2" HeaderText="Y2" />
                    <asp:BoundField DataField="X3" HeaderText="X3" />
                    <asp:BoundField DataField="Y3" HeaderText="Y3" />
                </Columns>
            </asp:GridView>
            
            <asp:Button ID="Button1" runat="server" Text="Apskaičiuoti" 
                OnClick="Button1_Click" />
            <br />

            <hr />

            <asp:Label ID="Label1" runat="server" Text=
                "a) Stačiakampiai, kurių viduje yra viena trikampio viršūnė:" 
                CssClass="label-title"></asp:Label>
            <asp:GridView ID="GridView3" runat="server" 
                AutoGenerateColumns="false" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="RectName" HeaderText="Stačiakampis"/>
                    <asp:BoundField DataField="TriName" HeaderText="Trikampis"/>
                    <asp:BoundField DataField="Description" HeaderText="Pastaba"/>
                </Columns>
            </asp:GridView>

            <asp:Label ID="Label2" runat="server" 
                Text="b) Stačiakampiai, kurių viduje yra visas trikampis:" 
                CssClass="label-title"></asp:Label>
            <asp:GridView ID="GridView4" runat="server" 
                AutoGenerateColumns="false" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="RectName" HeaderText="Stačiakampis"/>
                    <asp:BoundField DataField="TriName" HeaderText="Trikampis" />
                    <asp:BoundField DataField="Description" HeaderText="Pastaba" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="Label3" runat="server" 
                Text="c) Didžiausias stačiakampis ir trikampis:" 
                CssClass="label-title"></asp:Label>
            <asp:GridView ID="GridView5" runat="server" 
                AutoGenerateColumns="false" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Pavadinimas" />
                    <asp:BoundField DataField="Area" HeaderText="Plotas" 
                        DataFormatString="{0:F2}" />
                    <asp:BoundField DataField="Type" HeaderText="Tipas" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="Label4" runat="server" Text="Palyginimo rezultatas:" 
                CssClass="result-msg"></asp:Label>
            
            <hr />
            
            <div style="background-color: #fcfcfc; border: 1px solid #eee; 
                    padding: 15px; width: fit-content;">
                <asp:Label ID="Label5" runat="server" 
                    Text="Įveskite trikampio pavadinimą šalinimui:" 
                    Font-Size="Small"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" 
                    Width="180px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" 
                    Text="Panaikinti trikampį" OnClick="Button2_Click"/>
            </div>
        </div>
    </form>
</body>
</html>