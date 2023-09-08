using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Member.Models
{
    public class GymMember
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string PackageDuration { get; set; }
    }
}
