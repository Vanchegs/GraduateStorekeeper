using System.Collections;
using Internal.Codebase.Infrastructure;
using UnityEngine;

public class ShiftTimer
{
    public int ShiftDuration { get; } = 180;
    public bool IsShiftEnd { get; private set; }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(ShiftDuration);

        IsShiftEnd = true;
        
        GameEventBus.EndOfShift.Invoke();
    }
}
