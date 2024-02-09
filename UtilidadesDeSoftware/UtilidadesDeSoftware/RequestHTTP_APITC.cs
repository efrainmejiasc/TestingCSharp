using com.sun.org.apache.xpath.@internal.functions;
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

        public async Task<string> HttpRequestApiTc(string url,object model)
        {
            string respuesta = string.Empty;

            var content = JsonConvert.SerializeObject(model);
            using (HttpClient client = new HttpClient())
            {
                SetCommonHeaders(client);

                Uri urlRequest = new Uri(url, UriKind.Absolute);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/vnd.bancolombia.v4+json"));
                if (response.IsSuccessStatusCode)
                    respuesta = await response.Content.ReadAsStringAsync();
                else
                    respuesta = await response.Content.ReadAsStringAsync();
            }

            return respuesta;
        }

        private HttpClient SetCommonHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", APIKEY);
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
    }
}
