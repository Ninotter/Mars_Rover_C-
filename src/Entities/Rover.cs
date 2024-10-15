using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Entities
{
    public class Rover
    {
        #region Properties

        public double Horizontal {  get; set; }

        public double Vertical { get; set; }

        public OrientationsEnum Orientation { get; set; } = OrientationsEnum.NORD;

        public double RotationAngle { get; set; }

        #endregion
    }
}
