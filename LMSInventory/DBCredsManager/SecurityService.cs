using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBCredsManager
{
    class SecurityService
    {

        // Returns CipherText of DB Password and Tag
        public static (string, string) EncryptDBCreds(string plainText, string email, string contact, string location)
        {
            byte[] palinTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] emailBytes = Encoding.UTF8.GetBytes(email);
            byte[] associatedBytes = Encoding.UTF8.GetBytes(location);
            byte[] contactBytes = Encoding.UTF8.GetBytes(contact);

            // Key will be Email, 
            // Nonce will be Contact
            // Associated Data will be Location
            List<byte> key = new();
            List<byte> nonce = new();

            // Key has to be 32-byte
            if (emailBytes.Length < 32)
            {
                key = new List<byte>(emailBytes);
                key = PadByteArray(emailBytes, key, 32);
            }
            else
            {
                key = new List<byte>(emailBytes);
            }

            // nonce has to be 12-byte
            if (contactBytes.Length < 12)
            {
                nonce = new List<byte>(contactBytes);
                nonce = PadByteArray(contactBytes, nonce, 12);
            }
            else
            {
                nonce = new List<byte>(contactBytes);
            }

            // AESGCM Encryption
            var encryptedPair = AESGCMEncrypt(palinTextBytes, key.ToArray(), nonce.ToArray(), associatedBytes);

            // Getting CipherText and Tag
            string cipherText = Convert.ToBase64String(encryptedPair.Item1);
            string tagText = Convert.ToBase64String(encryptedPair.Item2);

            return (cipherText, tagText);
        }

        // Padds a Byte Array to the Target Length
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

        // Method for AESGCM Encryption
        // Returns CipherText and Tag
        private static (byte[], byte[]) AESGCMEncrypt(byte[] plainText, byte[] key, byte[] nonce, byte[] assocData)
        {
            byte[] tag = new byte[16];
            byte[] cypherText = new byte[plainText.Length];

            using AesGcm aesGcm = new AesGcm(key);
            aesGcm.Encrypt(nonce, plainText, cypherText, tag, assocData);

            return (cypherText, tag);
        }

    }
}
