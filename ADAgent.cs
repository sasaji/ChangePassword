using System;
using System.DirectoryServices;
using System.Reflection;

namespace ChangePassword
{
    /// <summary>
    /// ADとの処理を請け負うクラス
    /// </summary>
    public class ADAgent
    {
        /// <summary>
        /// パスワードを変更します。
        /// パスワードの有効期限が切れているユーザーのパスワードも変更されます。
        /// 次回ログオン時にパスワード変更が必要なユーザーのパスワードも変更されます。
        /// 無効なユーザーのパスワードも変更されます。
        /// アカウントの有効期限が切れているユーザーのパスワードも変更されます。
        /// </summary>
        /// <param name="userName">ユーザー名</param>
        /// <param name="domain">ドメイン</param>
        /// <param name="newPassword">新しいパスワード</param>
        /// <returns>パスワード変更結果</returns>
        public int ChangePassword(string userName, string newPassword)
        {
            try {
                this.ResetPassword(newPassword, GetUserDN(userName));
                return 0;
            } catch (TargetInvocationException tex) {
                // InnerExeption の HResult が "サーバーがプロセスを実行しようとしません。 (HRESULT からの例外: 0x80072035)"
                // の場合はパスワードポリシーの要件を満たしていないとみなす。
                if (tex.InnerException != null) {
                    try {
                        int hResult = Convert.ToInt32(typeof(Exception).InvokeMember("HResult",
                            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty,
                            null, tex.InnerException, null, System.Globalization.CultureInfo.InvariantCulture));
                        if ((uint)hResult == 0x800708C5)
                            return 1;
                    } catch {
                        return 2;
                    }
                }
                return 2;
            } catch (Exception ex) {
                return 2;
            } finally {
            }
        }

        /// <summary>
        /// 更新対象ユーザーオブジェクトディレクトリの識別名を取得します。
        /// </summary>
        /// <param name="userName">更新対象ユーザーのアカウント名</param>
        /// <returns>更新対象ユーザーオブジェクトディレクトリの識別名</returns>
        private string GetUserDN(string userName)
        {
            var rootDN = this.GetRootDN();
            if (string.IsNullOrEmpty(rootDN)) {
                return string.Empty;
            }
            using (var entry = this.GetDirectoryEntry(rootDN)) {
                using (var directorySearcher = new DirectorySearcher(entry, String.Format("(sAMAccountName={0})", userName))) {
                    var searchResult = directorySearcher.FindOne();
                    if (searchResult == null) {
                        return string.Empty;
                    }
                    using (var userEntry = searchResult.GetDirectoryEntry()) {
                        return (string)userEntry.Properties["distinguishedName"].Value;
                    }
                }
            }
        }

        /// <summary>
        /// ルートディレクトリの識別名を取得
        /// </summary>
        /// <returns>ルートディレクトリの識別名</returns>
        private string GetRootDN()
        {
            var rootDN = string.Empty;
            using (var rootEntry = this.GetDirectoryEntry("RootDSE")) {
                rootDN = (string)rootEntry.Properties["defaultNamingContext"].Value;
            }
            return rootDN;
        }

        /// <summary>
        /// 指定されたディレクトリオブジェクトのインスタンスを取得
        /// </summary>
        /// <param name="path">ディレクトリオブジェクトのパス</param>
        /// <returns>指定されたディレクトリオブジェクトのインスタンス</returns>
        private DirectoryEntry GetDirectoryEntry(string path)
        {
            return new DirectoryEntry("LDAP://" + path);
        }

        /// <summary>
        /// 新しいパスワードでパスワードをリセット
        /// </summary>
        /// <param name="connection">LDAP接続</param>
        /// <param name="newPassword">新しいパスワード</param>
        /// <param name="ldapPath">変更対象ユーザーのLDAPパス</param>
        private void ResetPassword(string password, string ldapPath)
        {
            DirectoryEntry userEntry = new DirectoryEntry("LDAP://" + ldapPath);
            userEntry.Invoke("SetPassword", password);
            userEntry.Properties["pwdLastSet"].Value = -1;
            userEntry.CommitChanges();
            userEntry.RefreshCache();
        }
    }
}