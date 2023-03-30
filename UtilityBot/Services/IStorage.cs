using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityBot.Models;

namespace UtilityBot.Services
{
    public interface IStorage
    {
        Session GetSession(long chatId);
    }
}
