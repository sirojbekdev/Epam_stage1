namespace OODP.Commands
{
    public class CountTypesCommand : Command
    {
        public CountTypesCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            _receiver.CountTypes();
        }
    }
}
