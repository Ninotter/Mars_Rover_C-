using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Entities;

public abstract class Vehicle : IStateSender
{
    public State vehicleState { get; set; }
    public OrientationsEnum Orientation { get; set; } = OrientationsEnum.NORD;
    public State SendState()
    {
        return vehicleState;
    }
}