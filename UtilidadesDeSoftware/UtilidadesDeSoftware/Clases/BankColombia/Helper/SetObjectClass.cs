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
                            relationshipId = "R7664a8c9a83e4ddf860c9c0a3e0416f3"
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

        public static BankCoTransferBetweenAccountsResponseDto SetTransferBetweenAccounts()
        {
            var requestDto = new BankCoTransferBetweenAccountsResponseDto
            {
                data = new DataTransferBetweenAccountsResponse
                {
                    customer = new CustomerTransferBetweenAccountsResponse
                    {
                        identification = new IdentificationTransferBetweenAccountsResponse
                        {
                            relationshipId = "F1E4F933826EE5FF33"
                        }
                    },
                    transaction = new TransactionTransferBetweenAccountsResponse
                    {
                        user = "sve",
                        trackingId = "TRQuwkohH0e2",
                        key = "Crédito",
                        amount = "50000",
                        reference1 = "1234567890",
                        transactionDate = "2021-09-08T10:42:13"
                    },
                    thirdpartyDestinationAccount = new ThirdpartyDestinationAccountTransferBetweenAccountsResponse
                    {
                        account = new AccountTransferBetweenAccountsResponse
                        {
                            type = "CUENTA_DE_AHORRO",
                            number = "51478643212"
                        },
                        identification = new IdentificationAccountTransferBetweenAccountsResponse
                        {
                            type = "NIT",
                            number = "900589687"
                        }
                    }

                }
            };

            return requestDto;
        }


 

    }
}

