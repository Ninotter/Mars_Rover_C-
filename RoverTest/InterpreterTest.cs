using Mars_Rover.Entities;
using Mars_Rover.Tools;

namespace RoverTest;

public class InterpreterTest
{
    [Test]
    public void CreateANewRoverTest()
    {
        Rover rover = Interpreter.CreateRover(new InfinitePlanet());
        Assert.IsTrue(rover != null);
    }

    [Test]
    public void MakeRoverGoForwardFromDefaultNorthPosition()
    {
        Interpreter.CreateRover(new InfinitePlanet());
        Interpreter.Send(Interpreter.FORWARD);
        Assert.That(Interpreter.GetRoverState().Vertical, Is.EqualTo(1));
    }
    
    [Test]
    public void MakeRoverGoBackwardFromDefaultNorthPosition()
    {   
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.BACKWARD);
        Assert.That(Interpreter.GetRoverState().Vertical, Is.EqualTo(10));
    }
}