using Gym_Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Member.Repositories
{
    public interface IRepository
    {
        IEnumerable<GymMember> ShowAll();
        GymMember FindMemberByID(int MemberId);
        void Insert(GymMember gymMember);
        void Update(GymMember gymMember);
        void Delete(int memberId);

    }
}
