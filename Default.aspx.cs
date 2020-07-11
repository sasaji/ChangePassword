using System;
using System.DirectoryServices;
using System.Web.UI;

namespace ChangePassword
{
    public partial class Default : Page
    {
        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // リファラーチェック。
            //ValidateReferer();
            // 初期メッセージセット
            this.lblMessage.Text = DisplayMessage.Check_M001;
            // ユーザー名フォーカス
            this.txtUserName.Focus();
        }

        /// <summary>
        /// 「次へ」ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Next_Click(object sender, EventArgs e)
        {
            // 接続ドメイン取得
            string domainName = Settings.DomainName;
            // ドメインユーザの状態を保持
            Attempter attempter = new Attempter(domainName, txtUserName.Text, txtPassword.Text);

            // ドメインに接続できない場合/ログイン可能の場合/ 要パスワード変更の場合/パスワード不正の場合
            if (!IsConnectable(domainName)) {
                // ドメイン接続エラーメッセージ表示
                this.lblMessage.Text = DisplayMessage.Check_M003;
            } else if (attempter.CanSignIn) {
                // 再認証誘導画面へ遷移
                Response.Redirect("ReAuthentication.aspx");
            } else if (attempter.MustChangePassword) {
                // パスワード変更画面へ遷移
                Session["UserName"] = this.txtUserName.Text;
                Response.Redirect("ChangePassword.aspx");
            } else if (attempter.IsLockedOut) {
                this.lblMessage.Text = DisplayMessage.Check_M004;
            } else {
                // パスワード不正メッセージ表示
                this.lblMessage.Text = DisplayMessage.Check_M002;
            }
        }

        /// <summary>
        /// ドメイン接続可否
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        protected bool IsConnectable(string domain)
        {
            try {
                // ドメインコントローラーを指定して rootDSE に接続してみる。
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain + "/rootDSE");
                // 名前が取得できたらそのドメインコントローラーを返す。
                string name = entry.Name;
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// リファラーチェック
        /// </summary>
        private void ValidateReferer()
        {
            // リファラーがないアクセスは拒否する。
            if (Request.UrlReferrer == null)
                Response.Redirect("DenyAccess.aspx");

            // クエリストリングが付いていたら外す。
            string requestReferer = Request.UrlReferrer.AbsoluteUri.ToLower();
            int queryStringPosition = requestReferer.IndexOf('?');
            if (queryStringPosition >= 0) requestReferer = requestReferer.Substring(0, requestReferer.IndexOf('?'));

            // 設定ファイルにリファラーがない場合もアクセスを拒否する。
            string referers = Settings.Referers;
            if (string.IsNullOrEmpty(referers))
                Response.Redirect("DenyAccess.aspx");

            // 設定ファイルのリファラーのいずれかとリファラーが前方一致していたら OK。
            foreach (string referer in referers.Split(new string[] { "||" }, StringSplitOptions.None)) {
                if (requestReferer.StartsWith(referer.ToLower())) return;
            }

            // 一致しているものがなかったのでアクセスを拒否する。
            Response.Redirect("DenyAccess.aspx");
        }
    }
}
