using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingRoomBLL;
using TrainingRoomEF;
using System.Web.Script.Serialization;

namespace TrainingRoomApp.Handlers
{
    /// <summary>
    /// Summary description for GetCampus
    /// </summary>
    public class GetCampus : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
          String LocationName;
            LocationName = context.Request.QueryString["LocationName"];
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();            
            //For passing id,name to screen 2.       
            IEnumerable<procGetCampus_Types> NameIdList = BO.procGetCampus(LocationName).ToList();
            context.Response.ContentType = "text/plain";
            
            context.Response.Write(JSerializer.Serialize(NameIdList));
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