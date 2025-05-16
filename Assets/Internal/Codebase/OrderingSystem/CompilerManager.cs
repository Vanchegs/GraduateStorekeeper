using System.Collections.Generic;
using Internal.Codebase;
using UnityEngine;

public class CompilerManager : MonoBehaviour
{
    [SerializeField] private List<OrdersCompiler> ordersCompilers;

    public void ResetOrders()
    {
        foreach (var ordComp in ordersCompilers) 
            ordComp.ResetOrder();
    }
}
