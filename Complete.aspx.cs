using System;
using System.Web.UI;

namespace ChangePassword
{
    public partial class Complete : Page
    {
        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // 固定メッセージセット
            this.lblMessage1.Text = DisplayMessage.Comp_M001;
            this.lblMessage2.Text = DisplayMessage.Comp_M002;
            if (Settings.IsTopPageAvailable) {
                this.pnSharePoint.Visible = true;
                this.hlSharePoint.NavigateUrl = Settings.TopPageUrl;
                this.hlSharePoint.Text = string.IsNullOrEmpty(Settings.TopPageText) ? "知マケPLUSトップへ" : Settings.TopPageText;
            }
            if (Settings.IsPhoneBookAvailable) {
                this.pnPhoneBook.Visible = true;
                this.hlPhoneBook.NavigateUrl = Settings.PhoneBookUrl;
                this.hlPhoneBook.Text = string.IsNullOrEmpty(Settings.PhoneBookText) ? "電話帳トップへ" : Settings.PhoneBookText;
            }
        }
    }
}