using Mars_Rover.src.Enum;

namespace Mars_Rover.src.Interfaces
{
    public interface IRotation
    {
        OrientationsEnum Rotate90Degrees(bool isRight, OrientationsEnum oldOrientation);
    }
}
