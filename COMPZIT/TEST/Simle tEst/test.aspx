<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="TEST_Simle_tEst_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <form id="form1" runat="server">
        <div>
           
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
        </div>
    </form>
</body>
</html>
