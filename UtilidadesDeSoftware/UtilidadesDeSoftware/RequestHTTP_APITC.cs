using Newtonsoft.Json;
using sun.security.timestamp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilidadesDeSoftware.Clases.HTTP_APITC;
using UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest;
using UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse;
using System.Runtime.Serialization.Json;
using Org.BouncyCastle.Crypto;
using java.security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using java.sql;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;


namespace UtilidadesDeSoftware
{
    public partial class RequestHTTP_APITC : Form
    {
        byte[] APIKEYBYTE = Encoding.ASCII.GetBytes("25d10b4c992b77128d06e1bdacb1c443ca458ccc3640679a04da92a90617a64de092164cc1baa1bae0438b1309ba9fb92e760ffbcbe562495596eaf8f8820a46");
        string APIKEY = "MjVkMTBiNGM5OTJiNzcxMjhkMDZlMWJkYWNiMWM0NDNjYTQ1OGNjYzM2NDA2NzlhMDRkYTkyYTkwNjE3YTY0ZGUwOTIxNjRjYzFiYWExYmFlMDQzOGIxMzA5YmE5ZmI5MmU3NjBmZmJjYmU1NjI0OTU1OTZlYWY4Zjg4MjBhNDY=";
        string URLBASE = "https://serviceregisterpruebas.vepay.com.co/ClientAPI/";
        //string URLBASE = "https://serviceregister.paymentsway.co/ClientAPI/";

        string PUBLICKEY = @"-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA9llGF9C5OZBN1hqKXw8f
z4kWCJjJqj0UG1sPKwxJyjjXVuwFB8z7kfQZlfSs//mKzyEoO1NNRc+WWROyNwf6
49fVlcDvcuzyhXtdokajk8Nr7ogoyjWlkAeqmZl4Neurt9wgJMmFyNjkY2RGmhcy
X8qq59oiOREav4WEUB/3Y+m5a/LAb8b6HNgI+7tNE6ZQvfadWvgPey7J/V0ZvLRn
ORtm5bA/KWzzJr5jopIgb2xK8QuoyheyMzAUS6EWK4yIH7AzuhBI7UFkKLgvzoW+
XBzcBwdtqinkPLLnsIIoKVokl9wLpR43Z/mAlzcSitQ4H2qVCZsrE7fnTOBOwlpO
5QIDAQAB
-----END PUBLIC KEY-----";

        public RequestHTTP_APITC()
        {
            InitializeComponent();
        }

