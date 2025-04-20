using UnityEngine;

public class SystemWorkShift : MonoBehaviour
{
    public ShiftTimer ShiftTimer { get; private set; }

    private void Start()
    {
        ShiftTimer = new ShiftTimer();

        StartCoroutine(ShiftTimer.Timer());
    }
}
