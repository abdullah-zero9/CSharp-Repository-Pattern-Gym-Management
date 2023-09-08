using Gym_Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Member.Repositories
{
    public class MemberRep : IRepository
    {
        public void Delete(int memberId)
        {
            GymMember gymMember = MemberDB.GymMemberList.FirstOrDefault(x => x.MemberId == memberId);
            MemberDB.GymMemberList.Remove(gymMember);
        }

        public IEnumerable<GymMember> ShowAll()
        {
            return MemberDB.GymMemberList;
        }

        public GymMember FindMemberByID(int MemberId)
        {
            GymMember gymMember = MemberDB.GymMemberList.FirstOrDefault(x => x.MemberId == MemberId);
            return gymMember;
        }

        public void Insert(GymMember gymMember)
        {
            MemberDB.GymMemberList.Add(gymMember);
        }

        public void Update(GymMember gymMember)
        {
            GymMember _GymMember = MemberDB.GymMemberList.FirstOrDefault(x => x.MemberId == gymMember.MemberId);
            if (gymMember.MemberName != null)
            {
                _GymMember.MemberName = gymMember.MemberName;
            }
            if (gymMember.Age != 0)
            {
                _GymMember.Age = gymMember.Age;
            }
        }
    }
}
