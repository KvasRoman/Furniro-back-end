using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.BusinessLogic
{
    public interface IEmailSender
    {
        public bool SendEmail();
    }
}
