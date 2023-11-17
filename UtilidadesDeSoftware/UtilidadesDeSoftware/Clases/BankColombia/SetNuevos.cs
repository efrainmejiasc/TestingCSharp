using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class SetNuevos
    {
        public static BankCoTransferBetweenAccountsResponseDto SetTransferBetweenAccountsRequest()
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

        public static BankCoTransfersBetweenAccountsResponseDto SetTransferBetweenAccountsResponse()
        {
            var response = new BankCoTransfersBetweenAccountsResponseDto
            {
                meta = new MetaTransfersBetweenAccountsResponse
                {
                    _messageId = Guid.NewGuid().ToString(),
                    _requestDateTime = DateTime.UtcNow,
                    _applicationId = Guid.NewGuid().ToString()
                },
                data = new DataTransfersBetweenAccountsResponse
                {
                    thirdpartyTransactionDetail = new ThirdpartyTransactionDetailTransfersBetweenAccountsResponse
                    {
                        transaction = new TransactionTransfersBetweenAccountsResponse
                        {
                            transactionDate = DateTime.Now,
                            amount = 1000
                        }
                    }
                }
            };

            return response;
        }


        public static BanCoAccountsTransfersVoiResponseDto SetAccountsTransfersVoidResponse()
        {
            var response = new BanCoAccountsTransfersVoiResponseDto
            {
                meta = new MetaAccountsTransfersVoiResponse
                {
                    _messageId = "c4e6bd04-5149-11e7-b114-b2f933d5fe66",
                    _requestDateTime = DateTime.UtcNow,
                    _applicationId = "acxff62e-6f12-42de-9012-3e7304418abd"
                },
                data = new DataAccountsTransfersVoiResponse
                {
                    voidedTransaction = true // Ejemplo de valor booleano
                }
            };

            return response;
        }


        public static BankCoAccountsTransfersVoidRequestDto SetAccountsTransfersVoidRequest()
        {
            var request = new BankCoAccountsTransfersVoidRequestDto
            {
                data = new DataAccountsTransfersVoidReques
                {
                    trackingId = "TRQuwkohH1f3", // Ejemplo de valor para trackingId
                    identificationAccount = new RelationshipIdAccountsTransfersVoidReques
                    {
                        relationshipId = "1" // Ejemplo de valor para relationshipId
                    },
                    destinationAccount = new DestinationAccountsTransfersVoidReques
                    {
                        type = "CUENTA_DE_AHORRO", // Ejemplo de valor para type
                        number = "51478643212" // Ejemplo de valor para number
                    },
                    transaction = new TransactionAccountsTransfersVoidReques
                    {
                        originalTrackingId = "TRQuwkohH0e2", // Ejemplo de valor para originalTrackingId
                        transactionDate = "2023-11-02T14:37:02" // Ejemplo de valor para transactionDate
                    }
                }
            };

            return request;
        }

    }
}
