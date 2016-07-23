using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingRoomEF;

namespace TrainingRoomDAL
{
    public class CTrainingRoomDO:ITrainingRoomDO
    {
        protected TrainingRoomAppDBEntities objDO = new TrainingRoomAppDBEntities();       


        public IEnumerable<GetLocation_Types> procGetLocation()
        {
            return objDO.procGetLocation();
        }


        public IEnumerable<procGetCampus_Types> procGetCampus(string LocationName)
        {
            return objDO.procGetCampus(LocationName);
        }


        public IEnumerable<procGetTrainingRoomDetails_Types> procGetTrainingRoomDetails(string LocationName, string CampusName)
        {
            return objDO.procGetTrainingRoomDetails(LocationName, CampusName);
        }


        public IEnumerable<procRoomAvailability_Types> procRoomAvailability(string TrainingRoomID, DateTime FromDate, DateTime ToDate)
        {
            return objDO.procRoomAvailability(TrainingRoomID, FromDate, ToDate);
        }


        public void procTrainingRoomBlocking(int UserID, string TrainingRoomID, DateTime FromDate, DateTime ToDate)
        {
            objDO.procTrainingRoomBlocking(UserID, TrainingRoomID, FromDate, ToDate);
        }

        public IEnumerable<procGettingBookedDetails_types> procGettingBookedDetails(int UserID)
        {
           return objDO.procGettingBookedDetails(UserID);
        }


        public void DeleteBookingDetails(int SlotID)
        {
            objDO.DeleteBookingDetails(SlotID);
        }


        public void uspAddReviews(int UserID, string Reviews)
        {
            objDO.uspAddReviews(UserID, Reviews);
        }


        public IEnumerable<uspGetReviews_Types> uspGetReviews()
        {
            return objDO.uspGetReviews();
        }
    }
}
