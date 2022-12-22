namespace BattleShipV3.Client.DesignPatterns.Memento
{
    public interface IMemento
    {
        DateTime GetDate();
        int GetLength();
        string GetName();
        string GetState();
        int GetXCoord();
        int GetYCoord();
    }

    //public interface IMemento
    //{
    //    string GetName();

    //    string GetState();

    //    DateTime GetDate();
    //}

    public class ConcreteMemento : IMemento
    {
        private string _state;
        private int _length;
        private int _x;
        private int _y;

        private DateTime _date;

        public ConcreteMemento(string state, int length, int x, int y)
        {
            this._state = state;
            this._length = length;
            this._x = x;
            this._y = y;
            this._date = DateTime.Now;
        }

        // The Originator uses this method when restoring its state.
        public string GetState()
        {
            return this._state;
        }

        public int GetLength()
        {
            return this._length;
        }

        public int GetXCoord()
        {
            return this._x;
        }

        public int GetYCoord()
        {
            return this._y;
        }

        // The rest of the methods are used by the Caretaker to display
        // metadata.
        public string GetName()
        {
            return $"{this._date} / ({this._state.Substring(0, 9)})... / {this._length} / {this._x} / {this._y}";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }
}
