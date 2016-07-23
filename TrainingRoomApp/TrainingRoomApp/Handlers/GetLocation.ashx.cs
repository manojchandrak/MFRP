using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using TrainingRoomEF;
using TrainingRoomBLL;

namespace TrainingRoomApp.Handlers
{
    /// <summary>
    /// Summary description for GetLocation
    /// </summary>
    public class GetLocation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {           
            
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            //For getting location       
            IEnumerable<GetLocation_Types> NameIdList = BO.procGetLocation().ToList();
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