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
    /// Summary description for GetBookedDetails
    /// </summary>
    public class GetBookedDetails : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Int32 UserID;
            UserID = int.Parse(context.Request.QueryString["UserID"]);
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            //For passing id,name to screen 2 and userid to procedure       
            IEnumerable<procGettingBookedDetails_types> GetBookedList = BO.procGettingBookedDetails(UserID).ToList();

            context.Response.ContentType = "text/plain";
            if (GetBookedList.Count() == 0)
            {
                context.Response.Write(0);
            }
            else
            {
                context.Response.Write(JSerializer.Serialize(GetBookedList));
            }
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