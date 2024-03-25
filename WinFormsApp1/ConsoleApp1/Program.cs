using Newtonsoft.Json;
using System;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Escriba '1' para cifrar o '2' para descifrar: ");
        string option = Console.ReadLine();

        if (option == "1")
        {
            byte[] nonce = new byte[12];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(nonce);
            }

            byte[] key = Convert.FromBase64String("u4XhWFD0AaJ0NXDplaA6d1F3P3XjuPvVB7fq9BlSpAA=");

            using (var cipher = new AesGcm(key))
            {
                byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(@"{""Email"":""genowa1715@minhlun.com""}");
                byte[] ciphertext = new byte[plaintextBytes.Length];
                byte[] tag = new byte[16];

                cipher.Encrypt(nonce, plaintextBytes, ciphertext, tag);

                var encryptedData = new
                {
                    tag = Convert.ToBase64String(tag),
                    vi = Convert.ToBase64String(nonce),
                    dt = Convert.ToBase64String(ciphertext)
                };

                // Convertir el objeto a una cadena JSON
                string json = JsonConvert.SerializeObject(encryptedData);

                Console.WriteLine("Mensaje cifrado: " + json);

                Console.ReadKey();
            }
        }
        else if (option == "2")
        {
            //Console.Write("Ingrese el texto cifrado en base64: ");
            string yourBase64Ciphertext = @"+BDTZzrxkmWNTNhRAKl1vcEF+4xURA9jXtPB+zuLAr77Hhc2MihUN8RrOyALiotAlfKKPPVj0Sxnbuaql8GWsh1fKJe9E1yJ\/FrBjm2WEwxBug9Mz8Ml9RugargiOO7\/jHtD4yI4\/JlDqwNO6EXZquB9nhYWBe3yiqg9S";

            //Console.Write("Ingrese la clave en base64: ");
            string yourBase64Key = "u4XhWFD0AaJ0NXDplaA6d1F3P3XjuPvVB7fq9BlSpAA=";

            //Console.Write("Ingrese el nonce en base64: ");
            string yourBase64Nonce = "UDafAocDrG7rss+R";

            //Console.Write("Ingrese el tag en base64: ");
            string yourBase64Tag = "EaluNlbpnRz+Da1UWBS4Mw==";

            byte[] ciphertext = Convert.FromBase64String(yourBase64Ciphertext);
            byte[] key = Convert.FromBase64String(yourBase64Key);
            byte[] nonce = Convert.FromBase64String(yourBase64Nonce);
            byte[] tag = Convert.FromBase64String(yourBase64Tag);

            using (var cipher = new AesGcm(key))
            {
                byte[] plaintext = new byte[ciphertext.Length];

                cipher.Decrypt(nonce, ciphertext, tag, plaintext);

                Console.WriteLine("Mensaje descifrado: " + System.Text.Encoding.UTF8.GetString(plaintext));
            }

            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Opción inválida. Por favor, escriba '1' para cifrar o '2' para descifrar.");
        }

    }
}
