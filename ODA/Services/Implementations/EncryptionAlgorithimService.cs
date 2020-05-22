using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ODA.Services.Implementations
{
    public class EncryptionAlgorithimService : IEncryptionAlgorithimService
    {
        private string saltValue = Guid.NewGuid().ToString();
        private string hashAlgorithm = "SHA256"; // can be "MD5"
        private int passwordIterations = 2;
        private string initVector;
        private int keySize = 256;                // can be 192 or 128
        private string DefaultPassPhrase = "4a2b1aecd0a0917059c8b3c9e5f3bd6c";
        public EncryptionAlgorithimService()
        {   // can be any string
            saltValue = GetSaltValue();        // can be any string
            initVector = "!3S3e4M4n0T616g2"; // must be 16 bytes

        }

        private string GetSaltValue()
        {
            return string.Format("$salts.ODA.iH7G7igI8TGJHFHj98767GH87gBJK224.ODA.com$");
        }

        public string Encrypt(string data, string passPhrase)
        {
            if (string.IsNullOrWhiteSpace(passPhrase))
                passPhrase = DefaultPassPhrase;
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            // Convert our data into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(data);
            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );
            byte[] keyBytes = password.GetBytes(keySize / 8);
            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor
            (
                keyBytes,
                initVectorBytes
            );
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                encryptor,
                CryptoStreamMode.Write
            );
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }
        public string Decrypt(string data, string passPhrase)
        {
            if (string.IsNullOrWhiteSpace(passPhrase))
                passPhrase = DefaultPassPhrase;
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(data);
            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                passPhrase,
                saltValueBytes,
                hashAlgorithm,
                passwordIterations
            );

            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor
            (
                keyBytes,
                initVectorBytes
            );
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                decryptor,
                CryptoStreamMode.Read
            );
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read
            (
                plainTextBytes,
                0,
                plainTextBytes.Length
            );

            memoryStream.Close();
            cryptoStream.Close();
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString
            (
                plainTextBytes,
                0,
                decryptedByteCount
            );

            // Return decrypted string.   
            return plainText;
        }

    }
}
