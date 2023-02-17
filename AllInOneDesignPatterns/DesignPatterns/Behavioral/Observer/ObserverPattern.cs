namespace Observer
{
    public interface IObserver
    {
        void ChangeColor(Color color);
    }

    public interface ISubscription
    {
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);

        void Notify();

    }
    public class ObservableColorSubscription : ISubscription
    {
        private Color color;

        private List<IObserver> observers = new List<IObserver>();

        public Color Color
        {
            get => color; set
            {
                color = value;
                Notify();
            }
        }

        public void Notify()
        {
            observers.ForEach(o => o.ChangeColor(color));
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnSubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
