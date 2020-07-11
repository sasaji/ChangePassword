using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ChangePassword
{
    /// <summary>
    /// ログオン情報を管理するクラス
    /// </summary>
    public class Attempter
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]

        // ログオンユーザー
        private extern static bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        //
        private const int LOGON32_PROVIDER_DEFAULT = 0;
        private const int LOGON32_LOGON_INTERACTIVE = 2;
        private const int LOGON32_LOGON_NETWORK = 3;

        // ログオン状態
        private enum Status
        {
            CorrectPassword = 0,
            PermissionDenied = 1385,
            PasswordExpired = 1330,
            PasswordMustChange = 1907,
            PasswordIncorrect = 1326,
            UserDisabled = 1331,
            UserExpired = 1793,
            UserLockedOut = 1909,
            Unknown = -1
        }
        // 状態に応じたメッセージを格納
        private Dictionary<Status, string> _messages = new Dictionary<Status, string>()
        {
            {Status.CorrectPassword, "正しいパスワードです。"},
            {Status.PermissionDenied, "正しいパスワードです。ログインする権限がありません。"},
            {Status.PasswordExpired, "パスワードの有効期限が切れています。"},
            {Status.PasswordMustChange, "次回ログオン時にパスワード変更が必要です。"},
            {Status.PasswordIncorrect, "現在のパスワードが間違っています。"},
            {Status.UserDisabled, "対象ユーザーは無効なユーザーです。"},
            {Status.UserExpired, "対象ユーザーの有効期間が切れています。"},
            {Status.UserLockedOut, "対象ユーザーはロックアウトされています。"},
            {Status.Unknown, "不明なエラーです。"}
        };
        // ログオン状態（返却用）
        private readonly Status _result;

        // ログオン可能状態プロパティ
        public bool CanSignIn { get { return _result == Status.CorrectPassword; } }
        // 要パスワード変更状態プロパティ
        public bool MustChangePassword { get { return (_result == Status.PasswordExpired || _result == Status.PasswordMustChange); } }
        // ロックアウト
        public bool IsLockedOut { get { return _result == Status.UserLockedOut; } }
        // 状態メッセージプロパティ
        public string ResultMessage { get { return _messages[_result]; } }

        /// <summary>
        /// Constructer
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public Attempter(string domain, string userName, string password)
        {
            IntPtr dupeTokenHandle = new IntPtr(0);
            IntPtr tokenHandle = IntPtr.Zero;

            bool returnValue = LogonUser(userName, domain, password, LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
            int result = Marshal.GetLastWin32Error();
            if (Enum.IsDefined(typeof(Status), result))
                _result = (Status)result;
            else
                _result = Status.Unknown;
        }
    }
}