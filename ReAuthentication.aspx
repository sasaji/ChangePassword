<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReAuthentication.aspx.cs" Inherits="ChangePassword.ReAuthentication" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title />
  </head>
  <body>
    <form id="form1" runat="server">
      <div>
        <asp:Label ID="lblMessage1" runat="server" Font-Size="Small" Text="ＫＫＫＫＫＫＫＫ１０ＫＫＫＫＫＫＫＫ２０ＫＫＫＫＫＫＫＫ３０ＫＫＫＫＫＫＫＫ４０" />
        <br />
        <asp:Label ID="lblMessage2" runat="server" Font-Size="Small" Text="ＫＫＫＫＫＫＫＫ１０ＫＫＫＫＫＫＫＫ２０ＫＫＫＫＫＫＫＫ３０ＫＫＫＫＫＫＫＫ４０" />
        <br />
        <br />
        <asp:Panel ID="pnSharePoint" runat="server" style="margin-left:100px; margin-bottom:10px;" Visible="False">
          <asp:HyperLink ID="hlSharePoint" runat="server" Target="_top"/>
        </asp:Panel>
        <asp:Panel ID="pnPhoneBook" runat="server" style="margin-left:100px;" Visible="False">
          <asp:HyperLink ID="hlPhoneBook" runat="server" Target="_top" />
        </asp:Panel>
      </div>
    </form>
  </body>
</html>
