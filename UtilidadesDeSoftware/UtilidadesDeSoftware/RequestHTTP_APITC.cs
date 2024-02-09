using Newtonsoft.Json;
using sun.security.timestamp;
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
using UtilidadesDeSoftware.Clases.HTTP_APITC;
using UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest;
using UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse;

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

        public async Task<TOutput> HttpRequestApiTc<TInput, TOutput>(string url, TInput model)
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

        public static PWCreatePersonRequestDto SetCreatePerson()
        {
            var createPerson = new PWCreatePersonRequestDto()
            {
                firstname = "John",
                lastname = "Doel",
                ididentificationtype = "4",
                identification = "499887766554433221",
                email = "john2@example.com",
                phone = "1134567890",
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





        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            _ = CreatePerson();
        }

        private async Task<bool> CreatePerson()
        {
            var model = SetCreatePerson();
            var result = await HttpRequestApiTc<PWCreatePersonRequestDto, PWCreatePersonResponseDto>("CrearPersona", model);
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
            var result = await HttpRequestApiTc<PWCreateTransactionRequestDto, PWCreateTransactionResponseDto>("CrearTransaccion", model);
            richTextBox1.Text = JsonConvert.SerializeObject(result);
            return false;
        }
    }
}
