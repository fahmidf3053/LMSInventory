using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using LMS.API.Utils;

namespace LMS.API.BusinessLogicLayer.Services
{
    public class SecurityService
    {
        public static string CreateSecureDBConnectionString(string connectionString)
        {
            //Connection String format = "Data Source=xx.xx.xx.xx;Initial Catalog=IDTPServerDB;User ID=icpadmin;Password=EncryptedPass

            // Get all params in connection string separated by ';'
            string[] connStringValues = connectionString.Split(Constants.DatabaseUtils.SQLDB_CONNECTION_STRING_DELIMITER);

            // Get the cypher text and tag (together)
            string cipherTextAndTag = connStringValues[3].Substring(9, connStringValues[3].Length - 9);

            // Separate out cypher text and tag (separated by '||')
            string[] cipherTextTag = cipherTextAndTag.Split(Constants.VALUE_SEPARATOR);

            // Decrypt and get the plain text
            // Plain text = [DB User Password]
            string plainTextPassword = DecryptDBCreds(cipherTextTag[0], cipherTextTag[1], SecurityConstants.Email, SecurityConstants.Contact, SecurityConstants.Location);

            // Set the DB password 
            connStringValues[3] = connStringValues[3].Substring(0, 9); // First separate out the text 'password=', then concatenate the actual pass in the below line
            connStringValues[3] = string.Concat(connStringValues[3], plainTextPassword);

            var secureConnString = string.Join(Constants.DatabaseUtils.SQLDB_CONNECTION_STRING_DELIMITER, connStringValues);

            return secureConnString;
        }

        private static string DecryptDBCreds(string cipherText, string tagText, string email, string contact, string associatedData)
        {
            byte[] emailBytes = Encoding.UTF8.GetBytes(email);
            byte[] associatedDataBytes = Encoding.UTF8.GetBytes(associatedData);
            byte[] contactBytes = Encoding.UTF8.GetBytes(contact);

            byte[] cipherForDecrypt = Convert.FromBase64String(cipherText);
            byte[] tagForDecrypt = Convert.FromBase64String(tagText);

            List<byte> key = new();
            List<byte> nonce = new();

            if (emailBytes.Length < 32)
            {
                key = new List<byte>(emailBytes);
                key = PadByteArray(emailBytes, key, 32);
            }
            else
            {
                key = new List<byte>(emailBytes);
            }

            if (contactBytes.Length < 12)
            {
                nonce = new List<byte>(contactBytes);
                nonce = PadByteArray(contactBytes, nonce, 12);
            }
            else
            {
                nonce = new List<byte>(contactBytes);
            }

            var decryptedValue = Decrypt(cipherForDecrypt, key.ToArray(), nonce.ToArray(), tagForDecrypt, associatedDataBytes);

            string plaintext = Encoding.UTF8.GetString(decryptedValue);

            return plaintext;

        }

        private static List<byte> PadByteArray(byte[] sourceByteArray, List<byte> targetByteList, int targetLength)
        {
            int i = 0;
            while (targetByteList.Count < targetLength)
            {
                if (i == sourceByteArray.Length)
                    i = 0;

                targetByteList.Add(sourceByteArray[i]);
                i++;
            }
            return targetByteList;
        }

        private static byte[] Decrypt(byte[] cipherText, byte[] key, byte[] nonce, byte[] tag, byte[] assocData)
        {
            byte[] plainText = new byte[cipherText.Length];

            using AesGcm aesGcm = new AesGcm(key);
            aesGcm.Decrypt(nonce, cipherText, tag, plainText, assocData);

            return plainText;
        }
    }
}
