using System.Collections;
using Internal.Codebase.Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase
{
    public class OrdersCompiler : MonoBehaviour
    {
        [SerializeField] private IssueTableProductDisplay tableProductDisplay;
        [SerializeField] private ProductPrice productPrice;
        
        private int waitingTime;

        public bool IsCompleted { get; private set; }
        public Order Order { get; private set; }

        private void OnEnable() => 
            GameEventBus.EndOfShift += ResetOrder;

        private void OnDisable() => 
            GameEventBus.EndOfShift -= ResetOrder;

        private void Start()
        {
            IsCompleted = true;
            
            waitingTime = Random.Range(5, 10);
            
            StartCoroutine(CreateOrderWithDelay());
        }

        public void OrderComplete() => 
            IsCompleted = true;

        public void RecountingWaitingTime() => 
            waitingTime = Random.Range(5, 20);

        public void ResetOrder()
        {
            OrderComplete();
            Order = new Order();
            tableProductDisplay.DisplayOrder();
        }

        private void OrderCreate()
        {
            Order = new Order();
            
            for (int i = 0; i < Order.ProductsList.Length; i++) 
                Order.ProductsList[i] = new OrderProduct();
            
            RecountingWaitingTime();
            
            IsCompleted = false;
            Order.CountingOrderPrice(productPrice);
            
            tableProductDisplay.DisplayOrder();
        }

        private IEnumerator CreateOrderWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitingTime);

                if (IsCompleted)
                {
                    OrderCreate();
                    
                    waitingTime = Random.Range(10, 20);
                }
            }
        }
    }
}