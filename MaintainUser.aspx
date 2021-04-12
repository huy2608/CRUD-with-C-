<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainUser.aspx.cs" Inherits="CRUDWebForm.MaintainUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        :<asp:TextBox ID="txtUsername" runat="server" Height="22px" style="margin-left: 12px" Width="150px"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            :<asp:TextBox ID="txtPassword" runat="server" Height="22px" style="margin-left: 11px" Width="150px"></asp:TextBox>
        </p>
        Full name:<asp:TextBox ID="txtFullname" runat="server" Height="22px" style="margin-left: 12px" Width="150px"></asp:TextBox>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Phone"></asp:Label>
            :<asp:TextBox ID="txtPhone" runat="server" Height="22px" style="margin-left: 31px" Width="150px"></asp:TextBox>
        </p>
        Role:<asp:TextBox ID="txtRole" runat="server" Height="22px" style="margin-left: 43px" Width="150px"></asp:TextBox>
        <asp:GridView ID="gvUserInfoList" runat="server" AutoGenerateSelectButton="True" Height="175px" OnSelectedIndexChanging="gvUserInfoList_SelectedIndexChanged" style="margin-top: 30px" Width="230px">
        </asp:GridView>
        <asp:Button ID="addButton" runat="server" Height="25px" OnClick="Button1_Click" Text="Add" />
        <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="Update" />
        <asp:Button ID="deleteButton" runat="server" OnClick="deleteButton_Click" Text="Delete" />
    </form>
</body>
</html>
