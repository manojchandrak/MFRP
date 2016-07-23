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
    /// Summary description for GetReviews
    /// </summary>
    public class GetReviews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            //For getting location       
            IEnumerable<uspGetReviews_Types> ReviewList = BO.uspGetReviews().ToList();
            context.Response.ContentType = "text/plain";
            context.Response.Write(JSerializer.Serialize(ReviewList));
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