using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.src.Interfaces
{
    public interface IMouvement
    {
        public void AvancerNord();

        public void AvancerSud();

        public void AvancerEst();

        public void AvancerOuest();

        public void ReculerNord();

        public void ReculerSud();

        public void ReculerEst();

        public void ReculerOuest();
    }
}
