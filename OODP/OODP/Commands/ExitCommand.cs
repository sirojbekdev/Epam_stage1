namespace OODP.Commands
{
    public class ExitCommand : Command
    {
        public ExitCommand(Receiver receiver) : base(receiver) { }


        public override void Execute()
        {
            _receiver.Exit();
        }
    }
}
