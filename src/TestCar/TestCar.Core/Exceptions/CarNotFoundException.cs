using System;

namespace TestCar.Core.Exceptions
{
    public class CarNotFoundException : Exception
    {
        private const string DefaultMessage = "There is no such car";
        private const string MessageWithCarName = "There is no car with name - {0}";
        private const string MessageWithCarId = "There is no car with id - {0}";

        public CarNotFoundException() : base(DefaultMessage)
        {
        }
        
        public CarNotFoundException(string carName) : base(string.Format(MessageWithCarName, carName))
        {
        }
        
        public CarNotFoundException(int carId) : base(string.Format(MessageWithCarId, carId))
        {
        }
    }
}