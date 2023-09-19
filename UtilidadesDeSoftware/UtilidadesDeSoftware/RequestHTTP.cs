using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilidadesDeSoftware.Clases;
using UtilidadesDeSoftware.Clases.BankColombia;
using UtilidadesDeSoftware.Clases.HTTPClass;

namespace UtilidadesDeSoftware
{
    public partial class RequestHTTP : Form
    {
        #region INICIAL
        public RequestHTTP()
        {
            InitializeComponent();
        }

        private void RequestHTTP_Load(object sender, EventArgs e)
        {

        }
        private void button1_ClickAsync(object sender, EventArgs e)
        {
            _= SolicitudRenaperAsync();
        }

        public async Task SolicitudRenaperAsync()
        {
            var datosToken = await ObtenerAutentificacionPost();
            if(datosToken.Data.Codigo == 0)
            {
                var datosPorDniSexo = await GetDatosPorDniSexo(datosToken.Data.Token);
            }
        }

        public async Task<AuthRenaper> ObtenerAutentificacionPost()
        {
            var authRenaper = new AuthRenaper();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://apirenaper.idear.gov.ar/CHUTROFINAL/API_ABIS/Autorizacion/token.php");
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("username", "esegdatos"));
            formData.Add(new KeyValuePair<string, string>("password", "c2sW*f_=ES(Q9Ow"));
            request.Content = new FormUrlEncodedContent(formData);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = response.Content.ReadAsStringAsync().Result;
                authRenaper = JsonConvert.DeserializeObject<AuthRenaper>(respuesta);
            }

