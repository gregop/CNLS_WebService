using CNSL_WepService.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Interfaces
{
    public partial interface IApiResponse
    {
        void StatusOK();

        void StatusNOK();

        void SetMessage(string message);

        void SetWorkoutItem(WorkoutItemModel workoutItem);
    }
}