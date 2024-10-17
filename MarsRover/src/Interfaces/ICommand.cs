namespace Mars_Rover.src.Interfaces
{
    public interface ICommand
    {
        void RotateRight90Degrees();

        void RotateLeft90Degrees();

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
