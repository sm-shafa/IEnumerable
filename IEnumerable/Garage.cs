using System.Collections;

namespace IEnumerable
{
    // Garage contains a set of Car objects.
    class Garage : System.Collections.IEnumerable
    {
        private Car[] carArray = new Car[4];
        private Truck[] truckArray = new Truck[4];
        // Fill with some Car objects upon startup.
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);

            truckArray[0] = new Truck("Rusty", 30);
            truckArray[1] = new Truck("Clunker", 55);
            truckArray[2] = new Truck("Zippy", 30);
            truckArray[3] = new Truck("Fred", 30);
        }

        public IEnumerator GetEnumerator()
        {
            // Return the array object's IEnumerator.
            return carArray.GetEnumerator();
        }


    }
}
