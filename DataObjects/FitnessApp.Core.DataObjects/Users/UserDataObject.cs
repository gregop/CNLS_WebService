using FitnessApp.Core.Validators;


namespace FitnessApp.Core.DataObjects.Users
{
    public class UserDataObject
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        [StrictlyPositiveProperty("Age")]
        public int Age { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

        public bool IsLockedOut { get; set; }
    }
}
