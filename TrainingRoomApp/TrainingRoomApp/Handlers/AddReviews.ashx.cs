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
    /// Summary description for AddReviews
    /// </summary>
    public class AddReviews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Int32 UserID;
            String Reviews;           
            UserID = int.Parse(context.Request.QueryString["UserID"]);
            Reviews = context.Request.QueryString["Reviews"];
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            BO.uspAddReviews(UserID, Reviews); 
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