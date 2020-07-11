using System;
using System.Web.UI;

namespace ChangePassword
{
    public partial class ChangePassword : Page
    {
        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // セッション情報のユーザー名を保持
            string userName = (string)Session["UserName"];
            // セッション情報が存在しない場合、不正アクセスと判断
            if (string.IsNullOrEmpty(userName)) {
                Response.Redirect("DenyAccess.aspx");
            }
            // 初期メッセージは空をセット
            this.lblMessage.Text = string.Empty;
            // 引き継がれたユーザー名をセット
            this.lblDispUserName.Text = userName;
            // 新しいパスワードフォーカス
            this.txtNewPassword.Focus();
        }

        /// <summary>
        /// 「次へ」ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Next_Click(object sender, EventArgs e)
        {
            // 新しいパスワードが空の場合
            if (string.IsNullOrEmpty(this.txtNewPassword.Text)) {
                this.lblMessage.Text = DisplayMessage.Change_M004;
                return;
            }
            // 入力したパスワードが確認入力した値と一致しない場合
            if (this.txtNewPassword.Text != this.txtNewPasswordCertificate.Text) {
                this.lblMessage.Text = DisplayMessage.Change_M001;
                return;
            }
            // AD間処理用インスタンス
            ADAgent adagent = new ADAgent();
            // ドメイン名取得
            string domainName = Settings.DomainName;
            // パスワード変更処理
            int result = adagent.ChangePassword(this.lblDispUserName.Text, this.txtNewPassword.Text);

            if (result == 0) {
                // セッション情報をクリア
                Session.Clear();
                // 完了画面へ遷移
                Response.Redirect("Complete.aspx");
            } else if (result == 1) {
                // パスワードポリシー違反
                this.lblMessage.Text = DisplayMessage.Change_M003;
            } else {
                // 接続エラー
                this.lblMessage.Text = DisplayMessage.Change_M002;
            }
        }
    }
}