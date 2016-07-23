using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using TrainingRoomBLL;
using TrainingRoomEF;

namespace TrainingRoomApp.Handlers
{
    /// <summary>
    /// Summary description for AddBookingDetails
    /// </summary>
    public class AddBookingDetails : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String TrainingRoomID;
            Int32 UserID;
            DateTime FromDate;
            DateTime ToDate;
            TrainingRoomID = context.Request.QueryString["TrainingRoomID"];
            UserID = int.Parse(context.Request.QueryString["UserID"]);
            FromDate = DateTime.Parse(context.Request.QueryString["FromDate"]);
            ToDate = DateTime.Parse(context.Request.QueryString["ToDate"]);
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            BO.procTrainingRoomBlocking(UserID, TrainingRoomID, FromDate, ToDate); 
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