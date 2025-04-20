using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

public class SystemWorkShift : MonoBehaviour
{
    [SerializeField] private ShiftPanelMover panelMover;
    
    public ShiftTimer ShiftTimer { get; private set; }

    private void Start()
    {
        ShiftTimer = new ShiftTimer();

        StartCoroutine(ShiftTimer.Timer(panelMover.MovePanel));
    }
}
