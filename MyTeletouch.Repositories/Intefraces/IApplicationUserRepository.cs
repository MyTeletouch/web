using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeletouch.Repositories.Intefraces
{
    public interface IApplicationUserRepository
    {
        /// <summary>
        /// Application to try find information for e-mail address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>true if email address exists in database</returns>
        bool EmailIsUnique(string emailAddress);
    }
}
