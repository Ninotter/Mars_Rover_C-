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

        void RotateRight90Degrees();

        void RotateLeft90Degrees();
    }
}
