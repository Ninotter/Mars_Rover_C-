using Mars_Rover.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Entities
{
    public class State
    {
        public double Horizontal { get; set; }
        
        public double Vertical { get; set; }
        
        public double RotationAngle { get; set; }
        
        public State(double horizontal, double vertical, double rotationAngle)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            RotationAngle = rotationAngle;
        }
    }
}
