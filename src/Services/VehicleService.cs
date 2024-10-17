using Mars_Rover.src.Entities;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Services
{
    public class VehicleService : ICommand
    {
        protected Vehicle VehicleModel { get; set; }

        public VehicleService(Rover rover)
        {
            VehicleModel = rover;
        }

        public void Move(double x, double y)
        {
            VehicleModel.VehicleState.Horizontal = x;
            VehicleModel.VehicleState.Vertical = y;
            VehicleModel.SendState();
        }

        public void AvancerNord()
        {
            if(VehicleModel.Orientation == OrientationsEnum.NORD)
            {
                VehicleModel.VehicleState.Vertical += 1;
            }
            VehicleModel.SendState();
        }

        public void AvancerSud()
        {
            if(VehicleModel.Orientation == OrientationsEnum.SUD)
            {
                VehicleModel.VehicleState.Vertical -= 1;
            }
            VehicleModel.SendState();
        }
        public void AvancerEst ()
        {
            if(VehicleModel.Orientation == OrientationsEnum.EST)
            {
                VehicleModel.VehicleState.Horizontal += 1;
            }
            VehicleModel.SendState();
        }

        public void AvancerOuest()
        {
            if(VehicleModel.Orientation == OrientationsEnum.OUEST)
            {
                VehicleModel.VehicleState.Vertical -= 1;
            }
            VehicleModel.SendState();
        }

        public void ReculerNord()
        {
            if(VehicleModel.Orientation == OrientationsEnum.SUD)
            {
                VehicleModel.VehicleState.Vertical -= 1;
            }
            VehicleModel.SendState();
        }

        public void ReculerSud()
        {
            if(VehicleModel.Orientation == OrientationsEnum.NORD)
            {
                VehicleModel.VehicleState.Vertical += 1;
            }
            VehicleModel.SendState();
        }
        public void ReculerEst ()
        {
            if(VehicleModel.Orientation == OrientationsEnum.OUEST)
            {
                VehicleModel.VehicleState.Horizontal -= 1;
            }
            VehicleModel.SendState();
        }

        public void ReculerOuest()
        {
            if(VehicleModel.Orientation == OrientationsEnum.EST)
            {
                VehicleModel.VehicleState.Vertical += 1;
            }
            VehicleModel.SendState();
        }


        public void RotateRight90Degrees()
        {
            SetOrientationAfterRotation(true);

            VehicleModel.VehicleState.RotationAngle += 90;

            VehicleModel.SendState();
        }

        public void RotateLeft90Degrees()
        {
            SetOrientationAfterRotation(false);
            
            VehicleModel.VehicleState.RotationAngle -= 90;

            VehicleModel.SendState();
        }

        private void SetOrientationAfterRotation(bool isRight)
        {
            switch (VehicleModel.Orientation)
            {
                case OrientationsEnum.NORD:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.EST : OrientationsEnum.OUEST;
                    break;
                case OrientationsEnum.SUD:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.OUEST : OrientationsEnum.EST;
                    break;
                case OrientationsEnum.EST:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.SUD : OrientationsEnum.NORD;
                    break;
                case OrientationsEnum.OUEST:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.NORD : OrientationsEnum.SUD;
                    break;
            }
        }
    }
}