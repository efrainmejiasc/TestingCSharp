using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using static Program.AuthService;

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

        //***************************************************

        var authService = new CognitoAuthService(
        region: "us-east-1",
        clientId: "6uaab73utm9bfnpg8gbkubecm3",
        poolId: "us-east-1_T66ODA7Q3",
        jwks: "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"kid\":\"cmCbV18kScc0rZpIHxjHYqUWuuP+yoZu9ytk7G64yis=\",\"kty\":\"RSA\",\"n\":\"2Bj1Vz78HDe4QAYhtIQq2kXr_vz25I0j3QfVzhqAHTSYH5zXAjLljg-KPt4-WJA4rIPkKJDwoUY5A9-2DhapkvUeqjJdIHwMqVb2uo5K56DYow5vAMPjPPsQDw1qMSgZQnMK03pu8VsSzHLn3KXoVtE38wfGir1wEHy8qZFRRQJShp_SoZCyDG4XPqYna_KwO2LORF8l7LL5vpVq4UOAjzdQI-CE4F7D1zZqnGk7REbwaVne8lbhOzsi1rDcaH1ivzS_3yudkMCOl8QsL6m-G9WANlDoY6lsSyMQoe4qgCzLNtaSRAHhTiPLtSmUAMQSlR9WQvB7UA7kWeauWVB-MQ\",\"use\":\"sig\"},{\"alg\":\"RS256\",\"e\":\"AQAB\",\"kid\":\"pb3qSCivNFCdUc/6ulr0N0yfhG608EIZvfKnlV+o+Ns=\",\"kty\":\"RSA\",\"n\":\"rglr9AEbKXA2sXQu_j3JmHmTLfVhG7jF4uNMPc8XHXfWDrpWJAnMbzSLIDg-qBWzWn9ExX1f862tunvqnj99seznHHUgf_VZbvUgekTxe3H8IKPP6v5MCT9NC4WRB7WW5DIOVAJ0ZepncLmiYBCFstj6_LjaSAqqwqdcmNG2F1MuQiQ_lhEpKg5XxD0AUOhHPOVhmVg5AbQxBbPQVXV25csbtigUASool6onRF4t2DMRvA--FssVbx9PdmlFVTydRPaAcY9YjAo8axQw0KGYcYZz6krY47UnqLdx0y32qT9DIAf06PTGWAYJU_qctbXAGBXnzVK2zh91_8M8k42x9Q\",\"use\":\"sig\"}]}"
       );

        var token = await authService.GetCognitoTokenAsync();
        Console.WriteLine($"Token JWT: {token}");

        //****************************************************

        //var authService = new AuthService();
        //var result = await authService.GetAccessTokenAsync();
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

        public async Task<LoginTokens?> FetchTokens()
        {
            try
            {
                // Configuración de Cognito
                var provider = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), RegionEndpoint.GetBySystemName(Region));
                var userPool = new CognitoUserPool(IdentityPoolId, AppClientId, provider);

                // Autenticación del usuario
                var user = new CognitoUser("pruebageneral30524@yopmail.com", AppClientId, userPool, provider);
                var authRequest = new InitiateSrpAuthRequest()
                {
                    Password = "Pruebas1234."
                };
                var authResult = await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);

                // Obtención de tokens de acceso e identificación
                var accessToken = authResult.AuthenticationResult.AccessToken;
                var idToken = authResult.AuthenticationResult.IdToken;

                return new LoginTokens(accessToken, idToken);
            }
            catch (Exception ev)
            {
                var error = ev.ToString();
            }

            return null;
        }



        public async Task<string> GetAccessTokenAsync()
        {
            var tokenUrl = "https://testmaasapp.auth.us-east-1.amazoncognito.com/oauth2/token";
            var clientId = "6uaab73utm9bfnpg8gbkubecm3";
            var clientSecret = "4t944pjmqa2d14dad1b6acenonslknvb45crnn28tjak8lai7ct";

            using (var client = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[]
                {
                  new KeyValuePair<string, string>("grant_type", "client_credentials"),
                  new KeyValuePair<string, string>("client_id", clientId),
                  new KeyValuePair<string, string>("client_secret", clientSecret)
                });

                var response = await client.PostAsync(tokenUrl, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    throw new Exception($"Error obteniendo token: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }


        public class CognitoAuthService
        {
            private readonly RegionEndpoint _region;
            private readonly string _clientId;
            private readonly string _poolId;
            private readonly string _jwks;

            public CognitoAuthService()
            {
            }

            public CognitoAuthService(string region, string clientId, string poolId, string jwks)
            {
                _region = RegionEndpoint.GetBySystemName(region);
                _clientId = clientId;
                _poolId = poolId;
                _jwks = jwks;
            }

            public async Task<string> GetCognitoTokenAsync()
            {
                var credentials = new Amazon.Runtime.BasicAWSCredentials("6uaab73utm9bfnpg8gbkubecm3", "4t944pjmqa2d14dad1b6acenonslknvb45crnn28tjak8lai7ct");
                var provider = new AmazonCognitoIdentityProviderClient(credentials, _region);

                var initiateAuthRequest = new InitiateAuthRequest
                {
                    AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
                    AuthParameters = { { "USERNAME", "pruebageneral30524@yopmail.com" }, { "PASSWORD", "Pruebas1234." } },
                    ClientId = _clientId
                };

                try
                {
                    var initiateAuthResponse = await provider.InitiateAuthAsync(initiateAuthRequest);

                    if (initiateAuthResponse.AuthenticationResult != null)
                    {
                        return initiateAuthResponse.AuthenticationResult.IdToken;
                    }
                    else
                    {
                        throw new Exception("Error authenticating user");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }

            }
        }





    }
}
