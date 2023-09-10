using CNSL_WepService.Models;

namespace CNSL_WepService.Interfaces
{
    public interface IExercise
    {

        void DefineNoSets(object sets);

        void DefineNoReps(object reps);

        void DefineWeight(object weight);

        
    }
}
