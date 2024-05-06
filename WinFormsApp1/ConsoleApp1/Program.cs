using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;

public class Program
{
    public static async Task Main()
    {
        //Console.WriteLine("Escriba '1' para cifrar o '2' para descifrar: ");
        //string option = Console.ReadLine();

        //if (option == "1")
        //{
        //    byte[] nonce = new byte[12];
        //    using (var rng = new RNGCryptoServiceProvider())
        //    {
        //        rng.GetBytes(nonce);
        //    }

        //    byte[] key = Convert.FromBase64String("u4XhWFD0AaJ0NXDplaA6d1F3P3XjuPvVB7fq9BlSpAA=");

        //    using (var cipher = new AesGcm(key))
        //    {
        //        byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(@"{""Email"":""genowa1715@minhlun.com""}");
        //        byte[] ciphertext = new byte[plaintextBytes.Length];
        //        byte[] tag = new byte[16];

        //        cipher.Encrypt(nonce, plaintextBytes, ciphertext, tag);

        //        var encryptedData = new
        //        {
        //            tag = Convert.ToBase64String(tag),
        //            vi = Convert.ToBase64String(nonce),
        //            dt = Convert.ToBase64String(ciphertext)
        //        };

        //        // Convertir el objeto a una cadena JSON
        //        string json = JsonConvert.SerializeObject(encryptedData);

        //        Console.WriteLine("Mensaje cifrado: " + json);

        //        Console.ReadKey();
        //    }
        //}
        //else if (option == "2")
        //{
        //    //Console.Write("Ingrese el texto cifrado en base64: ");
        //    string yourBase64Ciphertext = @"+BDTZzrxkmWNTNhRAKl1vcEF+4xURA9jXtPB+zuLAr77Hhc2MihUN8RrOyALiotAlfKKPPVj0Sxnbuaql8GWsh1fKJe9E1yJ\/FrBjm2WEwxBug9Mz8Ml9RugargiOO7\/jHtD4yI4\/JlDqwNO6EXZquB9nhYWBe3yiqg9S";

        //    //Console.Write("Ingrese la clave en base64: ");
        //    string yourBase64Key = "u4XhWFD0AaJ0NXDplaA6d1F3P3XjuPvVB7fq9BlSpAA=";

        //    //Console.Write("Ingrese el nonce en base64: ");
        //    string yourBase64Nonce = "UDafAocDrG7rss+R";

        //    //Console.Write("Ingrese el tag en base64: ");
        //    string yourBase64Tag = "EaluNlbpnRz+Da1UWBS4Mw==";

        //    byte[] ciphertext = Convert.FromBase64String(yourBase64Ciphertext);
        //    byte[] key = Convert.FromBase64String(yourBase64Key);
        //    byte[] nonce = Convert.FromBase64String(yourBase64Nonce);
        //    byte[] tag = Convert.FromBase64String(yourBase64Tag);

        //    using (var cipher = new AesGcm(key))
        //    {
        //        byte[] plaintext = new byte[ciphertext.Length];

        //        cipher.Decrypt(nonce, ciphertext, tag, plaintext);

        //        Console.WriteLine("Mensaje descifrado: " + System.Text.Encoding.UTF8.GetString(plaintext));
        //    }

        //    Console.ReadKey();
        //}
        //else
        //{
        //    Console.WriteLine("Opción inválida. Por favor, escriba '1' para cifrar o '2' para descifrar.");
        //}

        var authService = new AuthService();
        var tokens = await authService.FetchTokens();

        Console.WriteLine($"Access Token: {tokens.AccessToken}");
        Console.WriteLine($"Id Token: {tokens.IdToken}");

    }

    public class LoginTokens
    {
        public string AccessToken { get; set; }
        public string IdToken { get; set; }

        public LoginTokens(string accessToken, string idToken)
        {
            AccessToken = accessToken;
            IdToken = idToken;
        }
    }

    public class AuthService
    {
        private const string PoolId = "us-east-1:06719c47-687b-4594-968c-06de0abd5940";
        private const string AppClientId = "grqme08erl1o9d5j50lek1dps";
        private const string Region = "us-east-1";
        private const string IdentityPoolId = "us-east-1_T66ODA7Q3";

        public async Task<LoginTokens> FetchTokens()
        {
            // Configuración de Cognito
            var provider = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), RegionEndpoint.GetBySystemName(Region));
            var userPool = new CognitoUserPool(IdentityPoolId, AppClientId, provider);

            // Autenticación del usuario
            var user = new CognitoUser("6uaab73utm9bfnpg8gbkubecm3", AppClientId, userPool, provider);
            var authRequest = new InitiateSrpAuthRequest()
            {
                Password = "4t944pjmqa2d14dad1b6acenonslknvb45crnn28tjak8lai7ct"
            };
            var authResult = await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);

            // Obtención de tokens de acceso e identificación
            var accessToken = authResult.AuthenticationResult.AccessToken;
            var idToken = authResult.AuthenticationResult.IdToken;

            return new LoginTokens(accessToken, idToken);
        }
    }
}
