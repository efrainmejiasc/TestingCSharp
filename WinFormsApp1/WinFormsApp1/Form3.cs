using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Org.BouncyCastle.Utilities;


namespace WinFormsApp1
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        string key64 = "qmiVmjhHfNR+XfHtiPPIbtNLFGqlY+5q++SiFbCX5HM=";
        string iv64 = "QXNtQcemueTc549EopMU4g==";
        byte[] newIv;
        //GENERAR
        private void button4_Click(object sender, EventArgs e)
        {
            int keySize = 256; // Puedes elegir 128, 192 o 256 bits
            byte[] key = GenerateRandomKey(keySize);
            byte[] iv = Convert.FromBase64String(iv64);

            string keyFileName = "key.txt";
            string keyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, keyFileName);
            SaveKeyAndIVToFile(key, iv, keyFilePath);

            Console.WriteLine("Clave y IV generados y guardados en el archivo: " + keyFilePath);

            byte[] readKey;
            byte[] readIV;
            ReadKeyAndIVFromFile(keyFilePath, out readKey, out readIV);

            string base64Key = Convert.ToBase64String(readKey);
            string base64IV = Convert.ToBase64String(readIV);

            Console.WriteLine("Clave leída desde el archivo: " + base64Key);
            Console.WriteLine("IV leído desde el archivo: " + base64IV);
        }

        // ENCRIPTAR
        private void button3_Click(object sender, EventArgs e)
        {
            string keyString = key64;
            byte[] key = Convert.FromBase64String(keyString);
            newIv = GenerateRandomIV();
            byte[] iv = newIv;
            byte[] tag = new byte[32];

            string textoOriginal = richTextBox1.Text.Trim();

            string textoCifradoBase64 = Encrypt(textoOriginal, key, iv, out tag);
            var tag64 = Convert.ToBase64String(tag);
            var iv64 = Convert.ToBase64String(iv);

            richTextBox1.Text = textoCifradoBase64;
        }

        //DESENCRIPTAR
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] key = Convert.FromBase64String(key64);
            byte[] iv = newIv; // Genera un vector de inicialización aleatorio

            string textoDesencriptado = Decrypt(richTextBox1.Text.Trim(), key, iv);
            richTextBox1.Text = string.Empty;
            richTextBox1.Text = textoDesencriptado;
        }

        //public string Encrypt(string texto, byte[] key, byte[] iv)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = key;
        //        aesAlg.IV = iv; // Asigna el vector de inicialización
        //        aesAlg.Mode = CipherMode.CBC; // Utiliza el modo CBC
        //        aesAlg.Padding = PaddingMode.PKCS7;

        //        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //        using (MemoryStream msEncrypt = new MemoryStream())
        //        {
        //            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
        //                csEncrypt.Write(textoBytes, 0, textoBytes.Length);
        //            }
        //            byte[] encryptedBytes = msEncrypt.ToArray();
        //            return Convert.ToBase64String(encryptedBytes);
        //        }
        //    }
        //}

        public string Encrypt(string texto, byte[] key, byte[] iv, out byte[] tag)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                        csEncrypt.Write(textoBytes, 0, textoBytes.Length);
                    }

                    byte[] encryptedBytes = msEncrypt.ToArray();

                    // Calcula el HMAC del texto cifrado
                    using (HMACSHA256 hmac = new HMACSHA256(key))
                    {
                        tag = hmac.ComputeHash(encryptedBytes);
                    }

                    // Combina el texto cifrado con el tag
                    byte[] resultBytes = new byte[encryptedBytes.Length + tag.Length];
                    Buffer.BlockCopy(encryptedBytes, 0, resultBytes, 0, encryptedBytes.Length);
                    Buffer.BlockCopy(tag, 0, resultBytes, encryptedBytes.Length, tag.Length);

                    return Convert.ToBase64String(resultBytes);
                }
            }
        }

        //public static string Decrypt(string textoCifradoBase64, byte[] key, byte[] iv)
        //{
        //    byte[] textoCifradoBytes = Convert.FromBase64String(textoCifradoBase64);

        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = key;
        //        aesAlg.IV = iv;
        //        aesAlg.Mode = CipherMode.CBC;
        //        aesAlg.Padding = PaddingMode.PKCS7;

        //        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        //        using (MemoryStream msDecrypt = new MemoryStream(textoCifradoBytes))
        //        {
        //            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
        //                {
        //                    return srDecrypt.ReadToEnd().Trim();
        //                }
        //            }
        //        }
        //    }
        //}

        public string Decrypt(string textoCifradoBase64, byte[] key, byte[] iv)
        {
            byte[] encryptedBytesWithTag = Convert.FromBase64String(textoCifradoBase64);

            // Divide el texto cifrado y el tag
            int tagLength = 32; // Tamaño del tag HMAC SHA-256
            byte[] encryptedBytes = new byte[encryptedBytesWithTag.Length - tagLength];
            byte[] tag = new byte[tagLength];
            Buffer.BlockCopy(encryptedBytesWithTag, 0, encryptedBytes, 0, encryptedBytes.Length);
            Buffer.BlockCopy(encryptedBytesWithTag, encryptedBytes.Length, tag, 0, tag.Length);

            // Calcula el HMAC del texto cifrado
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] calculatedTag = hmac.ComputeHash(encryptedBytes);

                // Verifica si el tag es válido
                if (!ByteArraysEqual(tag, calculatedTag))
                {
                    throw new CryptographicException("Tag de verificación inválido. El texto cifrado puede haber sido alterado.");
                }
            }

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd().Trim();
                        }
                    }
                }
            }
        }

        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        public static byte[] GenerateRandomIV()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }
        public static byte[] GenerateRandomKey(int keySize)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.GenerateKey();
                return aes.Key;
            }
        }



        public static void SaveKeyAndIVToFile(byte[] key, byte[] iv, string filePath)
        {
            string base64Key = Convert.ToBase64String(key);
            string base64IV = Convert.ToBase64String(iv);

            string content = base64Key + Environment.NewLine + base64IV;
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        public static void ReadKeyAndIVFromFile(string filePath, out byte[] key, out byte[] iv)
        {
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            if (lines.Length >= 2)
            {
                key = Convert.FromBase64String(lines[0]);
                iv = Convert.FromBase64String(lines[1]);
            }
            else
            {
                throw new InvalidOperationException("El archivo de clave y IV no tiene el formato esperado.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int keySize = 256; // Puedes elegir 128, 192 o 256 bits
            byte[] key = GenerateRandomKey(keySize);
            byte[] iv = GenerateRandomIV();

            var propertySecurity = new PropertysSecurity()
            {
                SimetricKey = Convert.ToBase64String(key),
                ValidateTag = Convert.ToBase64String(iv)
            };

            var K = string.Empty;
        }

        public class PropertysSecurity
        {
            public string SimetricKey { get; set; }
            public string ValidateTag { get; set; }
        }
    }
}
