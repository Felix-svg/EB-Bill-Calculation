using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillCalculation
{
    public class User
    {
        public string MeterID { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string MailId { get; set; }
        public int UnitsUsed { get; set; } = 0;

        public User()
        {

        }

        public User(string meterId, string username, string phoneNumber, string mailId, int unitsUsed)
        {
            MeterID = meterId;
            Username = username;
            PhoneNumber = phoneNumber;
            MailId = mailId;
            UnitsUsed = unitsUsed;
        }
    }
}