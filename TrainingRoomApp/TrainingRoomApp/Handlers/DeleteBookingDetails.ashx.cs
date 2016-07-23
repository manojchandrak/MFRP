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
    /// Summary description for DeleteBookingDetails
    /// </summary>
    public class DeleteBookingDetails : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Int32 SlotID;
            SlotID = int.Parse(context.Request.QueryString["SlotID"]);
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            BO.DeleteBookingDetails(SlotID); 
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