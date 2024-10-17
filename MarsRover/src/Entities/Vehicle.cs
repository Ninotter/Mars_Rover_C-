using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Entities;

public abstract class Vehicle : IStateSender
{
    public State VehicleState { get; set; }
    public OrientationsEnum Orientation { get; set; }
    public Vehicle(State vehicleState)
    {
        VehicleState = vehicleState;
        SetOrientationByState();
    }
    public void SetOrientationByState()
    {
        if (VehicleState.RotationAngle >= 315 || VehicleState.RotationAngle < 45) Orientation = OrientationsEnum.NORD;
        if (VehicleState.RotationAngle >= 45 && VehicleState.RotationAngle < 135) Orientation = OrientationsEnum.EST;
        if (VehicleState.RotationAngle >= 135 && VehicleState.RotationAngle < 225) Orientation = OrientationsEnum.SUD;
        if (VehicleState.RotationAngle >= 225 && VehicleState.RotationAngle < 315) Orientation = OrientationsEnum.OUEST;
    }
    public State SendState()
    {
        return VehicleState;
    }
}