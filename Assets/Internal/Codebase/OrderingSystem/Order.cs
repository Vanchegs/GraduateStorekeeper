using Random = UnityEngine.Random;

namespace Internal.Codebase
{
    public class Order
    {
        public int timeToComplete;
     
        public OrderProduct[] ProductsList { get; private set; }

        public Order()
        {
            ProductsList = new OrderProduct[Random.Range(1, 5)];

            switch (ProductsList.Length)
            {
                case 1:
                    timeToComplete = 15;
                    break;
                case 2:
                    timeToComplete = 20;
                    break;
                case 3:
                    timeToComplete = 25;
                    break;
                case 4:
                    timeToComplete = 30;
                    break;
            }
        }
    }
}
