using static TP1.Entities.Models;

namespace TP1.Services
{
    public class PedidosYaBlueService
    {
        // Factory method
        public string CreateNewOrder(string type)
        {
            if (type == "blue")
            {
                OrderFactory factory = new DroneOrderFactory();
                Order order = factory.CreateOrder();

                return $"Pedido de id {order.Id} realizado con exito. Dron en camino hacia {order.Address}";
            }
            else
            {
                OrderFactory factory = new DefaultOrderFactory();

                Order order = factory.CreateOrder();

                return $"Pedido de id {order.Id} realizado con exito. Delivery en camino hacia {order.Address}";
            }
        }

        // Observer
        public string GetLocation()
        {
            Subject subject = new Subject();
            Client client = new Client();
            Drone drone = new Drone();

            subject.Attach(client);
            subject.Attach(drone);

            subject.State = "El pedido está en camino";

            subject.Detach(client);

            subject.State = "El pedido ha sido entregado";

            return subject.State;
        }

    }

    // Patron Observer
    public class Subject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string state = string.Empty;

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyObservers();
            }
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    public class Client : IObserver
    {
        public void Update()
        {
            // message
        }
    }

    public class Drone : IObserver
    {
        public void Update()
        {
            // message
        }
    }
}
