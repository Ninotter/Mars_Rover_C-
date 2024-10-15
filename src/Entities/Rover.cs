using Mars_Rover.src.Enum;

namespace Mars_Rover.src.Entities
{
    public class Rover
    {
        #region Properties

        public double Horizontal { get; set; }

        public double Vertical { get; set; }

        public OrientationsEnum Orientation { get; set; } = OrientationsEnum.NORD;

        private double rotationAngle;
        public double RotationAngle {
            get { return rotationAngle; }
            set
            {
                if (value >= 360)
                {
                    rotationAngle = value - 360;
                }
                else if (value < 0)
                {
                    rotationAngle = 360 + value;
                }
                else
                {
                    rotationAngle = value;
                }
            }
        }

        #endregion
    }
}