            return authRenaper;
        }

        public async Task<DatosPorDniSexo> GetDatosPorDniSexo(string token)
        {
            var respuesta = string.Empty;
            var datosResponse = new DatosPorDniSexo();
            var url = String.Format("https://apirenaper.idear.gov.ar/apidatos/porDniSexo.php?dni={0}&sexo={1}", "30673822", "M");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                respuesta = await response.Content.ReadAsStringAsync();
                datosResponse = JsonConvert.DeserializeObject<DatosPorDniSexo>(respuesta);
            }

            return datosResponse;
        }

        #endregion


        // BANCOLOMBIA Autorizacion Basica+

        // https://speeding-robot-388249.postman.co/workspace/Personal-Workspace~0f2aa486-b2d3-4c7a-a276-c54ffc54d8cd/collection/7790549-2a47464e-38d6-4a41-a710-d8492a256caf?action=share&source=copy-link&creator=7790549

        private void button2_Click(object sender, EventArgs e)
        {
            //_ = GetTokenAccess();
            _ = GetTermsAndConditions();
            // _ = AcceptTermsandConditionsAsync();
            //_= ValidateCodeAsync();
            //_= TerminosAsync();
        }

        public async Task<BankColombiaTokenResponse> GetTokenAccess()
        {
            string respuesta = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                byte[] byteArray = Encoding.UTF8.GetBytes("31e654ebcde32b86cd55e461942c4802:1ba42d9ce0f61e42c8e8e0887dd5d79d");
                var base64Auth = Convert.ToBase64String(byteArray);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);
                client.DefaultRequestHeaders.Add("accept-language", "en_ES");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                Uri url = new Uri("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/security/oauth-provider/oauth2/token", UriKind.Absolute);
                List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
                formData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                formData.Add(new KeyValuePair<string, string>("scope", "Terms-register:write:user TermsConditions:read:user SecurityCode:read:app BancolombiaPay-wallet:write:user"));//Validate
                HttpContent content = new FormUrlEncodedContent(formData);
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<BankColombiaTokenResponse>(respuesta);
                }
            }

            return null;
        }



        public async Task<GetTermsAndConditionsResponse> GetTermsAndConditions()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();
            var customer = CreateCustomer();
            var content = JsonConvert.SerializeObject(customer);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("IP", "1.2.1.1.1.1.1.1.1.11");
                client.DefaultRequestHeaders.Add("deviceId", "123456789");
                //client.DefaultRequestHeaders.Add("Accept", "application/vnd.bancolombia.v4+json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objauth.Access_Token);
                //client.DefaultRequestHeaders.Add ("Authorization", "Bearer " + objauth.Access_Token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("messageid", "8213586182381y9");
                Uri url = new Uri("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/retrieveTerms", UriKind.Absolute);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj =  JsonConvert.DeserializeObject<GetTermsAndConditionsResponse>(respuesta);
                    return obj;
                }
            }

            return null;
        }

        //MzFlNjU0ZWJjZGUzMmI4NmNkNTVlNDYxOTQyYzQ4MDI6MWJhNDJkOWNlMGY2MWU0MmM4ZThlMDg4N2RkNWQ3OWQ=

        public async Task<AcceptTermsAndConditionsResponse> AcceptTermsandConditionsAsync()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();
            var customer = CreateAcceptaceTerms();
            var content = JsonConvert.SerializeObject(customer);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("IP", "1.2.1.1.1.1.1.1.1.11");
                client.DefaultRequestHeaders.Add("deviceId", "123456789");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.bancolombia.v4+json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , objauth.Access_Token);
                //client.DefaultRequestHeaders.Add ("Authorization", "Bearer " + objauth.Access_Token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("messageid", "8213586182381y9");
                var url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/acceptanceTerms" ;
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<AcceptTermsAndConditionsResponse>(respuesta);
                    return obj;
                }
            }

            return null;
        }


        public async Task<AcceptTermsAndConditionsResponse> ValidateCodeAsync()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();
            var responseAccept = await AcceptTermsandConditionsAsync();
            var validate = CreateValidateCode(responseAccept.data.security.enrollmentKey, "2014756");
            var content = JsonConvert.SerializeObject(validate);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("IP", "1.2.1.1.1.1.1.1.1.11");
                client.DefaultRequestHeaders.Add("deviceId", "123456789");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.bancolombia.v4+json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objauth.Access_Token);
                //client.DefaultRequestHeaders.Add ("Authorization", "Bearer " + objauth.Access_Token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("messageid", "8213586182381y9");
                var url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/validateCode";
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<AcceptTermsAndConditionsResponse>(respuesta);
                    return obj;
                }
            }

            return null;
        }

        //Customers
        public async Task<string> GetCustomer()
        {
            var objAuth = await  GetTokenAccess();
            var customer = CreateCustomer();
            var content = JsonConvert.SerializeObject(customer);
            string respuesta = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.bancolombia.v4+json");
                var url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/acceptanceTerms";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objAuth.Access_Token);
                var response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode && response != null)
                    respuesta = await response.Content.ReadAsStringAsync();

                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Accept", "application/vnd.bancolombia.v4+json");
                //var url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/cross-product/payments/bancolombiapay/health";
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objAuth.Access_Token);

                //// Crear una solicitud HTTP con el método HEAD
                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head,url);

                //var response = await client.SendAsync(request);

                //if (response.IsSuccessStatusCode && response != null)
                //    respuesta = await response.Content.ReadAsStringAsync();

            }

            return respuesta;
        }

        public BankColombiaCustomer CreateCustomer()
        {
            var bankCustomer = new BankColombiaCustomer
            {
                data = new Data
                {
                    customer = new Customer
                    {
                        identification = new Identification
                        {
                            type = "CC",
                           // type = "CE",
                            number = "1234567890",
                            issuedDate = DateTime.Now.Date.ToString("yyyy-MM-dd")
                        }
                    }
                }
            };

            return bankCustomer;
        }

        public AcceptaceTerms CreateAcceptaceTerms()
        {
            var acceptanceTerms = new AcceptaceTerms
            {
                data = new Data_AcceptaceTerms
                {
                    contactDetail = new ContactDetail
                    {
                        email = "correo@ejemplo.com",
                        mobilePhoneNumber = "3002697624"
                    },
                    personalData = new PersonalData
                    {
                        firstName = "Carlos",
                        firstSurname = "Perez",
                        birthDate = "1972-02-08",
                        politicallyExposedPerson = true,
                        secondName = "Carlos",
                        secondSurname = "Perez"
                    },
                    termsCondition = new TermsCondition
                    {
                        productTerms = new ProductTerms
                        {
                            version = "1.0",
                            acceptance = true
                        },
                        clausesCustomer = new ClausesCustomer
                        {
                            version = "1.0",
                            acceptance = true
                        },
                        walletTerms = new WalletTerms
                        {
                            version = "1.0",
                            acceptance = true
                        }
                    },
                    security = new Security
                    {
                        enrollmentKey = "clave123"
                    },
                    identification = 1234567890  
                }
            };

            return acceptanceTerms;
        }

        public ValidateCodeRequest CreateValidateCode(string key, string code)
        {
            var validateCodeRequest = new ValidateCodeRequest
            {
                data = new DataValidateCodeRequest
                {
                    security = new SecurityValidateCodeRequest
                    {
                        enrollmentKey = key 
                    },
                    securityCode = code
                }
            };

            return validateCodeRequest;
        }
    


       

        private void button3_Click(object sender, EventArgs e)
        {
            GenerarCertificado();
        }
        public static void GenerarCertificado()
        {
            // Datos para el certificado
            var countryName = "CO";
            var stateOrProvince = "ANTIOQUIA";
            var localityName = "MEDELLIN";
            var organizationName = "VetticaMaasApp S.A.";
            var organizationalUnitName = "BANCOLOMBIA";
            var commonName = "VetticaMaasApp.com";

            // Tamaño de clave recomendado
            var keySize = 2048;

            // Crear clave RSA para el certificado
            using (RSA rsa = RSA.Create(keySize))
            {
                var distinguishedName = new X500DistinguishedName($"C={countryName}, ST={stateOrProvince}, L={localityName}, O={organizationName}, OU={organizationalUnitName}, CN={commonName}");

                var request = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                // Generar el certificado autofirmado
                var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));

                // Exportar el certificado en formato X.509 codificado en base 64 (.crt)
                var base64Certificate = Convert.ToBase64String(certificate.Export(X509ContentType.Cert));
                var pathToSaveCrt = "C:/Users/EfrainMejiasC/Downloads/Maas/BankColombia/BankColombiaCertificado.crt";
                File.WriteAllText(pathToSaveCrt, base64Certificate);

                // Exportar la clave privada junto con el certificado en formato PFX
                var pfxBytes = certificate.Export(X509ContentType.Pfx, "1234Santiago");
                var pathToSavePfx = "C:/Users/EfrainMejiasC/Downloads/Maas/BankColombia/BankColombiaCertificado.pfx";
                File.WriteAllBytes(pathToSavePfx, pfxBytes);
            }
        }


    }
}
