using Mars_Rover.src.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Interfaces
{
    public interface ICommand
    {
        void Move(double x, double y);

        void RotateToMax90Degrees(double angle);

        void RotateRight90Degrees();

        void RotateLeft90Degrees();
    }
}
