<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaypalAccess.aspx.cs" Inherits="BootstrapMVC.PaypalAccess"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    </form>

</body>
</html>
