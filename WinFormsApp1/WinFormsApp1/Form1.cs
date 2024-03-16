using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //HOLDMAN
        string PUBLICKEY = @"MIIEIjANBgkqhkiG9w0BAQEFAAOCBA8AMIIECgKCBAEAzftJzjI9UwatX8piW0NASZmsOQkwjwFclfWD4l3KaDvPeHAGiXPypIjOHnWoVx7utoPyzLj/gZ5t6OLcp1DC0aO2AioNHj242jEeQkVxYAAANvYVD1N4Pz3M/jI8lONSnPzGWLyD/rjnhhZ2RlggyvMomneYKtrs2litBdU7CRZ2cxkSVY/TtVqIuE8+ZwvUPiuF4Fe8KIZkZdna9n8+S9YkDiM2CybPqVSIDrH0cRNZHa+FZGgG/m5JnQ6WEG6V201xtyuJGVsQQM+9FwRjy73lfEsZ9BkcW3jJ7Z9TQBZUUXSX6AUwpae8NQ0IMRHiuP5qHHCMnTwdh5jq3FpyDGNxCvJsc3wgeBU0opaRsS8NtT6AgMF2epEC4Stwtr5vaX6recSWMWOB9hdq47TmHr2eCLyWCOKMmZEHnXPxualekXbl1PjGdNHXhoKHiKqsYyqiYl9XywU/otS6nnSYwid7R8d0KQWZsJrnL9y0jxZWebEt3uyP7Amt54Fi3P7bpY/gPqqGUuvnQ25j+4M4CVqgJqFfrQ/FKJfLfRmHHtwopO8Osb0uS8UFDrx4/Kn/DMsN5IY1a+eWdCAcKNOHAMDyzYtnn1E/yrLGXMNlWKgwQTNEszftPwfti8EGOp7aRJmGfNPmoY13f1vsUu7tlXtDQ20N1K7jM4c+sIHmM7YI2QvhhXCaRmV9qFuQD8jr9F0Cz6lRTW5jWxGrPEHfMDFWVbnpEhkaNVvSpAPPtIBUMvTv19sf5heryDEj+CmwZ+nev4bu4+CTTC4sjYWBP5mKgr3wMEb23DSa+IniAQwo3Ev5LLk+9krIdAICOXTE67SJuut/z4MuOjtTN04yn2IcBkd1dsofzBAoBLsZdevpTFdxgQzr1Ij9bvutbR4HL1SZJfXh2ryYXC9UkL9Z7nxjnWL4cKRnLD4T2SSMdPT3NSsjWsFHVOTMLIcc4U8Khm+HX5fxeb3x7/zDd9P0uq9y5PdgwUoaQ99ZI9Ef/beFBfQjoc2AuddX1faWaBy+dC7feUUNmgp1HT2TEiHgCjwLl8nPmrZDzl2mw6WZ+FKohODBXx6UMwb8uPHOg0BGTpEz9DmzuyZjOVqi8iP+MgYHc1QLw9P7RIklCT6bLoH0DROyYQ8lkHwtcjkmcHZbzkjTpz6+GqcIuZQRbFqgEWf9Fmgzh76VB73abO4MJX5FWA7v1y7LALlrPueeDdJ8cbhl7VdvrudLkVyrONUbBLCxnf0mnyRrcZL8tpiZQ5d3gfqq2M1GH58iSleAnP8rrSJkKRB1QDHxZXmSdsfwbIKdYfDRJaq6Xwkm/MsqDNLdKjkHeLNpbqfjgJAb9QHbN/eqoeEU3rSUDT3j/mJfbQIDAQAB";

        //LUIS
        string PUBLICKEY2 = @"MIIECgKCBAEAzY1g0R57d8lnhRJqBeOatR+xb6piy3llSC041OLqYGVrikBBj7zY\nP8tD+PBLiyPoJZXSN9kwjTlMd2aGmtXon/cHrXLZ0nVuF6yf934qN8JaSoyBhIaZ\nCOuJVyeccNje5pMQTH187KOLTuK1I543xIZ2suN4fEIiNvIorCcHLvlYaNdvfu25\ncd3b91IgOTQhAg+zzLPsIeINCdWNUXLfqFtfavfgtHSYghz88F1mWdwglLJGzArA\nS6LFGmniTdjG7CHg9HFb9Qli0b/UbjGQiw0+STi10f4YhZ1HuGEyCPeJORadKvhy\nxSKhbQq6lhaOqFr2zi7YOtoryQgGWt6m3akquvpcRQXe7T1t+/fpTuXsA4VexMLH\nuT1EK7z31uEtcsTIU3eUd2WfncEpF+wDvs34wdEJU767ZiD3qOC/BLiCMtsrIYDj\nNvxJdHLXvB7Qln7xqKqMwbxFmImkkJuUWdg+9nMhcgBWeHPoKFQctVyS0O6s869k\n0kJWuE8XaYQ8F61PcNskuoY4Zs6iN5vfp3x5bUxRifmMDh/HZWboTWPbWZjmA/dj\n0l1Kp6gK/WaxxC7IYJM7xD9AAIqH9Zr+7uuwEBTs9S1SLk6vwnd2qP2sKS/Vlc22\nXEm0Q1wlTAJUE0mROaiA4rVV2Slu1EpXJwPS9RIooPudMo80BeiL1zb5/yfcbtHq\naw2sVRz8AC/uavEOfD9VROE8BfIHjL6vNVBXFCBivZ+TEeMTOeziI35xm3Gm9SRo\nYxz2zP+4q89v4ONuqEmwyuxklES5Qd0Zy1szo59732uVWCNZLpMhHP00wM7ZztGb\ngPeniCeaDVHPNiD2dhrPNbwpPNH80ZCHshaiYPtdAtta3PewmwyrnowQAzgxwL8r\nSR/XQKPBFF5SMhXLRQBJFqIbiCkCAg5w0JwzT6rKhvFKjOOTbNneJNhhekcPA/+x\nDCwFogCcEwnSF35Z3PvDQExpjecNKXn6KDHdwfZeQfVKPmOt5zKkNt8lf13OKCKD\nJ8IIQV7saUMz4zaSf12XLZJWH2f+T9O5LGvN7fagiOHRgewABs/bgN6bbDKj5AOS\nDafp8DWcyGlSl4eIvQekBuSSuUK7lfm4gSli+T5CR7y1u2yw/G74v6I6qHqspg+i\n77k+VlGTDSvZwpXXwOckUDxQXdwDjAXViOkemEyWQvI+lGBO8FbiweO3j1UaO8xO\nXO5FWC+8DLkAd6UUz18BHvCDnc9PZ8h+NhF6y5dvVFUWbC/TKP9lstpr97SP/ptz\nQfjZkCIFG60xlsznO3EDzqnZ4ADJfYRQ69lrWrbgfNS+A7NjyzbYHX0TRNPvLAQF\nBhrIwu8UmmvdUMY4RHS88QFikp2CXCN3VQIDAQAB";

        //******************************************************
        string PUBLICKEY3 = @"MIIEIjANBgkqhkiG9w0BAQEFAAOCBA8AMIIECgKCBAEAxRjtbOggFH9iJpa6Qgpbgfoqoz5mlnmtn1t5HhbKgpU0f6DZvWsphcmhleyVSUNc6Yfej2vpII6sysp9f0i1SJIW5gqtxcMTejOVkvopQLhrEBDlPb+V7DtK/Sl/bTNYwC3ru+2tY6HAMF5ylCDwGpkCO/XeuFaUvJoQF+99XqV1ynRhQlIC2PRVNfVTcZNDhuh8hZ1PDZnDJpz1B1VESMae1B7iZgJ+dqM+7qzwdPFJbi3ad4GIYnWKKcXDqzB7ZGH3+VM77J1jY0tamxY4kr76agk/L9uOootoyYWwSsT//cM5hjbAWRR+1y0j/9yvGosU/SJgwlntjV5x6pYIdZXYHF8qY2pVXZBZKxEp+uRUNbwO5rKmmB/ITy8UQn6RIUiltH2DNmiXt3NRn9vElqDnAbtB6qZIq1ZefU0hwTy25prcnOBZLsclqYHkJeQFPkH/H9ftj4zaSq7bPSXe7Xn6aCOVxvqr/orXgkJCgBkWAHNdrA5kSd/bC4vGLcm3+7ZnSeesQNG+lNElfUT4byaMN2tLCuhKzKwcOENl27/wbfabpdTIN2/orvK+yocT5AboKO0F4hMqM9m9gawVH8JdIxO2J3zc6M3S2QoLySij8QEb+uvNtuNbsuPY0618jmxXae4LM+WKtc/3ZMaUPS9RGZull89Dinc4X24SEPBDdgviZr16y6bXo9RB0QNKhiVmj+XcGKfM5t8w0qgmqpGeW0ZYMhn+oOr/pxBsWGSvd/oY5nx4VJnef/fVjnGxoaqnfjdmLRA6C35YyubrzTDPf9kIBA7DRh1Tm3On1yNHQKwyNs81tYUyOdacdoxpdNfHCoaTXWc1juY183FUZ1sPMp2ezeXIgQ9HcTvhVn7rhRHdn6JwrYj3CrDZeaLXMz0HearRwmUEHVUSPy9Cl8TEJt9g3LXf83nsl+7Dn3AhySeWKDbySUObr3OkmaBsxfpGsapu1zj91Tc8IdQgjz8m+G1K0uZyf11EzFTsYHvc/YpN3bIjvBh/pVui+AGwtNozy4uvz65SJUq1g4fAd1GmF6d20SstIuHRFZd66WOVvBboeUJKPpSmrTcDotMoEGEedx+SymVhHcWQlksiq/r3ifFq4tVs7CGrexj4wW4FacUVCL17fhsSU1grZJPq5x0xtlk4mlpqYe+ZcQbOlT6l3E3stJFwd4ao8VKlM3fHZZEf3Vb4E0DygB846O1/ggc9xgGkhewIvDqn2jYVUP7QV7aiKrUSVU21hzLLLL3dw7edHpKYsrgJtm25NzzXdgIHmsyK6XjFZJSbDJEsa/c5v71wQYzRZvbgFTaVP+ekqjX+6lvMx0w0cK/Guwf70ifjygRl83F3H3yTHraoRQIDAQAB";

        string PRIVATEKEY3 = @"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";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = SetCreatePerson();
            var pwCreatePersonEncrypted = EncryptObject5<PWCreatePersonRequestDto>(model);
            //var str = SetPWRetrievePersonByDocument();
            //var pwCreatePersonEncrypted = EncryptObject5<PWRetrievePersonByDocumentRequestDto>(str);
            richTextBox1.Text = pwCreatePersonEncrypted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var k = ImportPublicKey();
        }

        //NUEVO ENCRIPTAR
        private void button3_Click(object sender, EventArgs e)
        {
            var model = CrearJsonData();
            var pwCreatePersonEncrypted = EncrypData<JsonData>(model);

            //var model = SetCreatePerson();
            //var pwCreatePersonEncrypted = EncryptObject5<PWCreatePersonRequestDto>(model);
            richTextBox1.Text = pwCreatePersonEncrypted;
        }

        public string ReadPublicKey()
        {
            var result = PUBLICKEY2;
            result = result
                   .Replace("-----BEGIN PUBLIC KEY-----", "")
                                   .Replace("-----END PUBLIC KEY-----", "")
                                   .Replace("\n", "")
                                   .Replace("\r", "")
                                   .Trim();

            return result;

        }

        public string EncrypData<T>(T model)
        {
            // Cargar la clave pública desde el archivo
            string publicKeyBase64 = ReadPublicKey();
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyBase64);

            // Cargar la cadena JSON a cifrar
            string jsonData = JsonConvert.SerializeObject(model);

            //  string jsonData = "HOLA MUNDO";

            // Cifrar la cadena JSON utilizando la clave pública
            byte[] encryptedData;
            using (var rsa = RSA.Create())
            {
                rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
                encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(jsonData), RSAEncryptionPadding.Pkcs1);
            }

            // Convertir los datos cifrados a formato Base64
            string encryptedDataBase64 = Convert.ToBase64String(encryptedData);

            return encryptedDataBase64;
        }

        public string ReadPrivateKey()
        {
            var result = PRIVATEKEY3;
            result = result
                   .Replace("-----BEGIN PRIVATE KEY-----", "")
                                   .Replace("-----END PRIVATE KEY-----", "")
                                   .Replace("\n", "")
                                   .Replace("\r", "")
                                   .Trim();

            return result;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var encryptedDataBase64 = richTextBox1.Text.Trim();
           // var encryptedDataBase64 = @"gruxXGZ9R4Gyo4EXNXo1OZt65/HqtrzAQgCk+OTcok2aT4eGf3TNVqwxDD68sjq0CyOkKa72KYQmR2SFCibwbD3cWC6PNsAOcWbfWz5N2CYisbNa4Cysm8nVA4jP3gqTrWfxqAOTmh/PhzyQ/+36i07HzWa104Yx+Iu2oa1GzmR7sBu64qZ0f8BQqWLuKZF6uA+/KG9woZ7p7+MiCCGbqiKancvvJCzTjg9TLs/LUMMLh0zBdBMC0gQm3oo4u1ER2POWMP6GHouVKqFGf2KDYu2uG5tRmUXBQSlbXBMT8mNJWCMVGXnWrA4vARUtYUrH2HrEkZTdrXondBA6H08u87VZ4WSYDq8QdqgP4Ve0YxVGF9X5tvtEe2r0568bEyMkOOrCgIZvCSAt2x9lqtxi001if+tHqGs2A13F8iPV3hVuVgU/B5f1Ud8C/CKm1aoXZ/5No2ZRKRfE52//Hlz3DPrS4QHUq1VBayPrvZNpc25MXHkGx5Zh/UvvZGKfkn77dYFTljx04fPQnLCFihASHancTABqRnA9nJwm0PqVWTXC9MmXYZPOVPfREZ7+JfZAXAUb3CQQemco99QR57WbrFmr2tUIStZdqzf7gksXdoJXofA2r6CeOTfvxrQIrU+0XK98HaZu3urrSV0F6gyzd/0ZhvHmu2mBve3sH6Lq/+OnZSt7Urtoou9FlMwiFhnI3wNWTscqdPGdckQYQ3YfYZNHW9nZgSXk20tnkBi5G7eDkriVIEXKhzKCZz1gew4gdSQjF99P8Rit0c7muBZUNV5V4dumiQ9BSOGwK9OXX8cOGP+ua1kVa1T07QPyVYCKG6yXS6c7rGTrjkbXnWHbjzqFTPdcNsyjAh7H0FbOncb5xHPp2tQHGhLOJCwnooj5hAeDI6BWiqfocvFJGxms/2tozTd0wWRr6PCkUDF+c6soUWqHgqPlcN3dgGVOl5qAxn0RLHYZKZVtuJURVBk74n0St+Qz5bewUjr35zZQ/TjF9YngQX7zaM+ELdC8hqyBCTDzsvfgLAeTGHLAdoDzpGg6O1dOE0aoHplAItT7IkWm8XHFfusYNLEW/NqkLrbMDD0VdlVE0ftQY1Pxn8epZTir3cj+xYx02hyymro4+rFG6niJc5Cl2sSLE2edTxyPd9mHVtGALlI15htGIj11fwNApLJUuAavKxWHXN9jc+qI+6QKEGiKHkiQAgLJ6e4OwUItFwCpmBFUUrLGjca50Fr/8Mmnqo2bK5f7Ch5/n/qRC4NMTlbHHMhpibWSW9XpKDiCeuufq1/qomy2ezJERx2sMCMWuS2IIJcip0hDHECPa/YeYFBOg9bzigEV0pNHvprIPlKkNIEoW7YuaoQwYg==";
            var model = DecryptData<JsonData>(encryptedDataBase64);
            richTextBox1.Text = JsonConvert.SerializeObject(model);
            //Decrypted();
        }

        public void Decrypted()
        {
            var bytesToDecrypt = Convert.FromBase64String("gruxXGZ9R4Gyo4EXNXo1OZt65/HqtrzAQgCk+OTcok2aT4eGf3TNVqwxDD68sjq0CyOkKa72KYQmR2SFCibwbD3cWC6PNsAOcWbfWz5N2CYisbNa4Cysm8nVA4jP3gqTrWfxqAOTmh/PhzyQ/+36i07HzWa104Yx+Iu2oa1GzmR7sBu64qZ0f8BQqWLuKZF6uA+/KG9woZ7p7+MiCCGbqiKancvvJCzTjg9TLs/LUMMLh0zBdBMC0gQm3oo4u1ER2POWMP6GHouVKqFGf2KDYu2uG5tRmUXBQSlbXBMT8mNJWCMVGXnWrA4vARUtYUrH2HrEkZTdrXondBA6H08u87VZ4WSYDq8QdqgP4Ve0YxVGF9X5tvtEe2r0568bEyMkOOrCgIZvCSAt2x9lqtxi001if+tHqGs2A13F8iPV3hVuVgU/B5f1Ud8C/CKm1aoXZ/5No2ZRKRfE52//Hlz3DPrS4QHUq1VBayPrvZNpc25MXHkGx5Zh/UvvZGKfkn77dYFTljx04fPQnLCFihASHancTABqRnA9nJwm0PqVWTXC9MmXYZPOVPfREZ7+JfZAXAUb3CQQemco99QR57WbrFmr2tUIStZdqzf7gksXdoJXofA2r6CeOTfvxrQIrU+0XK98HaZu3urrSV0F6gyzd/0ZhvHmu2mBve3sH6Lq/+OnZSt7Urtoou9FlMwiFhnI3wNWTscqdPGdckQYQ3YfYZNHW9nZgSXk20tnkBi5G7eDkriVIEXKhzKCZz1gew4gdSQjF99P8Rit0c7muBZUNV5V4dumiQ9BSOGwK9OXX8cOGP+ua1kVa1T07QPyVYCKG6yXS6c7rGTrjkbXnWHbjzqFTPdcNsyjAh7H0FbOncb5xHPp2tQHGhLOJCwnooj5hAeDI6BWiqfocvFJGxms/2tozTd0wWRr6PCkUDF+c6soUWqHgqPlcN3dgGVOl5qAxn0RLHYZKZVtuJURVBk74n0St+Qz5bewUjr35zZQ/TjF9YngQX7zaM+ELdC8hqyBCTDzsvfgLAeTGHLAdoDzpGg6O1dOE0aoHplAItT7IkWm8XHFfusYNLEW/NqkLrbMDD0VdlVE0ftQY1Pxn8epZTir3cj+xYx02hyymro4+rFG6niJc5Cl2sSLE2edTxyPd9mHVtGALlI15htGIj11fwNApLJUuAavKxWHXN9jc+qI+6QKEGiKHkiQAgLJ6e4OwUItFwCpmBFUUrLGjca50Fr/8Mmnqo2bK5f7Ch5/n/qRC4NMTlbHHMhpibWSW9XpKDiCeuufq1/qomy2ezJERx2sMCMWuS2IIJcip0hDHECPa/YeYFBOg9bzigEV0pNHvprIPlKkNIEoW7YuaoQwYg=="); // string to decrypt, base64 encoded

            AsymmetricCipherKeyPair keyPair;

            using (var reader = File.OpenText(@"C:/Users/DELL/source/repos/WinFormsApp1/WinFormsApp1/bin/Debug/net6.0-windows/private_key.pem")) // file containing RSA PKCS1 private key
                keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();

            var decryptEngine = new Pkcs1Encoding(new RsaEngine());
            decryptEngine.Init(false, keyPair.Private);

            var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
        }

        public T DecryptData<T>(string encryptedDataBase64)
        {
            // Cargar la clave privada desde el archivo (o desde donde la tengas almacenada)
            string privateKeyBase64 = ReadPrivateKey();
            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyBase64);

            // Decodificar los datos encriptados desde Base64
            byte[] encryptedData = Convert.FromBase64String(encryptedDataBase64);

            // Desencriptar los datos utilizando la clave privada
            string decryptedData = string.Empty;
            using (var rsa = RSA.Create(8192))
            {
                rsa.ImportRSAPrivateKey(privateKeyBytes, out _);
                byte[] decryptedBytes = rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);
                decryptedData = Encoding.UTF8.GetString(decryptedBytes);
            }

            // Convertir la cadena JSON desencriptada de nuevo al tipo T
            T result = JsonConvert.DeserializeObject<T>(decryptedData);
            return result;
        }

        public string ReadFileKeyPem2()
        {
            var result = PUBLICKEY;
            result = result
                    .Replace("-----BEGIN PRIVATE KEY-----", "")
                    .Replace("-----END PRIVATE KEY-----", "")
                     //.Replace("\r\n", "")
                     //.Replace(" ", "");
                     .Replace("\n", "")
                     .Replace("n\"", "")
                     .Trim();
            return result;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CrearRSA();
        }

        public void CrearRSA()
        {
            using (var rsa = RSA.Create(8192))
            {
                // Obtener la clave pública y privada en formato byte[]
                byte[] publicKeyBytes = rsa.ExportSubjectPublicKeyInfo(); // Clave pública
                byte[] privateKeyBytes = rsa.ExportPkcs8PrivateKey(); // Clave privada

                // Convertir las claves a formato Base64
                string publicKeyBase64 = Convert.ToBase64String(publicKeyBytes);
                string privateKeyBase64 = Convert.ToBase64String(privateKeyBytes);

                // Guardar las claves en archivos
                File.WriteAllText("public_key.pem", "-----BEGIN PUBLIC KEY-----\n" + publicKeyBase64 + "\n-----END PUBLIC KEY-----");
                File.WriteAllText("private_key.pem", "-----BEGIN PRIVATE KEY-----\n" + privateKeyBase64 + "\n-----END PRIVATE KEY-----");

                Console.WriteLine("Claves generadas y guardadas correctamente.");
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            Encriptacion();
        }


        public void Encriptacion()
        {
            // Clave pública en formato PEM
            string publicKeyPEM = @"-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAv8s+Wo4CE7kcEjxeLi5r
EyiqHRwMtKWu+lNCvJpFSGDfM33G9KlNxOpHmiuAOSG3XZLSjhXTQRyq9SM/TjiD
3JoWpmMyQRNUXymYLtkHZ92a3ypkXnRBMGB/TknO80e5d6sANwBBcTn7DigcFS4b
pmkcZUithzuCCRpndNT6r1q5DxwDf4YiBApWFBhWBDJR0PZY/h8oAK4E8nBMqLTS
CFY7lJ+U2s2EGtiUgUmS9/7HcuG+4t7knfQvOAB1UZDA2kFDM9eMDC2sICfBA665
rItK2iwBCvWcvC6kQXpJ5sakpyrd1SzjoMqKZy8+yTyDKQpWKTCn/AzVAkRfhrpM
NwIDAQAB
-----END PUBLIC KEY-----";

            // Convierte la clave pública de formato PEM a RSAParameters
            RSAParameters publicKeyParams = GetRSAParametersFromPublicKeyPEM(publicKeyPEM);

            // JSON a encriptar
            string textoPlano = "{\"form_id\":240,\"terminal_id\":294,\"idperson\":\"378\",\"amount\":\"10000\",\"external_order\":\"RT0018\",\"ip\":\"162.228.107.210\",\"additionalData\":\"\",\"currencycode\":\"COP\"}";

            // Firma digital del JSON
            string signature = SignData(textoPlano, publicKeyParams);

            Console.WriteLine("Firma Digital: " + signature);
        }

        public RSAParameters GetRSAParametersFromPublicKeyPEM(string publicKeyPEM)
        {
            var base64Key = publicKeyPEM
                .Replace("-----BEGIN PUBLIC KEY-----", "")
                .Replace("-----END PUBLIC KEY-----", "")
                .Replace("\n", "");

            var keyBytes = Convert.FromBase64String(base64Key);
            var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(keyBytes, out _);
            return rsa.ExportParameters(false);
        }

        // Método para firmar digitalmente los datos con la clave pública
        public string SignData(string data, RSAParameters publicKeyParams)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKeyParams);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] signatureBytes = rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return Convert.ToBase64String(signatureBytes);
            }
        }




        public string EncryptObject<T>(T obj)
        {
            var publicKeyBase64 = ReadPublicKey();

            using (var rsa = RSA.Create())
            {
                // Importar clave pública desde Base64
                rsa.ImportFromPem(publicKeyBase64);

                // Serializar el objeto a JSON
                var jsonData = JsonConvert.SerializeObject(obj);

                // Encriptar los datos utilizando RSA
                byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(jsonData), RSAEncryptionPadding.OaepSHA256);

                // Convertir datos encriptados a Base64
                return Convert.ToBase64String(encryptedData);
            }
        }


        public string EncryptObject2<T>(T obj)
        {
            var publicKey = ReadPublicKey();

            var jsonData = JsonConvert.SerializeObject(obj);
            byte[] jsonDataBytes = Encoding.UTF8.GetBytes(jsonData);

            RSA rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);
            var xmlString = rsa.ToXmlString(false);
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlString);
            var result = provider.Encrypt(Encoding.Default.GetBytes(jsonData), false);
            return Convert.ToBase64String(result);
        }
        public string EncryptObject3<T>(T obj)
        {
            var publicKey = ReadPublicKey();

            var jsonData = JsonConvert.SerializeObject(obj);
            byte[] jsonDataBytes = Encoding.UTF8.GetBytes(jsonData);

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(publicKey);

                // Encrypt data using RSA
                byte[] encryptedData = rsa.Encrypt(jsonDataBytes, RSAEncryptionPadding.OaepSHA256);

                return Convert.ToBase64String(encryptedData);
            }
        }

        public string EncryptObject4<T>(T obj)
        {
            var pemKey = PUBLICKEY;
            var plainText = JsonConvert.SerializeObject(obj);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (StringReader stringReader = new StringReader(pemKey))
            {
                PemReader pr = new PemReader(stringReader);
                RsaKeyParameters keys = (RsaKeyParameters)pr.ReadObject();

                // PKCS1 OAEP paddings
                OaepEncoding eng = new OaepEncoding(new RsaEngine());
                eng.Init(true, keys);

                int length = plainTextBytes.Length;
                int blockSize = eng.GetInputBlockSize();
                List<byte> cipherTextBytes = new List<byte>();
                for (int chunkPosition = 0; chunkPosition < length; chunkPosition += blockSize)
                {
                    int chunkSize = Math.Min(blockSize, length - chunkPosition);
                    cipherTextBytes.AddRange(eng.ProcessBlock(plainTextBytes, chunkPosition, chunkSize));
                }
                return Convert.ToBase64String(cipherTextBytes.ToArray());
            }
        }


        public string EncryptObject5<T>(T obj)
        {
            byte[] publicKeyData = GetPublicKeyFromString();
            var plainText = JsonConvert.SerializeObject(obj);
            byte[] encryptedData = EncryptStringWithRSA(plainText, publicKeyData);
            string encryptedString = Convert.ToBase64String(encryptedData);

            return encryptedString;
        }

        public byte[] GetPublicKeyFromString()
        {
            string keyString = PUBLICKEY
                .Replace("-----BEGIN PUBLIC KEY-----", "")
                .Replace("-----END PUBLIC KEY-----", "")
                .Replace("\n", "")
                .Replace("n\"", "")
                .Trim();

            byte[] publicKeyData = Convert.FromBase64String(keyString);

            return publicKeyData;
        }

        static byte[] EncryptStringWithRSA(string originalString, byte[] publicKey)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(originalString);

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportSubjectPublicKeyInfo(publicKey, out _);

                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256); // Utiliza OaepSHA256 como relleno

                return encryptedData;
            }
        }

        public string EncryptObject6<T>(T obj)
        {
            byte[] publicKeyData = GetPublicKeyFromString();
            var plainText = JsonConvert.SerializeObject(obj);

            // Dividir la cadena en bloques de un tamaño manejable
            int blockSize = 100; // Tamaño del bloque en caracteres
            List<string> chunks = new List<string>();
            for (int i = 0; i < plainText.Length; i += blockSize)
            {
                chunks.Add(plainText.Substring(i, Math.Min(blockSize, plainText.Length - i)));
            }

            // Cifrar cada bloque individualmente
            List<byte[]> encryptedChunks = new List<byte[]>();
            foreach (var chunk in chunks)
            {
                byte[] encryptedData = EncryptStringWithRSA(chunk, publicKeyData);
                encryptedChunks.Add(encryptedData);
            }

            // Concatenar los datos cifrados de cada bloque
            List<byte> encryptedBytes = new List<byte>();
            foreach (var chunk in encryptedChunks)
            {
                encryptedBytes.AddRange(chunk);
            }

            string encryptedString = Convert.ToBase64String(encryptedBytes.ToArray());

            return encryptedString;
        }

        public RSACryptoServiceProvider ImportPublicKey()
        {
            PemReader pr = new PemReader(new StringReader(PUBLICKEY));
            AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKey);

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();// cspParams);
            csp.ImportParameters(rsaParams);
            return csp;
        }




        public static PWCreatePersonRequestDto SetCreatePerson()
        {
            var createPerson = new PWCreatePersonRequestDto()
            {
                firstname = "John",
                lastname = "Doel",
                ididentificationtype = "4",
                identification = "499887766554433221",
                email = "john25675@example.com",
                phone = "113456789022",
                state = "",
                city = "",
                address = "",
                zipcode = ""
            };

            return createPerson;
        }

        public static PWRetrievePersonByDocumentRequestDto SetPWRetrievePersonByDocument()
        {
            var nroDocument = new PWRetrievePersonByDocumentRequestDto()
            {
                nroDocumento = "2233445566778899"
            };

            return nroDocument;
        }

        public class PWCreatePersonRequestDto
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string ididentificationtype { get; set; }
            public string identification { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string address { get; set; }
            public string zipcode { get; set; }
        }

        public class PWRetrievePersonByDocumentRequestDto
        {
            public string nroDocumento { get; set; }
        }

        public static JsonData CrearJsonData()
        {
            return new JsonData
            {
                FirmwareMobil = "a-c457bfa098992f12",
                Data = new CustomerData
                {
                    ContactDetail = new ContactDetail
                    {
                        Email = "efrain.mejias@vettica.co",
                        MobilePhoneNumber = "4654658788"
                    },
                    PersonalData = new PersonalData
                    {
                        FirstName = "efrq",
                        FirstSurname = "Mmeller",
                        BirthDate = new DateTime(1972, 8, 2),
                        PoliticallyExposedPerson = true
                    }
                },
                TermsCondition = new TermsCondition
                {
                    ProductTerms = new ProductTerms
                    {
                        Version = "1",
                        Acceptance = true
                    },
                    ClausesCustomer = new ClausesCustomer
                    {
                        Version = "1",
                        Acceptance = true
                    },
                    WalletTerms = new WalletTerms
                    {
                        Version = "1",
                        Acceptance = true
                    }
                },
                Security = new Security
                {
                    EnrollmentKey = "yBLW1aVToelcK9EKH/OMzOx2L6ZG3iLIRFQRNgMZKJ8/eat3SDoN8vnIfCiQcodPNV+4tsc5XheD2KK+cbN4+a5eTiY2qNLc3Bg6ibjWitWUz1d6/c48t++khEmRSqn19DJB7aTnUb7ydECCki3YQkoO43t/2ujQWvTbkTIAopJzTjOOpqEbUdmLEoIEC0oVei8jtLhibiBaDJpSEcdvTGVd/bdsI9bpolBqHXD+mjjK9RBAkhhhr0UaMTB7305+vMsVyy/lXY3H9dqNWXAXxxmwx49tKBwyH+WMDGTolMwE0"
                }
            };
        }

     
    }
}
