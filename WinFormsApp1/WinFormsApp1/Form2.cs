using crypto;
using Microsoft.Azure.Devices.Shared;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {

        string publicKey = "MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE1xXlCuiA+bkx01DliS5mupd67B+PDtA9xu4k2/NWzdYELomCW7fh53PRRK2A6E+KxHSsQS1XdhwG03BJ4uaWfw==";

        string privateKey = "MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQg0Hq41lUPPRmbGP1AxRyZnBPZ5wwoTqV9XXapYTFIJiGgCgYIKoZIzj0DAQehRANCAATXFeUK6ID5uTHTUOWJLma6l3rsH48O0D3G7iTb81bN1gQuiYJbt+Hnc9FErYDoT4rEdKxBLVd2HAbTcEni5pZ/";
        public Form2()
        {
            InitializeComponent();
        }

        public string ReadPublic()
        {
            var result = publicKey;
            result = result
                   .Replace("-----BEGIN PUBLIC KEY-----", "")
                                   .Replace("-----END PUBLIC KEY-----", "")
                                   .Replace("\n", "")
                                   .Replace("\r", "")
                                   .Trim();

            return result;

        }

        public string ReadPrivate()
        {
            var result = publicKey;
            result = result
                   .Replace("-----BEGIN EC PRIVATE KEY-----", "")
                                   .Replace("-----END EC PRIVATE KEY-----", "")
                                   .Replace("\n", "")
                                   .Replace("\r", "")
                                   .Trim();

            return result;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //string publicKeyFile = "public_key.pem";
            //string privateKeyFile = "private_key.pem";
            //GenerateAndSaveKeyPair(publicKeyFile, privateKeyFile);

            AsymmetricCipherKeyPair keyPair = LoadPrivateKey();

            // Encriptar el texto plano
            byte[] signature = SignData(Encoding.UTF8.GetBytes("123456"), keyPair);

            // Convertir la firma en base64 para visualización
            string base64Signature = Convert.ToBase64String(signature);
            Console.WriteLine("Firma: " + base64Signature);
        }


        public void GenerateAndSaveKeyPair(string publicKeyFile, string privateKeyFile)
        {
            AsymmetricCipherKeyPair keyPair = GenerateKeyPair();

            // Guardar clave pública en un archivo
            AsymmetricKeyParameter publicKey = keyPair.Public;
            SaveKeyToFile(publicKeyFile, publicKey);

            // Guardar clave privada en un archivo
            AsymmetricKeyParameter privateKey = keyPair.Private;
            SaveKeyToFile(privateKeyFile, privateKey);
        }

        private void SaveKeyToFile(string fileName, AsymmetricKeyParameter key)
        {
            using (TextWriter tw = new StreamWriter(fileName))
            {
                PemWriter pemWriter = new PemWriter(tw);
                pemWriter.WriteObject(key);
            }
        }
        public AsymmetricCipherKeyPair GenerateKeyPair()
        {
            //InitializeBouncyCastle();

            string curveName = "secp256r1"; // Esta es la curva más común, pero puedes cambiarla si lo deseas

            X9ECParameters ecp = SecNamedCurves.GetByName(curveName);
            ECDomainParameters ecSpec = new ECDomainParameters(ecp.Curve, ecp.G, ecp.N, ecp.H, ecp.GetSeed());
            ECKeyGenerationParameters ecgp = new ECKeyGenerationParameters(ecSpec, new SecureRandom());
            ECKeyPairGenerator gen = new ECKeyPairGenerator("ECDSA");
            gen.Init(ecgp);
            return gen.GenerateKeyPair();
        }

        public static string EncryptWithPublicKey(string text, AsymmetricKeyParameter publicKey)
        {
            byte[] plaintext = Encoding.UTF8.GetBytes(text);
            IBufferedCipher cipher = CipherUtilities.GetCipher("ECIES");
            cipher.Init(true, publicKey);
            byte[] ciphertext = cipher.DoFinal(plaintext);
            return Convert.ToBase64String(ciphertext);
        }

        public  string DecryptWithPrivateKey(string encryptedData, AsymmetricKeyParameter privateKey)
        {
            byte[] ciphertext = Convert.FromBase64String(encryptedData);
            IBufferedCipher cipher = CipherUtilities.GetCipher("ECIES");
            cipher.Init(false, privateKey);
            byte[] plaintext = cipher.DoFinal(ciphertext);
            return Encoding.UTF8.GetString(plaintext);
        }

        //public  string DecryptWithPrivateKey(string encryptedData, AsymmetricKeyParameter privateKey)
        //{
        //    byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

        //    IesEngine engine = new IesEngine(new DHBasicKeyPairGenerator(), new EphemeralKeyPairGenerator(), new Kdf2BytesGenerator(new Sha1Digest()));
        //    engine.Init(false, privateKey, null);

        //    byte[] decryptedBytes = engine.ProcessBlock(encryptedBytes, 0, encryptedBytes.Length);

        //    return Encoding.UTF8.GetString(decryptedBytes);
        //}

        // Método para cargar la llave privada desde un string PEM
        private  AsymmetricCipherKeyPair LoadPrivateKey()
        {
            using (TextReader privateKeyReader = new StringReader(privateKey))
            {
                PemReader pemReader = new PemReader(privateKeyReader);
                return (AsymmetricCipherKeyPair)pemReader.ReadObject();
            }
        }

        // Método para firmar datos usando la llave privada
        private static byte[] SignData(byte[] data, AsymmetricCipherKeyPair keyPair)
        {
            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA");
            signer.Init(true, keyPair.Private);
            signer.BlockUpdate(data, 0, data.Length);
            return signer.GenerateSignature();
        }

        //public  AsymmetricKeyParameter LoadPublicKeyFromString(string publicKeyString)
        //{
        //    byte[] publicKeyBytes = Convert.FromBase64String(publicKeyString);
        //    return PublicKeyFactory.CreateKey(publicKeyBytes);
        //}

        public AsymmetricKeyParameter LoadPublicKeyFromString()
        {
            using (TextReader publicKeyTextReader = new StringReader(publicKey))
            {
                PemReader pemReader = new PemReader(publicKeyTextReader);
                AsymmetricKeyParameter keyParameter = (AsymmetricKeyParameter)pemReader.ReadObject();
                return keyParameter;
            }
        }

        //private static void InitializeBouncyCastle()
        //{
        //    var provider = SecurityProvider.GetProvider("BC");
        //    if (provider == null)
        //    {
        //        SecurityProvider.AddProvider(new BouncyCastleProvider());
        //    }
        //}
    }
}
