using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase
{
    public class OrdersCompiler : MonoBehaviour
    {
        [SerializeField] private IssueTableProductDisplay tableProductDisplay;
        
        private int waitingTime;
        private bool isOrderCompleted;
        
        public Order Order { get; private set; }

        private void Start()
        {
            isOrderCompleted = true;
            
            waitingTime = Random.Range(5, 10);
            
            StartCoroutine(TimeOrderingWaiting());
        }

        private void OrderCreate()
        {
            Order = new Order();
            
            for (int i = 0; i < Order.ProductsList.Length; i++) 
                Order.ProductsList[i] = new OrderProduct();

            RecountingWaitingTime();
            
            Order.CountingOrderPrice();

            isOrderCompleted = false;
         
            tableProductDisplay.DisplayOrder();
        }

        public void OrderComplete() => 
            isOrderCompleted = true;

        public void RecountingWaitingTime() => 
            waitingTime = Random.Range(5, 20);

        private IEnumerator TimeOrderingWaiting()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitingTime);

                if (isOrderCompleted)
                {
                    OrderCreate();
                    
                    waitingTime = Random.Range(10, 20);
                }
            }
        }
    }
}