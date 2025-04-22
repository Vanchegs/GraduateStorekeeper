using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Internal.Codebase
{
    public class Order
    {
        public int TimeToComplete { get; private set; }

        public int OrderPrice { get; private set; }
        public OrderProduct[] ProductsList { get; private set; }

        public Order()
        {
            ProductsList = new OrderProduct[Random.Range(1, 5)];

            switch (ProductsList.Length)
            {
                case 1:
                    TimeToComplete = 15;
                    break;
                case 2:
                    TimeToComplete = 20;
                    break;
                case 3:
                    TimeToComplete = 25;
                    break;
                case 4:
                    TimeToComplete = 30;
                    break;
            }
        }

        public void ChangeOrder(List<OrderProduct> changedOrder) => 
            ProductsList = changedOrder.ToArray();

        public void CountingOrderPrice(ProductPrice productPrice)
        {
            foreach (var product in ProductsList) 
                OrderPrice += productPrice.ProductPrices[product.ProductType];
        }
    }
}
