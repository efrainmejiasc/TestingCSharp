using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesDeSoftware.Clases.BankColombia;

namespace UtilidadesDeSoftware.Clases.BankColombia.Helper
{
    public class SetObjectClass
    {
        public static BankCoCIPrepareTransactionRequestDto SetCIPrepareTransactionRequest()
        {
            var requestDto = new BankCoCIPrepareTransactionRequestDto
            {
                data = new DataCIPrepareTransactionRequest
                {
                    operation = new OperationCIPrepareTransactionRequest
                    {
                        customer = new CustomerCIPrepareTransactionRequest
                        {
                            identification = new IdentificationCIPrepareTransactionRequest
                            {
                                relationshipId = "12345"
                            }
                        },
                        termsCondition = new TermsConditionCIPrepareTransactionRequest
                        {
                            gatewayTerms = new GatewayTermsCIPrepareTransactionRequest
                            {
                                acceptance = true
                            }
                        },
                        contactDetail = new ContactDetailCIPrepareTransactionRequest
                        {
                            fullName = "John Doe",
                            mobilePhoneNumber = "123456890",
                            email = "johndoe@example.com"
                        },
                        payment_method = new PaymentMethodCIPrepareTransactionRequest
                        {
                            type = "Credit",
                            user_type = "1",
                            financial_institution_code = "XYZ",
                            payment_description = "Payment for goods"
                        },
                        amount = 15000,
                        redirect_url = "https://example.com/redirect"
                    },
                    confirmId = "ABC123"
                }
            };

            return requestDto;
        }
    


