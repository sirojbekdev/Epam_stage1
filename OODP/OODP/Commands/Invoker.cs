namespace OODP.Commands
{
    public class Invoker
    {
        private readonly Command _addCar;
        private readonly Command _avaragePrice;
        private readonly Command _avaragePriceType;
        private readonly Command _countAll;
        private readonly Command _countTypes;
        private readonly Command _exit;

        public Invoker(Command addCar, Command avaragePrice, Command avaragePriceType, Command countAll, Command countTypes, Command exit)
        {
            _addCar = addCar;
            _avaragePrice = avaragePrice;
            _avaragePriceType = avaragePriceType;
            _countAll = countAll;
            _countTypes = countTypes;
            _exit = exit;
        }

        public void AddCar()
        {
            _addCar.Execute();
        }
        public void AvaragePrice()
        {
            _avaragePrice.Execute();
        }
        public void AvaragePriceType()
        {
            _avaragePriceType.Execute();
        }
        public void CountAll()
        {
            _countAll.Execute();
        }
        public void CountTypes()
        {
            _countTypes.Execute();
        }
        public void Exit()
        {
            _exit.Execute();
        }
    }
}
