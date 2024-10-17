using Mars_Rover.src.Entities;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Services
{
    public class VehicleService : ICommand
    {
        private const double MIN_PLANET_SIZE = 0;
        protected Vehicle VehicleModel { get; set; } 
        protected Planet PlanetModel { get; set; }
        public VehicleService(Rover rover, Planet planet)
        {
            VehicleModel = rover;
            PlanetModel = planet;
        }

        private void CheckLimits()
        {
            
            if (VehicleModel.VehicleState.Horizontal < MIN_PLANET_SIZE)
            {
                VehicleModel.VehicleState.Horizontal = MIN_PLANET_SIZE - VehicleModel.VehicleState.Horizontal - 1;
            }
            if (VehicleModel.VehicleState.Vertical < MIN_PLANET_SIZE)
            {
                VehicleModel.VehicleState.Vertical = MIN_PLANET_SIZE - VehicleModel.VehicleState.Vertical -1;
            }
            if (VehicleModel.VehicleState.Horizontal > PlanetModel.Size)
            {
                VehicleModel.VehicleState.Horizontal = (VehicleModel.VehicleState.Horizontal - PlanetModel.Size -1);
            }
            if (VehicleModel.VehicleState.Vertical > PlanetModel.Size)
            {
                VehicleModel.VehicleState.Vertical = (VehicleModel.VehicleState.Vertical - PlanetModel.Size -1);
            }
        }

        public void AvancerNord()
        {
            if(VehicleModel.Orientation == OrientationsEnum.NORD)
            {
                VehicleModel.VehicleState.Vertical += 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void AvancerSud()
        {
            if(VehicleModel.Orientation == OrientationsEnum.SUD)
            {
                VehicleModel.VehicleState.Vertical -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }
        public void AvancerEst ()
        {
            if(VehicleModel.Orientation == OrientationsEnum.EST)
            {
                VehicleModel.VehicleState.Horizontal += 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void AvancerOuest()
        {
            if(VehicleModel.Orientation == OrientationsEnum.OUEST)
            {
                VehicleModel.VehicleState.Horizontal -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void ReculerNord()
        {
            if(VehicleModel.Orientation == OrientationsEnum.SUD)
            {
                VehicleModel.VehicleState.Vertical -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void ReculerSud()
        {
            if(VehicleModel.Orientation == OrientationsEnum.NORD)
            {
                VehicleModel.VehicleState.Vertical += 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }
        public void ReculerEst ()
        {
            if(VehicleModel.Orientation == OrientationsEnum.OUEST)
            {
                VehicleModel.VehicleState.Horizontal -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void ReculerOuest()
        {
            if(VehicleModel.Orientation == OrientationsEnum.EST)
            {
                VehicleModel.VehicleState.Vertical += 1;
                CheckLimits();
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
                    VehicleModel.Orientation = isRight ? OrientationsEnum.NORD : OrientationsEnum.SUD;
                    break;
                case OrientationsEnum.OUEST:
                    VehicleModel.Orientation = isRight ? OrientationsEnum.SUD : OrientationsEnum.NORD;
                    break;
            }
        }
    }
}