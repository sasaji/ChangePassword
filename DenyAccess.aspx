<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DenyAccess.aspx.cs" Inherits="ChangePassword.DenyAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="lblDenyAccess" runat="server" Font-Size="X-Large" Font-Bold="true" Text="アクセス拒否" />
                <br />
                <br />
                <asp:Label ID="lblMessage" runat="server" Font-Size="Small" Text="ＫＫＫＫＫＫＫＫ１０ＫＫＫＫＫＫＫＫ２０" />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnClose" runat="server" Height="30" Width="50" Font-Size="Smaller" OnClientClick="window.close();" style="left:110px; position:absolute;" Text="閉じる" />
            </div>
        </form>
    </body>
</html>
