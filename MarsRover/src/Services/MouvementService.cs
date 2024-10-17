using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Services
{
    public class MouvementService : IMouvement
    {
        private void CheckLimits()
        {

            if (VehicleModel.VehicleState.Horizontal < MIN_PLANET_SIZE)
            {
                VehicleModel.VehicleState.Horizontal = MIN_PLANET_SIZE - VehicleModel.VehicleState.Horizontal - 1;
            }
            if (VehicleModel.VehicleState.Vertical < MIN_PLANET_SIZE)
            {
                VehicleModel.VehicleState.Vertical = MIN_PLANET_SIZE - VehicleModel.VehicleState.Vertical - 1;
            }
            if (VehicleModel.VehicleState.Horizontal > PlanetModel.Size)
            {
                VehicleModel.VehicleState.Horizontal = (VehicleModel.VehicleState.Horizontal - PlanetModel.Size - 1);
            }
            if (VehicleModel.VehicleState.Vertical > PlanetModel.Size)
            {
                VehicleModel.VehicleState.Vertical = (VehicleModel.VehicleState.Vertical - PlanetModel.Size - 1);
            }
        }

        public void AvancerNord()
        {
            if (VehicleModel.Orientation == OrientationsEnum.NORD)
            {
                VehicleModel.VehicleState.Vertical += 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void AvancerSud()
        {
            if (VehicleModel.Orientation == OrientationsEnum.SUD)
            {
                VehicleModel.VehicleState.Vertical -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }
        public void AvancerEst()
        {
            if (VehicleModel.Orientation == OrientationsEnum.EST)
            {
                VehicleModel.VehicleState.Horizontal += 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void AvancerOuest()
        {
            if (VehicleModel.Orientation == OrientationsEnum.OUEST)
            {
                VehicleModel.VehicleState.Horizontal -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void ReculerNord()
        {
            if (VehicleModel.Orientation == OrientationsEnum.SUD)
            {
                VehicleModel.VehicleState.Vertical -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void ReculerSud()
        {
            if (VehicleModel.Orientation == OrientationsEnum.NORD)
            {
                VehicleModel.VehicleState.Vertical += 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }
        public void ReculerEst()
        {
            if (VehicleModel.Orientation == OrientationsEnum.OUEST)
            {
                VehicleModel.VehicleState.Horizontal -= 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }

        public void ReculerOuest()
        {
            if (VehicleModel.Orientation == OrientationsEnum.EST)
            {
                VehicleModel.VehicleState.Vertical += 1;
                CheckLimits();
            }
            VehicleModel.SendState();
        }
    }
}