        public async Task<TOutput> PostHttpRequestApiTc<TInput, TOutput>(string url, TInput model)
        {
            var responseModel = default(TOutput);
            var respuesta = string.Empty;
            try
            {
                var content = JsonConvert.SerializeObject(model);
                using (HttpClient client = new HttpClient())
                {
                    SetCommonHeaders(client);
                    url = URLBASE + url;
                    Uri urlRequest = new Uri(url, UriKind.Absolute);
                    HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        respuesta = await response.Content.ReadAsStringAsync();
                        responseModel = JsonConvert.DeserializeObject<TOutput>(respuesta);
                    }
                    else
                    {
                        respuesta = await response.Content.ReadAsStringAsync();
                        responseModel = JsonConvert.DeserializeObject<TOutput>(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }

            return responseModel;
        }


        public async Task<TOutput> GetPostHttpRequestApiTc<TOutput>(string url)
        {
            var responseModel = default(TOutput);
            var respuesta = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    SetCommonHeaders(client);
                    url = URLBASE + url;
                    Uri urlRequest = new Uri(url, UriKind.Absolute);
                    HttpResponseMessage response = await client.GetAsync(urlRequest);
                    if (response.IsSuccessStatusCode)
                    {
                        respuesta = await response.Content.ReadAsStringAsync();
                        responseModel = JsonConvert.DeserializeObject<TOutput>(respuesta);
                    }
                    else
                    {
                        respuesta = await response.Content.ReadAsStringAsync();
                        responseModel = JsonConvert.DeserializeObject<TOutput>(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }

            return responseModel;
        }


        #region METODOS_COMUNES

        private HttpClient SetCommonHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", APIKEY);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }


        private static string GenerarDireccionIP()
        {
            var direccionIP = string.Empty;

            Random random = new Random();
            int octeto1 = random.Next(10, 256);
            int octeto2 = random.Next(0, 256);
            int octeto3 = random.Next(0, 256);
            int octeto4 = random.Next(0, 256);

            direccionIP = $"{octeto1}.{octeto2}.{octeto3}.{octeto4}";

            return direccionIP;
        }

        #endregion

        #region SETEAR_MODELOS

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

        public static PWCreateTransactionRequestDto SetCreateTransaction()
        {
            var createTransaction = new PWCreateTransactionRequestDto()
            {
                form_id = 240,
                terminal_id = 294,
                idperson = "378",
                amount = "10000",
                external_order = "RT0018",
                ip = GenerarDireccionIP(),
                additionalData = "",
                currencycode = "COP",
            };

            return createTransaction;
        }

        public static PWTokenizeCustomerCardRequestDto SetTokenizarTarjetaCliente()
        {
            var tokenizarTarjeta = new PWTokenizeCustomerCardRequestDto()
            {
                idtransaction = 7279,
                idterminal = 294,
                card_holder = "Efrain Mejias",
                card_pan = "1423456789",
                card_expiry_year = "2029",
                card_expiry_month = "12",
                card_cvv = "789",
                autorizacionDatos = true
            };

            return tokenizarTarjeta;
        }

        public static PWCreateOrderTcClientRequestDto SetPWCreateOrderTcClient()
        {
            var createOrderTc = new PWCreateOrderTcClientRequestDto()
            {
                url_ok = "www.urldestino.com",
                url_ko = "www.urldestinocasofallido.com",
                description = "prueba crear orden del cliente",
                reference = "7280",
                dynamic_descriptor = "Descripcion de prueba",
                form_id = 240,
                terminal_id = 294,
                extra_data = new ExtraDataCreateOrderTcClientRequest()
                {
                    payment = new PaymentCreateOrderTcClientRequest
                    {
                        installments = 1 // Numero de cuotas de pago

                    }
                }
            };

            return createOrderTc;
        }


        public static PWExecuteOrderTcClientRequestDto SetPWExecuteOrderTcClient()
        {
            var executeOrderTc = new PWExecuteOrderTcClientRequestDto()
            {
                order_uuid = "CC51AE39-E2A1-4F2A-8CBF-91DE2140916C",
                card_uuid = "d1277a88fc140b268e049938d24550a297020e432930c1f1278fdd82cf9e1",
                customer_ip = GenerarDireccionIP(),
                idtransaction = 7279,
                successResponse = true
            };

            return executeOrderTc;
        }


        public static PWRetrievePersonByDocumentRequestDto SetPWRetrievePersonByDocument()
        {
            var nroDocument = new PWRetrievePersonByDocumentRequestDto()
            {
               nroDocumento = "2233445566778899"
            };

            return nroDocument;
        }

        public static PWReverseTransactionRequestDto SetPWReverseTransaction()
        {
            var reverseTransaction = new PWReverseTransactionRequestDto()
            {
                idTransaction = "7270"
            };

            return reverseTransaction;
        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            _ = CreatePerson();
        }

        private async Task<bool> CreatePerson()
        {
            var model = SetCreatePerson();
            var result = await PostHttpRequestApiTc<PWCreatePersonRequestDto, PWCreatePersonResponseDto>("CrearPersona", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result); 
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = CreateTransaction();
        }

        private async Task<bool> CreateTransaction()
        {
            var model = SetCreateTransaction();
            var result = await PostHttpRequestApiTc<PWCreateTransactionRequestDto, PWCreateTransactionResponseDto>("CrearTransaccion", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _= TokenizarTarjeta();
        }

        private async Task<bool> TokenizarTarjeta()
        {
            var model = SetTokenizarTarjetaCliente();
            var result = await PostHttpRequestApiTc<PWTokenizeCustomerCardRequestDto, PWTokenizeCustomerCardResponseDto>("TokenizarTarjetaCliente", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           _= CrearOrdenTc();
        }

        private async Task<bool> CrearOrdenTc()
        {
            var model = SetPWCreateOrderTcClient();
            var result = await PostHttpRequestApiTc<PWCreateOrderTcClientRequestDto, PWCreateOrderTcClientResponseDto>("CrearOrdenTcCliente", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _ = EjecutarOrdenTc();
        }

        private async Task<bool> EjecutarOrdenTc()
        {
            var model = SetPWExecuteOrderTcClient();
            var result = await PostHttpRequestApiTc<PWExecuteOrderTcClientRequestDto, PWExecuteOrderTcClientResponseDto>("EjecutarOrdenTcCliente", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _ = RetrievePersonByDocument();
        }

        private async Task<bool> RetrievePersonByDocument()
        {
            var model = SetPWRetrievePersonByDocument();
            var result = await PostHttpRequestApiTc<PWRetrievePersonByDocumentRequestDto, PWRetrievePersonByDocumentResponseDto>("ObtenerPersonaPorDocumento", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _ = ReverseTransaction();
        }

        private async Task<bool> ReverseTransaction()
        {
            var model = SetPWReverseTransaction();
            var result = await PostHttpRequestApiTc<PWReverseTransactionRequestDto, PWReverseTransactionResponseDto>("ReversarTransaccion", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _ = RetrieveTransaction();
        }


        private async Task<bool> RetrieveTransaction()
        {
            var result = await GetPostHttpRequestApiTc<PWRetrieveTransactionResponseDto>("ObtenerTransaccion?id=7279");
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
           _  = RetrieveAllTransactionStatuses();
        }

        private async Task<bool> RetrieveAllTransactionStatuses()
        {
            var result = await GetPostHttpRequestApiTc<List<PWRetrieveAllTransactionStatusesResponseDto>>("GetAllTransactionStatuses");
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }


        private void button13_Click(object sender, EventArgs e)
        {
            _ = RetrieveAllIdentificationType();
        }

        private async Task<bool> RetrieveAllIdentificationType()
        {
            //var result = await GetPostHttpRequestApiTc<List<PWRetrieveAllTransactionStatusesResponseDto>>("ObtenerTiposIdentificacion");
            var result = await GetPostHttpRequestApiTc<List<PWRetrieveAllTransactionStatusesResponseDto>>("ObtenerMediosDePago");
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }

        #region ENCRYPTED
        private void button15_Click(object sender, EventArgs e)
        {
            var pwCreatePerson = SetCreatePerson();
            var pwCreatePersonEncrypted = EncryptObject<PWCreatePersonRequestDto>(pwCreatePerson);
            richTextBox1.Text = pwCreatePersonEncrypted;
        }
        public string ReadFileKeyPem()
        {
            var result = PUBLICKEY;
            result = result
                   .Replace("-----BEGIN PUBLIC KEY-----", "")
                   .Replace("-----END PUBLIC KEY-----", "")
                   .Replace("\r\n", "");

            return result;

        }


        public string EncryptObject<T>(T obj)
        {
            var publicKey = ReadFileKeyPem();

            var jsonData = JsonConvert.SerializeObject(obj);
            byte[] publicKeyBytes = Convert.FromBase64String(publicKey);

            using (var rsa = RSA.Create())
            {
                // Importar clave pública desde Base64
                rsa.ImportFromPem (publicKey);

                // Encriptar los datos utilizando RSA
                byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(data), RSAEncryptionPadding.OaepSHA256);

                // Convertir datos encriptados a Base64
                return Convert.ToBase64String(encryptedData);
            }
        }



        #endregion





        private void button10_Click(object sender, EventArgs e)
        {
            Random _random = new Random(DateTime.UtcNow.Millisecond + 100009);
            var unixTimestamp = _random.NextDouble().ToString().Replace(",", "").Replace(".", "").Remove(0, 1).Substring(0, 4);
            textBox1.Text = unixTimestamp;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            var obj = SetTokenizarTarjetaCliente();
            var objEncrypted= Encrypted.Encrypt<PWTokenizeCustomerCardRequestDto>(obj);
            richTextBox1.Text = objEncrypted;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var obj = richTextBox1.Text;
            var objDecrypted = Encrypted.Decrypt<PWTokenizeCustomerCardRequestDto>(obj);
            var content = JsonConvert.SerializeObject(objDecrypted);
            richTextBox1.Text = content;
           
        }

      
    }
}
