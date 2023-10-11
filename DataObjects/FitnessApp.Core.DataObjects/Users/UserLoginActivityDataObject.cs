using FitnessApp.Core.Validators;


namespace FitnessApp.Core.DataObjects.Users
{
    public class UserLoginActivityDataObject
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [StrictlyPositiveProperty("Id")]
        public int UserId { get; set; }

        public DateTime LoginDateTime { get; set; }
    }
}
