namespace OODP.Commands
{
    public class AddCarCommand : Command
    {
        public AddCarCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            _receiver.AddCar();
        }
    }
}
