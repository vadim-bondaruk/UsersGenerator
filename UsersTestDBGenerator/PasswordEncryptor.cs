/*
 * Created by SharpDevelop.
 * User: GVadmin
 * Date: 07.04.2017
 * Time: 12:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security.Cryptography;
using System.Text;

namespace UsersTestDBGenerator
{
	/// <summary>
	/// Description of PasswordEncryptor.
	/// </summary>
	public static class PasswordEncryptor
	{
		/// <summary>
        /// Convert string password to string sha1
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetHashString(string password)
        {
            var sb = new StringBuilder();
            foreach (byte b in GetHash(password))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convert string password to sha1 byte array
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static byte[] GetHash(string password)
        {
            var sha1 = SHA1.Create();
            return sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

	}
}
