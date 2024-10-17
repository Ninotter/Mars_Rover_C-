using Mars_Rover.src.Enum;
using Mars_Rover.src.Interfaces;

namespace Mars_Rover.src.Entities;

public abstract class Vehicle : IStateSender
{
    public required State VehicleState { get; set; }
    public Planet Planet { get; }
    public OrientationsEnum Orientation { get; set; } = OrientationsEnum.NORD;
    public Vehicle(Planet planet)
    {
        Planet = planet;
    }
    public State SendState()
    {
        return VehicleState;
    }
}