using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilidadesDeSoftware.Clases.BankColombia;
using UtilidadesDeSoftware.Clases.BankColombia.Helper;

namespace UtilidadesDeSoftware
{
    public partial class BankCoHeaders : Form
    {
        string UrlProductsBase = "https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/sales-services/customer-management/customer-products/bancolombiapay-deposit-products-management/product-opening/";
        public BankCoHeaders()
        {
            InitializeComponent();
        }

        private void BankCoHeaders_Load(object sender, EventArgs e)
        {

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
                formData.Add(new KeyValuePair<string, string>("scope", ScopeCashIn.ScopePrepareTransaction));
                //formData.Add(new KeyValuePair<string, string>("scope", "Terms-register:write:user TermsConditions:read:user SecurityCode:read:app BancolombiaPay-wallet:write:user"));
                //formData.Add(new KeyValuePair<string, string>("scope", "TermsConditions-register:write:user TermsConditions:read:user"));
                //formData.Add(new KeyValuePair<string, string>("scope", "Products-payment:read:user BancolombiaPay-wallet:write:user"));
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

        public async Task<BankCoCIRetrieveTermsResponseDto> BankCoCIRetrieveTerms()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();
            var content = JsonConvert.SerializeObject(SetObjectClass.SetCIRetrieveTerms());
            using (HttpClient client = new HttpClient())
            {
                SetCommonHeaders(client, objauth.Access_Token);

                Uri url = new Uri("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/trade-banking/cash-management/bancolombiapay-cash-in/financial-gateway-cash-in/terms/cash-in-pse", UriKind.Absolute);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BankCoCIRetrieveTermsResponseDto>(respuesta);
                    return obj;
                }
                else
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BankCoCIRetrieveTermsResponseDto>(respuesta);
                }
            }

            return null;
        }


        public async Task<BankCoCIPrepareTransactionResponseDto> BankCoCIPrepareTransaction()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();
            var content = JsonConvert.SerializeObject(SetObjectClass.SetCIPrepareTransactionRequest());
            using (HttpClient client = new HttpClient())
            {
                SetCommonHeaders(client, objauth.Access_Token);

                Uri url = new Uri("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/trade-banking/cash-management/bancolombiapay-cash-in/financial-gateway-cash-in/transactions/cash-in-pse", UriKind.Absolute);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BankCoCIPrepareTransactionResponseDto>(respuesta);
                    return obj;
                }else
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BankCoCIPrepareTransactionResponseDto> (respuesta);
                }
            }

            return null;
        }

        public async Task<BankCoCIRetrieveStatusTransactionResponseDto> BankCoCIRetrieveStatus()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();
            var content = JsonConvert.SerializeObject(SetObjectClass.SetCIRetrieveStatus());
            using (HttpClient client = new HttpClient())
            {
                SetCommonHeaders(client, objauth.Access_Token);

                Uri url = new Uri("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/trade-banking/cash-management/bancolombiapay-cash-in/financial-gateway-cash-in/transaccions/cash-in-pse-status", UriKind.Absolute);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BankCoCIRetrieveStatusTransactionResponseDto>(respuesta);
                    return obj;
                }
                else
                {
                    respuesta = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<BankCoCIRetrieveStatusTransactionResponseDto>(respuesta);
                }
            }

            return null;
        }

        private HttpClient SetCommonHeaders(HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("accept", "application/vnd.bancolombia.v4+json");
            client.DefaultRequestHeaders.Add("strongAuthentication", "true");
            client.DefaultRequestHeaders.Add("messageId", "123456789");
            client.DefaultRequestHeaders.Add("deviceId", "123456789");
            client.DefaultRequestHeaders.Add("IP", "1.2.1.1.1.1.1.1.1.11");

            return client;
        }




        public async Task<string> GetTermsAndConditions()
        {
            string respuesta = string.Empty;
            var objauth = await GetTokenAccess();

            try
            {
                var url = UrlProductsBase + "retrieveTerms";
                HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("https://gw-sandbox-qa.apps.ambientesbc.com/public-partner/sb/v1/operations/product-specific/consumer-services/brokered-product/bancolombiapay-wallet-syncing/terms/retrieveTerms");
                HttpWReq.Method = "GET";
                HttpWReq.Headers.Add("Authorization", "Bearer " + objauth.Access_Token);
                HttpWReq.ContentType = "application/json";
                HttpWReq.Accept = "application/vnd.bancolombia.v4+json"; 
                HttpWReq.Headers.Add("deviceId", "123456789");
                HttpWReq.Headers.Add("messageid", "1511a409-ecaa-4d96-baee-eca3380b2ee0");

                using (HttpWebResponse response = (HttpWebResponse)HttpWReq.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                respuesta = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // _ = GetTermsAndConditions();
            //_ = BankCoCIRetrieveTerms();
            // _ = BankCoCIPrepareTransaction();
            _ = BankCoCIRetrieveStatus();
        }
    }
}
