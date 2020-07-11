<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ChangePassword.ChangePassword" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:mso="urn:schemas-microsoft-com:office:office" xmlns:msdt="uuid:C2F41010-65B3-11d1-A29F-00AA00C14882">
  <head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  </head>
  <body>
    <form id="form1" runat="server">
      <div>
        <asp:Label ID="lblChangePassword" runat="server" Font-Size="X-Large" Font-Bold="true" Text="パスワード変更" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Size="Small" ForeColor="#ff0000" Text="ＫＫＫＫＫＫＫＫ１０ＫＫＫＫＫＫＫＫ２０" />
        <br />
        <br />
        <br />
        <asp:Panel ID="pnlUserName" runat="server" HorizontalAlign="Left">
          <asp:Label ID="lblUserName" runat="server" Font-Size="Medium" style="left:5px; position:absolute;" Text="ユーザー名：" />
          <asp:Label ID="lblDispUserName" runat="server" Width="100" Font-Size="Medium"  style="left:230px; position:absolute;" Text="bpr\AXXXXXXX" />        
        </asp:Panel>
        <asp:Panel ID="pnlDummy1" runat="server" Height="30"></asp:Panel>
        <asp:Panel ID="pnlNewPassword" runat="server" HorizontalAlign="Left">
          <asp:Label ID="lblNewPassword" runat="server" Font-Size="Medium" style="left:5px; position:absolute;" Text="新しいパスワード：" />
          <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Font-Size="Medium" style="left:230px; position:absolute;" Width="150" />
        </asp:Panel>
        <asp:Panel ID="pnlDummy2" runat="server" Height="30"></asp:Panel>
        <asp:Panel ID="pnlNewPasswordCertificate" runat="server" HorizontalAlign="Left">
          <asp:Label ID="lblNewPasswordCertificate" runat="server" Font-Size="Medium" style="left:5px; position:absolute;" Text="新しいパスワードの確認入力：" />
          <asp:TextBox ID="txtNewPasswordCertificate" runat="server" TextMode="Password" Font-Size="Medium" style="left:230px; position:absolute;" Width="150" />
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnlDummy3" runat="server" Height="20">
          <asp:Button ID="btnNext" runat="server" Height="30" Width="50" Font-Size="Smaller" style="left:110px; position:absolute;" OnClick="Next_Click"  Text="次へ" />
          <asp:Button ID="btnClose" runat="server" Height="30" Width="50" Font-Size="Smaller" style="left:230px; position:absolute;" OnClientClick="window.close();" Text="閉じる" />
        </asp:Panel>
      </div>
    </form>
  </body>
</html>
