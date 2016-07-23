using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingRoomEF;

namespace TrainingRoomDAL
{
    interface ITrainingRoomDO
    {      
       IEnumerable<GetLocation_Types> procGetLocation();
       IEnumerable<procGetCampus_Types> procGetCampus(String LocationName);
       IEnumerable<procGetTrainingRoomDetails_Types> procGetTrainingRoomDetails(String LocationName, String CampusName);
       IEnumerable<procRoomAvailability_Types> procRoomAvailability(String TrainingRoomID, DateTime FromDate, DateTime ToDate);
       void procTrainingRoomBlocking(Int32 UserID, String TrainingRoomID, DateTime FromDate, DateTime ToDate);
       void DeleteBookingDetails(Int32 SlotID);       
       IEnumerable<procGettingBookedDetails_types> procGettingBookedDetails(Int32 UserID);
       void uspAddReviews(Int32 UserID, String Reviews);
       IEnumerable<uspGetReviews_Types> uspGetReviews();
    }
}
