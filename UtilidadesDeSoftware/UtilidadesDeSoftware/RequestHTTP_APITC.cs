using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest;

namespace UtilidadesDeSoftware
{
    public partial class RequestHTTP_APITC : Form
    {
        byte[] APIKEYBYTE = Encoding.ASCII.GetBytes("25d10b4c992b77128d06e1bdacb1c443ca458ccc3640679a04da92a90617a64de092164cc1baa1bae0438b1309ba9fb92e760ffbcbe562495596eaf8f8820a46");
        string APIKEY = "MjVkMTBiNGM5OTJiNzcxMjhkMDZlMWJkYWNiMWM0NDNjYTQ1OGNjYzM2NDA2NzlhMDRkYTkyYTkwNjE3YTY0ZGUwOTIxNjRjYzFiYWExYmFlMDQzOGIxMzA5YmE5ZmI5MmU3NjBmZmJjYmU1NjI0OTU1OTZlYWY4Zjg4MjBhNDY=";
        string URLBASE = "https://serviceregisterpruebas.vepay.com.co/ClientAPI/";

        public RequestHTTP_APITC()
        {
            InitializeComponent();
        }

        public async Task<string> HttpRequestApiTc<T>(string url, T model)
        {
            string respuesta = string.Empty;
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
                        respuesta = await response.Content.ReadAsStringAsync();
                    else
                        respuesta = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }

            return respuesta;
        }


        public async Task<string> Test123()
        {
            var client = new HttpClient();
            var model = SetCreateTransaction();
            var contenido = JsonConvert.SerializeObject(model);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://serviceregisterpruebas.vepay.com.co/ClientAPI/CrearTransaccion");
            request.Headers.TryAddWithoutValidation("Authorization", APIKEY);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            var content = new StringContent(contenido, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var respuesta = await response.Content.ReadAsStringAsync();
            return respuesta;
        }


        public async Task<string> Test1234()
        {
            var client = new HttpClient();
            var model = SetCreateTransaction();
            var contenido = JsonConvert.SerializeObject(model);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://serviceregisterpruebas.vepay.com.co/ClientAPI/CrearTransaccion");
            request.Headers.TryAddWithoutValidation("Authorization", APIKEY);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            var content = new StringContent(contenido, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var respuesta = await response.Content.ReadAsStringAsync();
            return respuesta;
        }


        public async Task<string> CrearPersona()
        {
            try
            {
                string url = "https://serviceregisterpruebas.vepay.com.co/ClientAPI/CrearPersona";
                string jsonData = JsonConvert.SerializeObject(SetCreatePerson());
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "MjVkMTBiNGM5OTJiNzcxMjhkMDZlMWJkYWNiMWM0NDNjYTQ1OGNjYzM2NDA2NzlhMDRkYTkyYTkwNjE3YTY0ZGUwOTIxNjRjYzFiYWExYmFlMDQzOGIxMzA5YmE5ZmI5MmU3NjBmZmJjYmU1NjI0OTU1OTZlYWY4Zjg4MjBhNDY=");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
            }
            return "";
        }





        #region METODOS_COMUNES

        private HttpClient SetCommonHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "MjVkMTBiNGM5OTJiNzcxMjhkMDZlMWJkYWNiMWM0NDNjYTQ1OGNjYzM2NDA2NzlhMDRkYTkyYTkwNjE3YTY0ZGUwOTIxNjRjYzFiYWExYmFlMDQzOGIxMzA5YmE5ZmI5MmU3NjBmZmJjYmU1NjI0OTU1OTZlYWY4Zjg4MjBhNDY=");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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

        public static PWCreatePerson SetCreatePerson()
        {
            var createPerson = new PWCreatePerson()
            {
                firstname = "John",
                lastname = "Doe",
                ididentificationtype = "DNI",
                identification = "12345678",
                email = "john@example.com",
                phone = "123456789",
                state = "California",
                city = "Los Angeles",
                address = "123 Main St",
                zipcode = "90001"
            };

            return createPerson;
        }
        public static PWCreateTransaction SetCreateTransaction()
        {
            var createTransaction = new PWCreateTransaction()
            {
                form_id = 1234,
                terminal_id = 5678,
                idperson = "378",
                amount = "10000",
                external_order = "RT3000",
                ip = GenerarDireccionIP(),
                additionalData = "Additional data example",
                currencycode = "COP",
            };

            return createTransaction;
        }





        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            _ = CrearPersona().Result;
            var model = SetCreatePerson();
            var result = HttpRequestApiTc("CrearPersona", model).Result;
            richTextBox1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = Test123().Result;
            var model = SetCreateTransaction();
            var result = HttpRequestApiTc("CrearTransaccion", model).Result;
            richTextBox1.Text = result;
        }
    }
}
