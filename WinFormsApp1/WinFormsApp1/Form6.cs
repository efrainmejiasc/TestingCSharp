using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        string objAuthTCStr = string.Empty;
        string privateKey = @"-----BEGIN OPENSSH PRIVATE KEY-----
b3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW
QyNTUxOQAAACCtPFqfeKLKqPn4dFtI2eyj0yRpgsuFYoZ47OhWQkeEdAAAAJj8hYz0/IWM
9AAAAAtzc2gtZWQyNTUxOQAAACCtPFqfeKLKqPn4dFtI2eyj0yRpgsuFYoZ47OhWQkeEdA
AAAED2cfX43xkzyF/2NSjHaiM5w+BkviiAzBppvJLGWeHg4q08Wp94osqo+fh0W0jZ7KPT
JGmCy4Vihnjs6FZCR4R0AAAAFXZpY3RvckBrZXRvcm8uZGlnaXRhbA==
-----END OPENSSH PRIVATE KEY-----";

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try {
                ConnectToSftp();
                // Conectar();
                //Conectar2(); 

            }
            catch(Exception ex)
            {
                var error = ex.ToString();
            }


        } 

        private void ObtenerValoresTC()
        {
            objAuthTCStr = ValuesTokenCognito.json;
            var objAuth = JsonConvert.DeserializeObject<ValuesTokenCognito>(objAuthTCStr);
        }


        public string GetPrivateKey()
        {
            var result = privateKey;
            result = result.Replace("-----BEGIN OPENSSH PRIVATE KEY-----", "-----BEGIN OPENSSH PRIVATE KEY-----\r\n")
                           .Replace("-----END OPENSSH PRIVATE KEY-----", "\r\n-----END OPENSSH PRIVATE KEY-----")
                           .Replace("\r\n", "")
                           .Replace("\n", "")
                           .Replace("\r", "");

            result = Regex.Replace(privateKey, @"\r\n?|\n", "");

            return result;

        }

        //var client = new SftpClient("eu1.sftp.clevertap.com", 22, "1666379008@eu1.sftp.clevertap.com", "1666379008"); // You can aslo use a private key file


        public void Conectar2()
        {
            bool isConnected = TestSftpConnection("eu1.sftp.clevertap.com","1666379008", @"C:\Users\DELL\Downloads\TaskMaas\CleverTab\clevertap_maasapp");

        }

        public bool TestSftpConnection(string host, string user, string keyFilePath, int port = 22)
        {
            try
            {
                // Define el comando a ejecutar
                string command = "sftp";
                //string arguments = $"-i \"{keyFilePath}\" -oPort={port} {user}@{host}";
                string arguments = $"-i \"{keyFilePath}\" {user}@{host}";

                // Configura el proceso
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Utiliza cmd.exe para ejecutar el comando SFTP en Windows
                    Arguments = $"/c \"{command} {arguments}\"", // Formato correcto para ejecutar el comando con argumentos en cmd.exe
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                // Inicia el proceso
                using (Process process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();

                    // Lee las salidas estándar y de error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Verifica si hay un mensaje de error
                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine($"Error: {error}");
                        return false;
                    }

                    // Comprueba si la salida contiene texto que indique una conexión exitosa
                    if (output.Contains("sftp>"))
                    {
                        Console.WriteLine("SFTP session initiated successfully.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to initiate SFTP session.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    

    public bool Conectar()
        {
            var host = "eu1.sftp.clevertap.com";
            var username = "1666379008";

            string privateKey = GetPrivateKey();
            using (var privateKeyStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(privateKey)))
            {
                var keyFile = new PrivateKeyFile(privateKeyStream);
                var keyFiles = new[] { keyFile };
                var authMethod = new PrivateKeyAuthenticationMethod(username, keyFiles);
                var connectionInfo = new ConnectionInfo(host, 22, username, authMethod);

                using (var client = new SftpClient(connectionInfo))
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        client.Disconnect();
                        return true;
                    }

                        return false;
                }
            }
        }

        public bool ConnectToSftp()
        {
            string host = "eu1.sftp.clevertap.com";
            string username = "1666379008";
            string keyFilePath = @"C:\Users\DELL\Downloads\TaskMaas\CleverTab\clevertap_maasapp";

            var result = false;
            var keyFile = new PrivateKeyFile(keyFilePath);
            var keyFiles = new[] { keyFile };

            var connectionInfo = new ConnectionInfo(host, username, new PrivateKeyAuthenticationMethod(username, keyFiles));

            using (var sftp = new SftpClient(connectionInfo))
            {
                sftp.Connect();
                if (sftp.IsConnected)
                {
                    result = true;
                    sftp.Disconnect();
                }
            }

            return result;
        }



        public async Task<bool> WriteCsvAsync2()
        {
            var host = "eu1.sftp.clevertap.com";
            var username = "1666379008";
            var privateKeyPath = @"~/.ssh/clevertap_maasa"; // Ruta a tu llave privada SSH
            var remoteFilePath = "/ruta/en/el/servidor/archivo.csv";
            var localFilePath = "ruta/de/tu/archivo.csv";

            try
            {
                // Leer la llave privada SSH
                PrivateKeyFile privateKeyFile = new PrivateKeyFile(privateKeyPath);

                // Configurar la autenticación con la llave privada
                PrivateKeyAuthenticationMethod privateKeyAuth = new PrivateKeyAuthenticationMethod(username, privateKeyFile);

                // Configurar las opciones de conexión
                ConnectionInfo connectionInfo = new ConnectionInfo(host, username, privateKeyAuth);

                // Crear cliente SFTP
                using (var client = new SftpClient(connectionInfo))
                {
                    client.Connect();

                    if (!client.IsConnected)
                    {
                        Console.WriteLine("No se pudo establecer la conexión con el servidor.");
                        return false;
                    }

                    if (File.Exists(localFilePath))
                    {
                        using (var fileStream = File.OpenRead(localFilePath))
                        {
                            await Task.Run(() => client.UploadFile(fileStream, remoteFilePath));
                        }
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            return true;
        }


    }
}