    //public static BankCoCIPrepareTransactionRequestSignature SetCIPrepareTransactionRequest()
    //{
    //    var exampleObject = new BankCoCIPrepareTransactionRequestSignature
    //    {
    //        type = "object",
    //        required = new List<string> { "data" },
    //        properties = new PropertiesCIPrepareTransactionRequest
    //        {
    //            data = new DataCIPrepareTransactionRequest
    //            {
    //                type = "object",
    //                required = new List<string> { "operation", "confirmId" },
    //                properties = new PropertiesCIPrepareTransactionRequest
    //                {
    //                    operation = new OperationCIPrepareTransactionRequest
    //                    {
    //                        type = "object",
    //                        required = new List<string>
    //                        {
    //                            "customer",
    //                            "termsCondition",
    //                            "contactDetail",
    //                            "payment_method",
    //                            "amount",
    //                            "redirect_url"
    //                        },
    //                        description = "Información del cliente Bancolombia.",
    //                        properties = new PropertiesCIPrepareTransactionRequest
    //                        {
    //                            customer = new CustomerCIPrepareTransactionRequest
    //                            {
    //                                type = "object",
    //                                required = new List<string> { "identification" },
    //                                properties = new PropertiesCIPrepareTransactionRequest
    //                                {
    //                                    identification = new IdentificationCIPrepareTransactionRequest
    //                                    {
    //                                        type = "object",
    //                                        required = new List<string> { "relationshipId" },
    //                                        properties = new PropertiesCIPrepareTransactionRequest
    //                                        {
    //                                            relationshipId = new RelationshipIdCIPrepareTransactionRequest
    //                                            {
    //                                                type = "string",
    //                                                minLength = 1,
    //                                                maxLength = 33,
    //                                                example = "F1E4F933826EE5FF33",
    //                                                description = "identificador de la relacion de autorizacion establecida entre el tercero y el cliente para el producto seleccionado"
    //                                            }
    //                                        }
    //                                    }
    //                                }
    //                            },
    //                            termsCondition = new TermsConditionCIPrepareTransactionRequest
    //                            {
    //                                type = "object",
    //                                required = new List<string> { "gatewayTerms" },
    //                                properties = new PropertiesCIPrepareTransactionRequest
    //                                {
    //                                    gatewayTerms = new GatewayTermsCIPrepareTransactionRequest
    //                                    {
    //                                        type = "object",
    //                                        required = new List<string> { "acceptance" },
    //                                        properties = new PropertiesCIPrepareTransactionRequest
    //                                        {
    //                                            acceptance = new AcceptanceCIPrepareTransactionRequest
    //                                            {
    //                                                type = "boolean",
    //                                                maxLength = 10,
    //                                                example = "true",
    //                                                description = "Indica si el cliente acepto los términos y condiciones  de la pasarela de pago",
    //                                                @enum = new List<bool> { true, false }
    //                                            }
    //                                        }
    //                                    }
    //                                }
    //                            },
    //                            contactDetail = new ContactDetailCIPrepareTransactionRequest
    //                            {
    //                                type = "object",
    //                                required = new List<string> { "fullName", "mobilePhoneNumber", "email" },
    //                                properties = new PropertiesCIPrepareTransactionRequest
    //                                {
    //                                    fullName = new FullNameCIPrepareTransactionRequest
    //                                    {
    //                                        type = "string",
    //                                        minLength = 1,
    //                                        maxLength = 50,
    //                                        example = "MAURICIO ANTONIO SUAREZ GOMEZ",
    //                                        description = "Corresponde al nombre completo del cliente. Para persona natural, el nombre completo corresponderá a la información de Primer nombre, Segundo nombre, Primer apellido y Segundo apellido. Para persona Juridica el nombre Completo corresponde a la Razón Social."
    //                                    },
    //                                    mobilePhoneNumber = new MobilePhoneNumberCIPrepareTransactionRequest
    //                                    {
    //                                        type = "string",
    //                                        minLength = 1,
    //                                        maxLength = 20,
    //                                        example = "573152609876",
    //                                        description = "Número de teléfono contacto del cliente"
    //                                    },
    //                                    email = new EmailCIPrepareTransactionRequest
    //                                    {
    //                                        type = "string",
    //                                        minLength = 1,
    //                                        maxLength = 250,
    //                                        example = "mauro@correo.com.co",
    //                                        description = "Corresponde a la dirección de correo electrónico del cliente"
    //                                    }
    //                                }
    //                            },
    //                            payment_method = new PaymentMethodCIPrepareTransactionRequest
    //                            {
    //                                type = "object",
    //                                required = new List<string> { "type", "user_type", "financial_institution_code", "payment_description" },
    //                                properties = new PropertiesCIPrepareTransactionRequest
    //                                {
    //                                    type = new TypeCIPrepareTransactionRequest
    //                                    {
    //                                        type = "string",
    //                                        minLength = 1,
    //                                        maxLength = 20,
    //                                        example = "PSE",
    //                                        description = "Método de pago utilizado para la transacción cash in"
    //                                    },
    //                                    user_type = new UserTypeCIPrepareTransactionRequest
    //                                    {
    //                                        type = "string",
    //                                        minLength = 1,
    //                                        maxLength = 1,
    //                                        example = "1",
    //                                        description = "Tipo de persona que realiza la transacción",
    //                                        @enum = new List<string> { "0", "1" }
    //                                    },
    //                                    financial_institution_code = new FinancialInstitutionCodeCIPrepareTransactionRequest
    //                                    {
    //                                        type = "string",
    //                                        minLength = 1,
    //                                        maxLength = 4,
    //                                        example = "1002",
    //                                        description = "Código que identifica la institución financiera de la cuenta depósito origen de la transferencia"
    //                                    },
    //                                    payment_description = new PaymentDescriptionCIPrepareTransactionRequest
    //                                    {
    //                                        type = "string",
    //                                        minLength = 1,
    //                                        maxLength = 64,
    //                                        example = "Recarga de monedero",
    //                                        description = "Texto libre para registro de información de referencia para el pago"
    //                                    }
    //                                }
    //                            },
    //                            amount = new AmountCIPrepareTransactionRequest
    //                            {
    //                                type = "number",
    //                                minLength = 1,
    //                                example = 15000,
    //                                description = "Valor del movimiento expresado en pesos colombianos."
    //                            },
    //                            redirect_url = new RedirectUrlCIPrepareTransactionRequest
    //                            {
    //                                type = "string",
    //                                minLength = 1,
    //                                maxLength = 250,
    //                                example = "www.comercio.com.co",
    //                                description = "URL para redireccionar al cliente una vez que se culmina la transacción"
    //                            }
    //                        }
    //                    },
    //                    confirmId = new ConfirmIdCIPrepareTransactionRequest
    //                    {
    //                        type = "string",
    //                        maxLength = 700,
    //                        example = "g6XCQePJOUg0APhNk/jmH8g8CB8OvucPLBuajG4VRLJpYzJPk77Qo/BQru04PRPPkKesd/qUuF/6qAglVyA9UJXwIObDOqKhe4aSWO2UV049NsFFWXMQO3YRQNVHJXgbDI+kzR4UpSYvlox4f5g1+RXqvMLQN4FTgLxEizP5onNEhkbuJh2w/ZjBFKXf4/g9qZgFOtnkdOhwmPdkJFGIvOmFa9YuYBDlrzAe+EI6VeGwLE6uIZuCqu8oIoR8AqzLy4LMplr2wGWv0b4hUXAcEQgOHZ6E5S88VAVrGCBTX8C9pnFXB6cBmj+ZsC7Z2Y2FViWYlJhxi6SbsMp1deYVz9PSXzSq+5cZiQM9bZXjHuLwcFAjX5uZ6pXuNtSeN+656RpBaH48EOwKTlFoGX9/fOYBO0Kg8DqVcvGzEYXzg7+4OmmmFB8MUH1Oxk1Q11lWJapHpR4+NPRPPjMjsfMf0yX5Stvu9XqjWPdhdWXMHFH4UV0WCOQ+LmUOHdb3Zb5rpMHE0MjmRj+d/WaQhrOZvA59zV0S8QGirzp20wK/EhTqwpspwPkz8lkyZrL/M45rMJ8=",
    //                        description = "Es el Token de respuesta devuelto por la pasarela de pago"
    //                    }
    //                }
    //            }
    //        }
    //    };

    //    return exampleObject;
    //}
}

}

