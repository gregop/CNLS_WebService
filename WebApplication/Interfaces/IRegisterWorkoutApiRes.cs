using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Interfaces
{
    public interface IRegisterWorkoutApiRes
    {
        string Status { get; }

        string Message { get; }
        void StatusOK();

        void StatusNOK();

        void SetMessage(string message);
    }
}
