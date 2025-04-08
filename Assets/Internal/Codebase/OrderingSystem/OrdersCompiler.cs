using System.Collections;
using Internal.Codebase.Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase
{
    public class OrdersCompiler : MonoBehaviour
    {
        [SerializeField] private IssueTableProductDisplay tableProductDisplay;
        
        private int waitingTime;
        private bool orderCompleted;
        
        public Order Order { get; private set; }

        private void Start()
        {
            orderCompleted = true;
            
            waitingTime = Random.Range(10, 30);
            
            StartCoroutine(TimeOrderingWaiting());
        }

        private void OrderCreate()
        {
            Order = new Order();

            for (int i = 0; i < Order.ProductsList.Length; i++) 
                Order.ProductsList[i] = new OrderProduct();

            orderCompleted = false;
         
            tableProductDisplay.DisplayOrder();
        }
        
        private IEnumerator TimeOrderingWaiting()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitingTime);

                if (orderCompleted)
                {
                    OrderCreate();
                    
                    waitingTime = Random.Range(10, 30);
                }
            }
        }
    }
}