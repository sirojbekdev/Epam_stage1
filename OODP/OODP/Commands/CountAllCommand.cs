namespace OODP.Commands
{
    public class CountAllCommand : Command
    {
        public CountAllCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            _receiver.CountAll();
        }
    }
}
