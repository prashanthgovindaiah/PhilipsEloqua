using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EloquaCloudProductConnector
{
    public class EloquaInstance
    {

        private EloquaServiceNew.EloquaServiceClient serviceProxy;
        private EloquaProgramService.ExternalActionServiceClient programServiceProxy;

        private DateTime dttLastEloquaAPICall;

        private string strInstanceName = "";
        private string strUserID = "";
        private string strUserPassword = "";

        public EloquaInstance(string InstanceName, string UserID, string UserPassword)
        {
            strInstanceName = InstanceName;
            strUserID = UserID;
            strUserPassword = UserPassword;

            serviceProxy = new EloquaServiceNew.EloquaServiceClient();
            serviceProxy.ClientCredentials.UserName.UserName = strInstanceName + "\\" + strUserID;
            serviceProxy.ClientCredentials.UserName.Password = strUserPassword;


            programServiceProxy = new EloquaProgramService.ExternalActionServiceClient();
            programServiceProxy.ClientCredentials.UserName.UserName = strInstanceName + "\\" + strUserID;
            programServiceProxy.ClientCredentials.UserName.Password = strUserPassword;

           // ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            //dttLastEloquaAPICall = DateTime.Now.ToUniversalTime().Subtract(TimeSpan.FromMilliseconds(1000));

        }
 

    }
}