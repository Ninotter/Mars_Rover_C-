using Mars_Rover.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Entities
{
    public class State
    {
        public IStateSender StateModel { get; set; }

        public State(IStateSender sender)
        {
            StateModel = sender;
        }
    }
}
