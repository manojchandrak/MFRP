using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingRoomEF;
using TrainingRoomBLL;
using System.Web.Script.Serialization;
namespace TrainingRoomApp.Handlers
{
    /// <summary>
    /// Summary description for GetTrainingRoomDetails
    /// </summary>
    public class GetTrainingRoomDetails : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String LocationName;
            String CampusName;
            LocationName = context.Request.QueryString["LocationName"];
            CampusName = context.Request.QueryString["CampusName"];
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            IEnumerable<procGetTrainingRoomDetails_Types> TRoomList = BO.procGetTrainingRoomDetails(LocationName, CampusName).ToList();
            context.Response.ContentType = "text/plain";

            context.Response.Write(JSerializer.Serialize(TRoomList));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}