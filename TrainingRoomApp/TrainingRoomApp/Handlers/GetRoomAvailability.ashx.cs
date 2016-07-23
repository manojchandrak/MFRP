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
    /// Summary description for GetRoomAvailability
    /// </summary>
    public class GetRoomAvailability : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            String TrainingRoomID;
            DateTime FromDate;
            DateTime ToDate;
            
            TrainingRoomID = context.Request.QueryString["TrainingRoomID"];
            FromDate = DateTime.Parse(context.Request.QueryString["FromDate"]);
            ToDate = DateTime.Parse(context.Request.QueryString["ToDate"]);
            CTrainingRoomBO BO = new CTrainingRoomBO();
            JavaScriptSerializer JSerializer = new JavaScriptSerializer();
            //For passing id,name to screen 2 and userid to procedure       
            IEnumerable<procRoomAvailability_Types> AvailabilityList = BO.procRoomAvailability(TrainingRoomID, FromDate, ToDate).ToList();
            
            context.Response.ContentType = "text/plain";
            if (AvailabilityList.Count() == 0)
            {
                context.Response.Write(0);
            }
            else
            {
                List<string> OutputList = new List<string>();
                OutputList.Add(AvailabilityList.ElementAt(0).UserID.ToString());
                //OutputList.Add(AvailabilityList.ElementAt(0).TrainingRoomID);
                OutputList.Add(AvailabilityList.ElementAt(0).FromDate.ToShortDateString());
                OutputList.Add(AvailabilityList.ElementAt(0).ToDate.ToShortDateString());
                context.Response.Write(JSerializer.Serialize(OutputList));
                
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