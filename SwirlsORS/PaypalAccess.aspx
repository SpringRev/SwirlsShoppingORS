<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaypalAccess.aspx.cs" Inherits="BootstrapMVC.PaypalAccess" Trace="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #btnEncrypt {
            width: 70px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>


           
           
            </div>
            <asp:Button ID="btnSortMe" runat="server" Text="SortMe" OnClick="btnSortMe_Click" />

            <br />
        <br />
            <asp:Button ID="btnPaypal" runat="server" Text="Paypal" OnClick="btnPaypal_Click" />
        <asp:Button ID="btnFunc" runat="server" Text="Func" OnClick="btnFunc_Click" />

            <br />

            <asp:DataList ID="sortedList" runat="server" AlternatingItemStyle-BackColor="Yellow"></asp:DataList>

        <section>
                <input type="text" id="txtEncrypt" name="txtEncrypt" value="revathis" />                <%--<input type="button" id="btnEncrypt" name="btnEncrypt" runat="server" value="Encrypt" />--%>
                 <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" />

        </section>
         <section>
                <%--<input type="button" id="btnEncrypt" name="btnEncrypt" runat="server" value="Encrypt" />--%>
                 <asp:Button ID="btnUnhandledException" runat="server" Text="Test Unhandled Exception" OnClick="btnUnhandledException_Click" />

        </section>
        
        <section>
                <%--<input type="button" id="btnEncrypt" name="btnEncrypt" runat="server" value="Encrypt" />--%>
                 <asp:Button ID="btnLambdaSamples" runat="server" Text="LambdaSamples" OnClick="btnLambdaSamples_Click"/>

        </section>
        <asp:DataList ID="dlProduct" runat="server" OnLoad="dlProduct_Load" BorderWidth="2" RepeatColumns="2" RepeatDirection="Vertical"  >
                <ItemTemplate>
                        <div style="padding:15,15,15,15;font-size:10pt;
                        font-family:Verdana">
                        <div style="font:12pt verdana;color:darkred">
                           <i><b><%# DataBinder.Eval(Container.DataItem, "Name")%> 
                           </i></b>
                        </div>
                        <br>
                        <b>Price: </b>
                        <%# DataBinder.Eval(Container.DataItem, "Price") %><br>
                       
                        <p>
                     </div>

                </ItemTemplate>
        </asp:DataList>
    </form>

</body>
</html>
