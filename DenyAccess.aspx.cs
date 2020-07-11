using System;
using System.Web.UI;

namespace ChangePassword
{
    public partial class DenyAccess : Page
    {
        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // 固定メッセージセット
            this.lblMessage.Text = DisplayMessage.Deny_M001;
        }
    }
}