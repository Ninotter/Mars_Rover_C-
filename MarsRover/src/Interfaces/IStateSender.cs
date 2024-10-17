using Mars_Rover.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Interfaces
{
    public interface IStateSender
    {
        State SendState();
    }
}
