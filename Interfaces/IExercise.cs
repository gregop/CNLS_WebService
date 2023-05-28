using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Interfaces
{
    public interface IExercise
    {
        int DefineNoSets(int sets);
        
        int DefineNoReps(int reps);

        float DefineWeight(float weight);
    }
}
