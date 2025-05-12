using System.Collections.Generic;
using Internal.Codebase;
using UnityEngine;

public class CompilerManager : MonoBehaviour
{
    [SerializeField] private List<OrdersCompiler> ordersCompilers;

    public void NewShiftOrdering()
    {
        foreach (var ordComp in ordersCompilers) 
            ordComp.StartOrderCreating();
    }
}
