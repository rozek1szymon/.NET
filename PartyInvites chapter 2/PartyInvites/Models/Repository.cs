using System.Collections.Generic;
namespace PartyInvites.Models
{
    public static class Repository
    {
        //  we are reating list of our guests of class GuestResponses
        private static List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable <GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }
        //this is a functcio which is adding a guest to our list
        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}