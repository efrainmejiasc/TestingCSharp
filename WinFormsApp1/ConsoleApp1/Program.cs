using System;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Escriba '1' para cifrar o '2' para descifrar: ");
        string option = Console.ReadLine();

        if (option == "1")
        {
            //Console.Write("Mensaje a cifrar: ");
            string yourMessage = @"{
  ""firmwareMobil"": ""i-EDC683D5-B52D-423F-9655-DC493BB2C6E3"",
  ""data"": {
    ""operation"": {
      ""customer"": {
        ""identification"": {
          ""relationshipId"": ""F1E4F933826EE5FF33""
        }
      },
      ""termsCondition"": {
        ""gatewayTerms"": {
          ""acceptance"": true
        }
      },
      ""contactDetail"": {
        ""fullName"": ""MAURICIO ANTONIO SUAREZ GOMEZ"",
        ""mobilePhoneNumber"": ""573152609876"",
        ""email"": ""mauro@correo.com.co""
      },
      ""payment_method"": {
        ""type"": ""PSE"",
        ""user_type"": ""1"",
        ""financial_institution_code"": ""1002"",
        ""payment_description"": ""Recarga de monedero""
      },
      ""amount"": 15000,
      ""redirect_url"": ""www.comercio.com.co""
    },
    ""confirmId"": ""g6XCQePJOUg0APhNk/jmH8g8CB8OvucPLBuajG4VRLJpYzJPk77Qo/BQru04PRPPkKesd/qUuF/6qAglVyA9UJXwIObDOqKhe4aSWO2UV049NsFFWXMQO3YRQNVHJXgbDI+kzR4UpSYvlox4f5g1+RXqvMLQN4FTgLxEizP5onNEhkbuJh2w/ZjBFKXf4/g9qZgFOtnkdOhwmPdkJFGIvOmFa9YuYBDlrzAe+EI6VeGwLE6uIZuCqu8oIoR8AqzLy4LMplr2wGWv0b4hUXAcEQgOHZ6E5S88VAVrGCBTX8C9pnFXB6cBmj+ZsC7Z2Y2FViWYlJhxi6SbsMp1deYVz9PSXzSq+5cZiQM9bZXjHuLwcFAjX5uZ6pXuNtSeN+656RpBaH48EOwKTlFoGX9/fOYBO0Kg8DqVcvGzEYXzg7+4OmmmFB8MUH1Oxk1Q11lWJapHpR4+NPRPPjMjsfMf0yX5Stvu9XqjWPdhdWXMHFH4UV0WCOQ+LmUOHdb3Zb5rpMHE0MjmRj+d/WaQhrOZvA59zV0S8QGirzp20wK/EhTqwpspwPkz8lkyZrL/M45rMJ8=""
  }
}";

            byte[] nonce = new byte[12];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(nonce);
            }

           // Console.Write("Ingrese la clave en base64: ");
            string yourBase64Key = "qmiVmjhHfNR+XfHtiPPIbtNLFGqlY+5q++SiFbCX5HM=";

            byte[] key = Convert.FromBase64String(yourBase64Key);

            using (var cipher = new AesGcm(key))
            {
                byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(yourMessage);
                byte[] ciphertext = new byte[plaintextBytes.Length];
                byte[] tag = new byte[16];

                cipher.Encrypt(nonce, plaintextBytes, ciphertext, tag);

                Console.WriteLine("Mensaje cifrado: " + Convert.ToBase64String(ciphertext));
                Console.WriteLine("Tag: " + Convert.ToBase64String(tag));
                Console.WriteLine("Nonce: " + Convert.ToBase64String(nonce));

                Console.ReadKey();
            }
        }
        else if (option == "2")
        {
            //Console.Write("Ingrese el texto cifrado en base64: ");
            string yourBase64Ciphertext = @"UAqMBPSOsifQXQ7xewh7f/xBCtehvOjpUb+Mj27jWsCDn6NGlQi2lyAlYbtF1isM0eakI/L1QSrHuE7Ioz7xvxVNacNJn1HNF4GrY0LNApJ1bsCSIFbin5UG8CtpJXeSEx6dd9mUV2YPMgNXvpMd4iuFZ9WROrGFiAEljzF/9NTs9OBZosKoqQAUBMLPAH6WXBOf5CmtKyH4pNJxDZ75oaoADrJMABACba1CLd0aDo6v2fx4LukDVGEqfkcSrFAIMq8eauIvmBlK+Rm9GWt/3vxLyjczzvHFaJnzcOO3qivTCNDVJVqVi+9cowjDNgvfaXKwW48JMmXGFg9hjUvUoklmSbpH1MxFLsUGbSdk23hSQHV8CJkw+6DGdAVYbN37hxGmB/57wCW68T4DR9CveCP+dJsnSvdItqgsJsdpxMF8wjm/fm7tTMgc/WDXTvjzmRFmeEgI5nxFERX9lQkhe8zY1ov5j53Enzv6JemJVrgGdOCyGsQ2Dq0UookjtG+9tkVY6NzN6s5b1sBypoK17V1l+wYbFHsJgMvpispwhS00B0HP0kHMV/PO4t0VBvxhI9eQLV6Sqo0dVibsgLlL7q3cS1+jRq3mEf/v6TYVqWgCqYhqppa1Hdmi5tmorSB5yCoWJhOli800S1vN4FW72/10z0xFtXVQ13xjDmlFrdzuVPUTc5EKCGKb89ZHkL5Ge8ONd/8oufUKQIJDXSw5Cg6OCCrv/QDak0Hi49Y8KfLEIPItm2//lg0V4g3GS5T0x0ICbSwi84NLcGEMoePbLQtL/65sPczlvIg+dLh318sCis1YwttvA3G36dXE9ZnkB5fC0QmujNQ4twcoeWQ4QBTvMzF9rscH9p49AQWvO0g2ATe+LRohTtbmEWFSgSsC0GS9AAc6Y85wxTqZS7dIkAPCB7nhCHhhqvZM5bnJB3CLgNm5cxzkupOkWNKxt3fpuo/sOVQXAE+5UzpVv/nqDJNBB6ogaMDDyd7iIpbBCej0hXsNPMaZQf0BuV2H+mf3/dor4TorWyJyCTBzkoQ=";

            //Console.Write("Ingrese la clave en base64: ");
            string yourBase64Key = "4OYdBlwv/xdmHiR+LRgwfH+9MO9hG4w9i4xfngiCpNY=";

            //Console.Write("Ingrese el nonce en base64: ");
            string yourBase64Nonce = "E4wsA5D0R6B4BetU";

            //Console.Write("Ingrese el tag en base64: ");
            string yourBase64Tag = "LDp5TGSkFiMtU7SI84LSfQ==";

            byte[] ciphertext = Convert.FromBase64String(yourBase64Ciphertext);
            byte[] key = Convert.FromBase64String(yourBase64Key);
            byte[] nonce = Convert.FromBase64String(yourBase64Nonce);
            byte[] tag = Convert.FromBase64String(yourBase64Tag);

            using (var cipher = new AesGcm(key))
            {
                byte[] plaintext = new byte[ciphertext.Length];

                cipher.Decrypt(nonce, ciphertext, tag, plaintext);

                Console.WriteLine("Mensaje descifrado: " + System.Text.Encoding.UTF8.GetString(plaintext));
            }

            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Opción inválida. Por favor, escriba '1' para cifrar o '2' para descifrar.");
        }

    }
}
