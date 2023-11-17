using Newtonsoft.Json;
using RestSharp;
using RestApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
            _ = GetTokenAccess();
            ///_ = GetTermsAndConditions();
            _ = AcceptTermsandConditionsAsync();
            //_= ValidateCodeAsync();
            //_= TerminosAsync();

            // _ = CreateProduct();

            //_ = TestingALM();
            // _ = RetrieveTermsAsync();
            //_ =  RetrieveTermsAsync2();

            //TestingHead();


            //_ = RetrieveTermsAsync2();

          // _=  SendBankcoApiRequestAsync();
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
                //formData.Add(new KeyValuePair<string, string>("scope", "Terms-register:write:user TermsConditions:read:user SecurityCode:read:app BancolombiaPay-wallet:write:user Customer-token:write:user Customer-viability:read:app Product-balance:read:user"));
                //formData.Add(new KeyValuePair<string, string>("scope", "TermsConditions-register:write:user TermsConditions:read:user"));
                //formData.Add(new KeyValuePair<string, string>("scope", "Products-payment:read:user BancolombiaPay-wallet:write:user"));
                //formData.Add(new KeyValuePair<string, string>("scope", "Product-balance:read:user"));
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
               SetCommonHeaders(client, objauth.Access_Token);

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
        private HttpClient SetCommonHeaders(HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("IP", "1.2.1.1.1.1.1.1.1.11");
            client.DefaultRequestHeaders.Add("deviceId", "123456789");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("messageid", "8213586182381y9");

            return client;
        }


        public  async Task RetrieveTermsAsync()
        {
            try
            {
                var objauth = await GetTokenAccess();
                using (HttpClient client = new HttpClient())
                {
                    // Configurar los encabezados requeridos
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("accept", "application/vnd.bancolombia.v4+json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objauth.Access_Token);
                    client.DefaultRequestHeaders.Add("messageId", "1511a409-ecaa-4d96-baee-eca3380b2ee0");
                    client.DefaultRequestHeaders.Add("accept", "application/vnd.bancolombia.v4+json");
                    HttpResponseMessage response = await client.GetAsync("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/consumer-services/brokered-product/bancolombiapay-wallet-syncing/terms/retrieveTerms");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);

                }
            }
            catch(Exception ex)
            {
                var error = ex.ToString();
            }
        }

        public async Task<string> RetrieveTermsAsync2()
        {
            try
            {
                var objauth = await GetTokenAccess();
                string url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/consumer-services/brokered-product/bancolombiapay-wallet-syncing/terms/retrieveTerms";
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("content-type", "application/vnd.bancolombia.v4+json");
                client.DefaultRequestHeaders.Add("messageId", "1511a409-ecaa-4d96-baee-eca3380b2ee0");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objauth.Access_Token);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Respuesta exitosa:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error en la solicitud:");
                     Console.WriteLine(response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                Console.WriteLine($"Error: {error}");
                 return null;
            }

            return "";
        }

        public async Task<object> RestSharpAsync()
        {
            var objauth = await GetTokenAccess();
            string url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/consumer-services/brokered-product/bancolombiapay-wallet-syncing/terms/retrieveTerms";
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/vnd.bancolombia.v4+json");
            request.AddHeader("message-Id", "1511a409-ecaa-4d96-baee-eca3380b2ee0");
            request.AddHeader("Authorization", "Bearer " + objauth.Access_Token);
            IRestResponse response = client.Execute(request);

            return "";
        }


        public void TestingHead()
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/consumer-services/brokered-product/bancolombiapay-wallet-syncing/terms/retrieveTerms");
            
            
            // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Console.WriteLine("\nThe HttpHeaders are \n\n\tName\t\tValue\n{0}", myHttpWebRequest.Headers);
            // Print the HTML contents of the page to the console.
            Stream streamResponse = myHttpWebResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuff = new Char[256];
            int count = streamRead.Read(readBuff, 0, 256);
            Console.WriteLine("\nThe HTML contents of page the are  : \n\n ");
            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                Console.Write(outputData);
                count = streamRead.Read(readBuff, 0, 256);
            }
            // Close the Stream object.
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse Resource.
            myHttpWebResponse.Close();
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
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.bancolombia.v4+json"));
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.bancolombia.v4+json");
                client.DefaultRequestHeaders.Add("messageid", "8213586182381y9");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.bancolombia.v4+json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , objauth.Access_Token);

                var url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/acceptanceTerms" ;
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<AcceptTermsAndConditionsResponse>(respuesta);
                    return obj;
                }
                respuesta = await response.Content.ReadAsStringAsync();
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

        public async Task<AcceptTermsAndConditionsResponse> CreateProduct()
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
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("messageid", "8213586182381y9");
                var url = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/createProduct";
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


        public async Task<string> SendBankcoApiRequestAsync()
        {
          try
            {
                var apiUrl = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/acceptanceTerms";

                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

                // Configurar encabezados
                request.Headers.Add("IP", "1.2.1.1.1.1.1.1.1.11");
                request.Headers.Add("deviceId", "123456789");
                request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Accept", "application/vnd.bancolombia.v4+json");
                request.Headers.Add("messageid", "8213586182381y9");
                request.Headers.Add("Authorization", "Bearer AAIgMzFlNjU0ZWJjZGUzMmI4NmNkNTVlNDYxOTQyYzQ4MDKvDMQQv-0HuAkw1S6S6ZzB9jTN7n4A3onV6G1scWPw4oWWboYhgGkyhDZRuS4Zof8fgHA1v4EdMs4A_1rmDK4mNNwpA3x5vMOVkGzhMwBEpyVtohqAsc82OEEBI3K_207_1AYW8MKU-HIZ4OFSPfkaXTBImJkr-JwW4bhp8zeMXCrE4gKMl6Uia6sd86Zy87DSTmzR4wdoEapLECXVzgK4dyI0bOck0jq9IMmbHaE1VSgJujjn6Vl7ukD8uaqrqf9BP-2uMaLSr85opZZmCQBW4CYfFA6PPr7bcoTQq6jaV7XTfWo7d54UqHhe1FOzcomp8q9-qFdU5Vx5iT82nqNYD4o5TwcU5fLcs9VHq7rLtg");
                request.Headers.Add("Accept", "application/vnd.bancolombia.v4+json");
   
                request.Headers.Add("Cookie", "incap_ses_9084_2772063=j/BnEgBA8me4lGL089kQfsJFHGUAAAAARPnvgBe3M4xtwCEY5m8iYA==; nlbi_2772063=UXdXWoWo6Guocgjt4mx6zAAAAABHWVRBYI3e+HS0d6DOjYMC; visid_incap_2772063=IrJBP/zwTu2oebwS+WwJIb8pA2UAAAAAQUIPAAAAAADgAKQPRMxcamQNhA1cz4Hz");

                // Configurar datos en formato JSON
                var requestData = new
                {
                    firmwareMobil = "i-F86F832F-244F-400E-8750-E4D6683B2F32",
                    data = new
                    {
                        customer = new
                        {
                            contactDetail = new
                            {
                                email = "correo@dominio.com.co",
                                mobilePhoneNumber = "3201234567"
                            },
                            personalData = new
                            {
                                firstName = "Pedro",
                                secondName = "Pablo",
                                firstSurname = "Suarez",
                                secondSurname = "Perez",
                                birthDate = "1972-08-02",
                                politicallyExposedPerson = true
                            }
                        },
                        termsCondition = new
                        {
                            productTerms = new
                            {
                                version = "1",
                                acceptance = true
                            },
                            clausesCustomer = new
                            {
                                version = "1",
                                acceptance = true
                            },
                            walletTerms = new
                            {
                                version = "1",
                                acceptance = true
                            }
                        },
                        security = new
                        {
                            enrollmentKey = "yBLW1aVToelcK9EKH/OMzOx2L6ZG3iLIRFQRNgMZKJ8/eat3SDoN8vnIfCiQcodPNV+4tsc5XheD2KK+cbN4+a5eTiY2qNLc3Bg6ibjWitWUz1d6/c48t++khEmRSqn19DJB7aTnUb7ydECCki3YQkoO43t/2ujQWvTbkTIAopJzTjOOpqEbUdmLEoIEC0oVei8jtLhibiBaDJpSEcdvTGVd/bdsI9bpolBqHXD+mjjK9RBAkhhhr0UaMTB7305+vMsVyy/lXY3H9dqNWXAXxxmwx49tKBwyH+WMDGTolMwE0"
                        }
                    }
                };

                var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                request.Content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
                HttpClient _httpClient = new HttpClient();
                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    // Manejar la respuesta en caso de error
                    return null;
                }
            }
            catch (Exception ex)
            {
                var es = ex.ToString();
            }
            return "";
        }






        public async Task<string> TestingALM()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();
            var responseAccept = await AcceptTermsandConditionsAsync();
            var validate = CreateValidateCode(responseAccept.data.security.enrollmentKey, "2014756");
            var content = JsonConvert.SerializeObject(validate);

            using (HttpClient client = new HttpClient())
            {
                SetCommonHeaders(client, objauth.Access_Token);

                Uri url = new Uri("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/consumer-services/brokered-product/bancolombiapay-wallet-syncing/customer/validate", UriKind.Absolute);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                //if (response.IsSuccessStatusCode)
                //{
                    respuesta = await response.Content.ReadAsStringAsync();
                    //var obj = JsonConvert.DeserializeObject<GetTermsAndConditionsResponse>(respuesta);
                    //return obj;
                //}
            }

            return respuesta;
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
            var commonName = "Maspay.com";

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
                var pathToSaveCrt = "C:/Users/DELL/Downloads/TaskMaas/BankColombiaCertificado.crt";
                File.WriteAllText(pathToSaveCrt, base64Certificate);

                // Exportar la clave privada junto con el certificado en formato PFX
                var pfxBytes = certificate.Export(X509ContentType.Pfx, "1234Santiago");
                var pathToSavePfx = "C:/Users/DELL/Downloads/TaskMaas/BankColombiaCertificado.pfx";
                File.WriteAllBytes(pathToSavePfx, pfxBytes);
            }
        }




        public class BankcoApiService
    {
        private readonly HttpClient _httpClient;

        public BankcoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

      
    }

}
}
