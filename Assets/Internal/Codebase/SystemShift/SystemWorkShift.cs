using System;
using Internal.Codebase;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

public class SystemWorkShift : MonoBehaviour
{
    [SerializeField] private ShiftPanelMover panelMover;
    [SerializeField] private PlayerComponent player;
    
    private Action EndOfShift;
    
    public ShiftTimer ShiftTimer { get; private set; }

    private void OnEnable()
    {
        EndOfShift += panelMover.MovePanel;
        EndOfShift += player.Mover.StaminaSystem.ResetStamina;
    }

    private void OnDisable()
    {
        EndOfShift -= panelMover.MovePanel;
        EndOfShift -= player.Mover.StaminaSystem.ResetStamina;
    }

    private void Start()
    {
        ShiftTimer = new ShiftTimer();
        
        StartCoroutine(ShiftTimer.Timer(EndOfShift));
    }

    public void StartShift() => 
        StartCoroutine(ShiftTimer.Timer(EndOfShift));
}
