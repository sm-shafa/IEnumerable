namespace IEnumerable
{
    public class Truck
    {
        private string _PetName;
        private int _CurrentSpeed;

        public Truck(string PetName, int CurrentSpeed)
        {
            _PetName = PetName;
            _CurrentSpeed = CurrentSpeed;
        }

        public string PetName { get => _PetName; set => _PetName = value; }
        public int CurrentSpeed { get => _CurrentSpeed; set => _CurrentSpeed = value; }
    }
}

