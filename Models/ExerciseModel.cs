using System.ComponentModel.DataAnnotations;
using CNSL_WepService.Interfaces;

namespace CNSL_WepService.Models
{
    public class ExerciseModel : IExercise
    {

        private int Reps;

        private int Sets;

        private float Weight;


        public int DefineNoReps(int reps)
        {   

            throw new NotImplementedException();
        }

        public int DefineNoSets(int sets)
        {
            throw new NotImplementedException();
        }

        public float DefineWeight(float weight)
        {
            throw new NotImplementedException();
        }
    }
}
