namespace OODP.Commands
{
    public class AvaragePriceCommand : Command
    {
        public AvaragePriceCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            _receiver.AvaragePrice();
        }
    }
}
