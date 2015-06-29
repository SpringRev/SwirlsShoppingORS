<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="BootstrapMVC.SignIn" Trace="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="Titles/Create" method="post">
    <div>
        <label>UserName</label> 
        <input type="text" name="txtUserName" />
        <input type="text" name="vasanth" />
        <br />
         <label>Password</label> 
        <input type="password"  name="txtPassword" />
        <br />
        <input id="btnSubmit" " type="submit" value="Submit"/>
     
    </div>
    </form>
</body>
</html>
