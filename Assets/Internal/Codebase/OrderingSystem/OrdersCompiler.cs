using UnityEngine;

namespace Internal.Codebase
{
    public class OrdersCompiler : MonoBehaviour
    {
        private Order order;
        private ProductsType[] products;

        private void Start()
        {
            OrderCreate();
            
            Debug.Log(order.ProductsList.Length);
        }

        private void OrderCreate()
        {
            order = new Order();

            Product product = new Product();

            Debug.Log(product.ProductType);
        }
    }
}