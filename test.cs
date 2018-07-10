using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace AESFileEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.Key = Encoding.ASCII.GetBytes("s9puRS0$rng00as!");
            aes.IV = new byte[0x10];
            aes.Padding = PaddingMode.Zeros;
            aes.Mode = CipherMode.ECB;
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] data = Encoding.ASCII.GetBytes("This is a secret !");

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    string output = Convert.ToBase64String(ms.ToArray());
                    Debug.WriteLine(output);
                    File.WriteAllBytes(args[0], ms.ToArray());
                }
            }
        }
    }
}