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



        public static BankCoCIRetrieveTermsRequestDto SetCIRetrieveTerms()
        {
            var request = new BankCoCIRetrieveTermsRequestDto
            {
                data = new DataCIRetrieveTermsRequest
                {
                    customer = new CustomerCIRetrieveTermsRequest
                    {
                        identification = new IdentificationCIRetrieveTermsRequest
                        {
                            relationshipId = "ExampleRelationshipId"
                        }
                    }
                }
            };

            return request;
        }


        public static BankCoCIRetrieveStatusTransactionRequestDto SetCIRetrieveStatus()
        {
            var requestDto = new BankCoCIRetrieveStatusTransactionRequestDto
            {
                data = new DataCIRetrieveStatusTransactionRequest
                {
                    operation = new OperationCIRetrieveStatusTransactionRequest
                    {
                        customer = new CustomerCIRetrieveStatusTransactionRequest
                        {
                            identification = new IdentificationCIRetrieveStatusTransactionRequest
                            {
                                relationshipId = "R7664a8c9a83e4ddf860c9c0a3e0416f3"
                            }
                        },
                        identifierRecordPrepared = "ExampleIdentifierRecordPrepared"
                    }
                }
            };

            return requestDto;
        }
    }
}

