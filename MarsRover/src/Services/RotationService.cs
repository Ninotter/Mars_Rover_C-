using Mars_Rover.src.Entities;
using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Services
{
    public class RotationService : IRotation
    {
        public static OrientationsEnum Rotate90Degrees(bool isRight, OrientationsEnum oldOrientation)
        {
            return SetOrientationAfterRotation(isRight, oldOrientation);
        }

        private static OrientationsEnum SetOrientationAfterRotation(bool isRight, OrientationsEnum orientations)
        {
            switch (orientations)
            {
                case OrientationsEnum.NORD:
                    return isRight ? OrientationsEnum.EST : OrientationsEnum.OUEST;
                case OrientationsEnum.SUD:
                    return isRight ? OrientationsEnum.OUEST : OrientationsEnum.EST;
                case OrientationsEnum.EST:
                    return isRight ? OrientationsEnum.SUD : OrientationsEnum.NORD;
                case OrientationsEnum.OUEST:
                    return isRight ? OrientationsEnum.NORD : OrientationsEnum.SUD;
                default:
                    throw new Exception("Orientations not found");
            }
        }
    }
}
