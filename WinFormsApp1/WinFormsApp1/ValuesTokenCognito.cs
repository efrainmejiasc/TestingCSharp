using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class ValuesTokenCognito
    {

        //CognitoIdentity PoolID: us-east-1:06719c47-687b-4594-968c-06de0abd5940
        //UserPool
        //        PoolID: us-east-1_T66ODA7Q3
        //        AppClientID:grqme08erl1o9d5j50lek1dps

        public static string json = @"
        {
            ""auth"": {
                ""plugins"": {
                    ""awsCognitoAuthPlugin"": {
                        ""IdentityManager"": {
                            ""Default"": {}
                        },
                        ""CredentialsProvider"": {
                            ""CognitoIdentity"": {
                                ""Default"": {
                                    ""PoolId"": ""us-east-1:95376321-01c5-4162-b5b6-74f69f24344a"",
                                    ""Region"": ""us-east-1""
                                }
                            }
                        },
                        ""CognitoUserPool"": {
                            ""Default"": {
                                ""PoolId"": ""us-east-1_3415ZVUI6"",
                                ""AppClientId"": ""2utqqtn97015dgbmcq693it01n"",
                                ""Region"": ""us-east-1""
                            }
                        },
                        ""Auth"": {
                            ""Default"": {
                                ""authenticationFlowType"": ""USER_SRP_AUTH"",
                                ""OAuth"": {
                                    ""WebDomain"": ""prodmaasapp.auth.us-east-1.amazoncognito.com"",
                                    ""AppClientId"": ""2utqqtn97015dgbmcq693it01n"",
                                    ""SignInRedirectURI"": ""myapp://signin"",
                                    ""SignOutRedirectURI"": ""myapp://signout"",
                                    ""Scopes"": [
                                        ""aws.cognito.signin.user.admin"",
                                        ""email"",
                                        ""openid"",
                                        ""profile""
                                    ]
                                }
                            }
                        }
                    }
                }
            },
            ""storage"": {
                ""plugins"": {
                    ""awsS3StoragePlugin"": {
                        ""bucket"": ""maasapp-data"",
                        ""region"": ""us-east-1""
                    }
                }
            }
        }";

        public Auth auth { get; set; }
        public Storage storage { get; set; }
    }

    public class Auth
    {
        public Plugins plugins { get; set; }
    }

    public class Auth2
    {
        public Default Default { get; set; }
    }

    public class AwsCognitoAuthPlugin
    {
        public IdentityManager IdentityManager { get; set; }
        public CredentialsProvider CredentialsProvider { get; set; }
        public CognitoUserPool CognitoUserPool { get; set; }
        public Auth Auth { get; set; }
    }

    public class AwsS3StoragePlugin
    {
        public string bucket { get; set; }
        public string region { get; set; }
    }

    public class CognitoIdentity
    {
        public Default Default { get; set; }
    }

    public class CognitoUserPool
    {
        public Default Default { get; set; }
    }

    public class CredentialsProvider
    {
        public CognitoIdentity CognitoIdentity { get; set; }
    }

    public class Default
    {
        public string PoolId { get; set; }
        public string Region { get; set; }
        public string AppClientId { get; set; }
        public string authenticationFlowType { get; set; }
        public OAuth OAuth { get; set; }
    }

    public class IdentityManager
    {
        public Default Default { get; set; }
    }

    public class OAuth
    {
        public string WebDomain { get; set; }
        public string AppClientId { get; set; }
        public string SignInRedirectURI { get; set; }
        public string SignOutRedirectURI { get; set; }
        public List<string> Scopes { get; set; }
    }

    public class Plugins
    {
        public AwsCognitoAuthPlugin awsCognitoAuthPlugin { get; set; }
        public AwsS3StoragePlugin awsS3StoragePlugin { get; set; }
    }

    public class Root
    {
        public Auth auth { get; set; }
        public Storage storage { get; set; }
    }

    public class Storage
    {
        public Plugins plugins { get; set; }
    }
}
