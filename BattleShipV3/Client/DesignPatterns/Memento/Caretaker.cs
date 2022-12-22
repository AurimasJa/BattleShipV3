namespace BattleShipV3.Client.DesignPatterns.Memento
{
    public class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();
        private int _mementosAmount = 0;
        private MementoOriginator _originator = null;

        public Caretaker(MementoOriginator originator)
        {
            this._originator = originator;
        }

        public void Backup(int length, int x, int y)
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this._mementos.Add(this._originator.Save(length, x, y));
        }

        public List<int> Undo()
        {
            List<int> coords = new List<int>();
            if (this._mementos.Count == 0)
            {
                return coords;
            }

            var memento = this._mementos.Last();
            coords.Add(memento.GetLength());
            coords.Add(memento.GetXCoord());
            coords.Add(memento.GetYCoord());
            this._mementos.Remove(memento);

            Console.WriteLine("Caretaker: Restoring state to: " + memento.GetName());

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
            return coords;
        }

        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetName());
            }
            Console.WriteLine("Caretaker: ----------------------------");
        }
        public int GetAmount()
        {
            Console.WriteLine("Caretaker: Amount of mementos:");

            _mementosAmount = this._mementos.Count;

            return _mementosAmount;
        }

        //static void Main(string[] args)
        //{
        //    // Client code.
        //    Originator originator = new Originator("Super-duper-super-puper-super.");
        //    Caretaker caretaker = new Caretaker(originator);

        //    caretaker.Backup();
        //    originator.DoSomething();

        //    caretaker.Backup();
        //    originator.DoSomething();

        //    caretaker.Backup();
        //    originator.DoSomething();

        //    Console.WriteLine();
        //    caretaker.ShowHistory();

        //    Console.WriteLine("\nClient: Now, let's rollback!\n");
        //    caretaker.Undo();

        //    Console.WriteLine("\n\nClient: Once more!\n");
        //    caretaker.Undo();

        //    Console.WriteLine();
        //}
    }
}
