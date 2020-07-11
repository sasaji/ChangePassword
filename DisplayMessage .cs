namespace ChangePassword
{
    public class DisplayMessage
    {

        // パスワード確認画面用
        public const string Check_M001 = "パスワードの有効期限が切れているか、パスワードが間違っています。";
        public const string Check_M002 = "ユーザー名またはパスワードが間違っています。";
        public const string Check_M003 = "ただ今、システムに問題が発生し、お取り扱いできません。";
        public const string Check_M004 = "アカウントがロックされています。ロックが解除されるまでしばらくお待ちいただくか、パスワードの初期化を行ってください。";
        // パスワード変更画面用
        public const string Change_M001 = "入力されたパスワードが一致しません。";
        public const string Change_M002 = "ただ今、システムに問題が発生し、お取り扱いできません。";
        public const string Change_M003 = "入力されたパスワードがActive Directoryのパスワードポリシーに違反します。別のパスワードを入力してください。";
        public const string Change_M004 = "新しいパスワードを入力してください。";
        // 再認証誘導画面用
        public const string Reauth_M001 = "入力されたIDとパスワードは有効期限内で正しいものであることが確認できました。";
        public const string Reauth_M002 = "お手数ですが、以下のリンクをクリックし、再度、IDとパスワードを入力してください。";
        // 完了画面用
        public const string Comp_M001 = "パスワードの変更が完了しました。";
        public const string Comp_M002 = "以下のリンクをクリックし、設定したパスワードを入力してください。";
        // アクセス拒否画面用
        public const string Deny_M001 = "このページにはアクセスできません。";
    }
}