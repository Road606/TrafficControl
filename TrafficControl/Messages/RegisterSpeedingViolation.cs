using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControl.Messages
{
    class RegisterSpeedingViolation
    {
        public RegisterSpeedingViolation(string registration, string color, string brand, int speed)
        {
            Registration = registration;
            Color = color;
            Brand = brand;
            Speed = speed;
        }

        public string Registration { get; }
        public int Speed { get; }
        public string Brand { get; }
        public string Color { get; }
    }
}
