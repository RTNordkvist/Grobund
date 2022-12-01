using Grobund.Data.Models;
using GrobundLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrobundLibrary.DataAccess
{
    public interface IDataConnection
    {
        Member CreateMember(Member memberModel);
    }
}
