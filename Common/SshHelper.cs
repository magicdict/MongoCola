using Renci.SshNet;

namespace Common
{
    public class SshHelper
    {
        /// <summary>
        ///     GetSshClient
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static SshClient GetSshClient(string host, string username, string password)
        {
            SshClient client = new SshClient(host, username, password);
            return client;
        }

        /// <summary>
        ///     GetSshClient
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="ppkFilename"></param>
        /// <returns></returns>
        public static SshClient GetSshClient(string host, string username, string password, string ppkFilename)
        {
            PrivateKeyFile ppkFile = new PrivateKeyFile(ppkFilename);
            SshClient client = new SshClient(host, username, new PrivateKeyFile[] { ppkFile });
            return client;
        }
    }
}
