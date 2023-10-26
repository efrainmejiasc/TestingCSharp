using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class SetNuevos
    {
        public static BankCoTransferBetweenAccountsResponseDto SetTransferBetweenAccountsResponse()
        {
            var response = new BankCoTransferBetweenAccountsResponseDto
            {
                meta = new MetaTransferBetweenAccountsResponse
                {
                    _messageId = Guid.NewGuid().ToString(),
                    _requestDateTime = DateTime.UtcNow,
                    _applicationId = Guid.NewGuid().ToString()
                },
                data = new DataTransferBetweenAccountsResponse
                {
                    thirdpartyTransactionDetail = new ThirdpartyTransactionDetailTransferBetweenAccountsResponse
                    {
                        transaction = new TransactionTransferBetweenAccountsResponse
                        {
                            transactionDate = DateTime.Now,
                            amount = 1000
                        }
                    }
                }
            };

            return response;
        }


        public static BanCoAccountsTransfersVoiResponseDto SetAccountsTransfersVoiResponse()
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


        public static BankCoAccountsTransfersVoidRequestDto SetAccountsTransfersVoidReques()
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
                        transactionDate = DateTime.UtcNow // Ejemplo de valor para transactionDate
                    }
                }
            };

            return request;
        }

    }
}
