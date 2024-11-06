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
    public void MakeRoverGoForwardFromDefaultNorthPosition_OnInfinitPlanet()
    {
        Interpreter.CreateRover(new InfinitePlanet());
        Interpreter.Send(Interpreter.FORWARD);
        Assert.That(Interpreter.GetRoverState().Vertical, Is.EqualTo(1));
    }
    
    [Test]
    public void MakeRoverGoBackwardFromDefaultNorthPosition_OnTorroidalPlanet()
    {   
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.BACKWARD);
        Assert.That(Interpreter.GetRoverState().Vertical, Is.EqualTo(10));
    }

    [Test]
    public void MakeRoverTurnRightToFaceEast_OnInfinitPlanet()
    {
        Interpreter.CreateRover(new InfinitePlanet());
        Interpreter.Send(Interpreter.RIGHT);
        Assert.That(Interpreter.GetRoverState().Orientation, Is.EqualTo(State.EAST));
    }
    
    [Test]
    public void MakeRoverGoForwardFromEastPosition_OnInfinitPlanet()
    {
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.RIGHT);
        Interpreter.Send(Interpreter.FORWARD);
        Assert.That(Interpreter.GetRoverState().Horizontal, Is.EqualTo(1));
    }
    
    [Test]
    public void MakeRoverGoBackwardFromEastPosition_OnTorroidalPlanet()
    {   
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.RIGHT);
        Interpreter.Send(Interpreter.BACKWARD);
        Assert.That(Interpreter.GetRoverState().Horizontal, Is.EqualTo(10));
    }
    
    [Test]
    public void MakeRoverTurnRightTwiceToFaceSouth_OnInfinitPlanet()
    {
        Interpreter.CreateRover(new InfinitePlanet());
        Interpreter.Send(Interpreter.RIGHT);
        Interpreter.Send(Interpreter.RIGHT);
        Assert.That(Interpreter.GetRoverState().Orientation, Is.EqualTo(State.SOUTH));
    }
    
    [Test]
    public void MakeRoverGoForwardFromSouthPosition_OnInfinitPlanet()
    {
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.RIGHT);
        Interpreter.Send(Interpreter.RIGHT);
        Interpreter.Send(Interpreter.FORWARD);
        Assert.That(Interpreter.GetRoverState().Vertical, Is.EqualTo(10));
    }
    
    [Test]
    public void MakeRoverGoBackwardFromSouthPosition_OnTorroidalPlanet()
    {   
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.RIGHT);
        Interpreter.Send(Interpreter.RIGHT);
        Interpreter.Send(Interpreter.BACKWARD);
        Assert.That(Interpreter.GetRoverState().Vertical, Is.EqualTo(1));
    }
    
    [Test]
    public void MakeRoverTurnLeftToFaceWest_OnInfinitPlanet()
    {
        Interpreter.CreateRover(new InfinitePlanet());
        Interpreter.Send(Interpreter.LEFT);
        Assert.That(Interpreter.GetRoverState().Orientation, Is.EqualTo(State.WEST));
    }
    
    [Test]
    public void MakeRoverGoForwardFromWestPosition_OnInfinitPlanet()
    {
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.LEFT);
        Interpreter.Send(Interpreter.FORWARD);
        Assert.That(Interpreter.GetRoverState().Horizontal, Is.EqualTo(10));
    }
    
    [Test]
    public void MakeRoverGoBackwardFromWestPosition_OnTorroidalPlanet()
    {   
        Interpreter.CreateRover(new TorroidalPlanet(10, 10));
        Interpreter.Send(Interpreter.LEFT);
        Interpreter.Send(Interpreter.BACKWARD);
        Assert.That(Interpreter.GetRoverState().Horizontal, Is.EqualTo(1));
    }
}
