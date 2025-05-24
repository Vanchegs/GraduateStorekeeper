using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase
{
    public class CompilerManager : MonoBehaviour
    {
        [SerializeField] private List<OrdersCompiler> ordersCompilers;
    
        public void ResetOrders()
        {
            foreach (var ordComp in ordersCompilers) 
                ordComp.ResetOrder();
        }
    }
}

