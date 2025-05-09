using System;
using System.Collections;
using Internal.Codebase.Infrastructure;
using UnityEngine;

public class ShiftTimer
{
    public static int ShiftDuration { get; } = 180;
    public bool IsShiftEnd { get; private set; }

    public IEnumerator Timer(Action callback)
    {
        yield return new WaitForSeconds(ShiftDuration);

        IsShiftEnd = true;

        callback.Invoke();
        GameEventBus.SaveGame?.Invoke();
    }
}
