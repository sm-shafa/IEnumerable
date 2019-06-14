namespace IEnumerable
{
    public class Car
    {
        private string _PetName;
        private int _CurrentSpeed;

        public Car(string PetName, int CurrentSpeed)
        {
            _PetName = PetName;
            _CurrentSpeed = CurrentSpeed;
        }

        public string PetName
        {
            get => _PetName; set => _PetName = value;
        }

        public int CurrentSpeed
        {
            get => _CurrentSpeed; set => _CurrentSpeed = value;
        }
    }
}
