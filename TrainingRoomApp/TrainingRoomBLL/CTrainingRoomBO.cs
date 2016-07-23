using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingRoomEF;
using TrainingRoomDAL;

namespace TrainingRoomBLL
    
 
{
    /// <summary>
    /// 
    /// </summary>
    public class CTrainingRoomBO:ITrainingRoomBO
    {
        protected CTrainingRoomDO objBO = new CTrainingRoomDO();      


        public IEnumerable<GetLocation_Types> procGetLocation()
        {
            return objBO.procGetLocation();
        }


        public IEnumerable<procGetCampus_Types> procGetCampus(string LocationName)
        {
            return objBO.procGetCampus(LocationName);
        }


        public IEnumerable<procGetTrainingRoomDetails_Types> procGetTrainingRoomDetails(string LocationName, string CampusName)
        {
            return objBO.procGetTrainingRoomDetails(LocationName, CampusName);
        }


        public IEnumerable<procRoomAvailability_Types> procRoomAvailability(string TrainingRoomID, DateTime FromDate, DateTime ToDate)
        {
            return objBO.procRoomAvailability(TrainingRoomID, FromDate, ToDate);

        }


        public void procTrainingRoomBlocking(int UserID, string TrainingRoomID, DateTime FromDate, DateTime ToDate)
        {
            objBO.procTrainingRoomBlocking(UserID, TrainingRoomID, FromDate, ToDate);
        }


     


        public IEnumerable<procGettingBookedDetails_types> procGettingBookedDetails(int UserID)
        {
            return objBO.procGettingBookedDetails(UserID);
        }


        public void DeleteBookingDetails(int SlotID)
        {
            objBO.DeleteBookingDetails(SlotID);
        }


        public void uspAddReviews(int UserID, string Reviews)
        {
            objBO.uspAddReviews(UserID, Reviews);
        }


        public IEnumerable<uspGetReviews_Types> uspGetReviews()
        {
            return objBO.uspGetReviews();
        }
    }
}
