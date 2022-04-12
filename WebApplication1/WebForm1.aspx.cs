using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CrmServiceClient crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["MyCDSServer"].ConnectionString);
                if (crmSvc.IsReady)
                {
                    WhoAmIRequest req = new WhoAmIRequest();
                    WhoAmIResponse res = (WhoAmIResponse)crmSvc.Execute(req);
                    Response.Write("UserID:" + res.UserId);
                }
                else
                {
                    Response.Write($"Error occurred:{crmSvc.LastCrmError}");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Error while connecting to Dataverse:{ex.Message}");
            }
        }
    }
}