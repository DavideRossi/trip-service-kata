using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.Model;

namespace TripServiceKata.Services
{
    public interface ITripService
    {
        List<Trip> GetTripsByUser(User user);
    }

    public class TripService : ITripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            List<Trip> tripList = new List<Trip>();
            User loggedUser = GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach (User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    tripList = getTrips(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }

        protected virtual User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }

        protected virtual List<Trip> getTrips(User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
