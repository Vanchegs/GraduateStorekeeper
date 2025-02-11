using System.Collections;
using UnityEngine;

namespace Internal.Codebase
{
    public class OrdersCompiler : MonoBehaviour
    {
        private Order order;
        private Product[] products;
        private int waitingTime;

        private void Start()
        {
            waitingTime = Random.Range(5, 30);
            
            StartCoroutine(TimeOrderingWaiting());
        }

        private void OrderCreate()
        {
            order = new Order();

            for (int i = 0; i < order.ProductsList.Length; i++)
            {
                order.ProductsList[i] = new Product();
                
                Debug.Log(order.ProductsList[i].ProductType);
            }
            
            Debug.Log(order.ProductsList.Length);
        }

        private IEnumerator TimeOrderingWaiting()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitingTime);
                
                OrderCreate();
                
                waitingTime = Random.Range(10, 30);
            }
        }
    }
}