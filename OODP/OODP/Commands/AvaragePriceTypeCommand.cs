namespace OODP.Commands
{
    public class AvaragePriceTypeCommand : Command
    {
        public AvaragePriceTypeCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            _receiver.AvaragePriceForType();
        }
    }
}
