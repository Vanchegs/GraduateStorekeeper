using UnityEngine;

namespace Internal.Codebase
{
    public class OrdersCompiler : MonoBehaviour
    {
        private Order order;
        private Product[] products;

        private void Start()
        {
            OrderCreate();
            
            Debug.Log(order.ProductsList.Length);
        }

        private void OrderCreate()
        {
            order = new Order();

            for (int i = 0; i < order.ProductsList.Length; i++)
            {
                order.ProductsList[i] = new Product();
                
                Debug.Log(order.ProductsList[i].ProductType);
            }
        }
    }
}