using System;
using Rock.Paper.Scissors;

namespace Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class UserRound 
    {
        public int UserMove { get; set; }
    }
}
