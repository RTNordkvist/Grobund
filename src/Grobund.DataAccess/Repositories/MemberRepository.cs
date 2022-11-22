using Grobund.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grobund.DataAccess.Repositories
{
    public class MemberRepository
    {
        private readonly string connectionString;

        public MemberRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int AddMember(Member member)
        {
            // TO DO: Insert code block to save new member in database

            return member.Id;
        }
    }
}
