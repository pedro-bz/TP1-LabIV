namespace TP1.Entities
{
    public class Models
    {
        // Factory method
        public abstract class Order
        {
            public int Id { get; set; }
            public string Address { get; set; } = string.Empty;
            public float Price { get; set; }
        }

        public class DroneOrder : Order
        {
            public int DroneId { get; set; }
            public string DroneName { get; set; } = string.Empty;
            public string DroneDescription { get; set; } = string.Empty;
            public string DroneType { get; set; } = string.Empty;
        }

        public class DefaultOrder : Order
        {
            public int DeliveryId { get; set; }
            public string DeliveryName { get; set; } = string.Empty;
            public string Vehicle { get; set; } = string.Empty;
        }

        public abstract class OrderFactory
        {
            public abstract Order CreateOrder();
        }

        public class DroneOrderFactory : OrderFactory
        {
            public override Order CreateOrder()
            {
                return new DroneOrder();
            }
        }

        public class DefaultOrderFactory : OrderFactory
        {
            public override Order CreateOrder()
            {
                return new DefaultOrder();
            }
        }

        // Observer
        public interface IObserver
        {
            void Update();
        }

    }
}
