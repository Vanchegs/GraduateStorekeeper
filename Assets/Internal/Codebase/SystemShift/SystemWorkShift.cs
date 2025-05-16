using Internal.Codebase.Infrastructure;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

namespace Internal.Codebase
{
    public class SystemWorkShift : MonoBehaviour
    {
        [SerializeField] private ShiftPanelMover panelMover;
        [SerializeField] private SafeBalanceUI safeBalance;
        [SerializeField] private PlayerComponent player;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Transform playerSpawnPoint;
        
        public ShiftTimer ShiftTimer { get; private set; }
    
        private void OnEnable()
        {
            GameEventBus.EndOfShift += SwitchJoystick;
            GameEventBus.EndOfShift += panelMover.MovePanel;
            GameEventBus.EndOfShift += player.Mover.StaminaSystem.ResetStamina;
            GameEventBus.EndOfShift += safeBalance.UpdateSafeBalance;
        }
    
        private void OnDisable()
        {
            GameEventBus.EndOfShift -= SwitchJoystick;
            GameEventBus.EndOfShift -= panelMover.MovePanel;
            GameEventBus.EndOfShift -= player.Mover.StaminaSystem.ResetStamina;
            GameEventBus.EndOfShift -= safeBalance.UpdateSafeBalance;
        }
    
        private void Start()
        {
            ShiftTimer = new ShiftTimer();
            
            StartCoroutine(ShiftTimer.Timer(GameEventBus.EndOfShift));
        }
    
        public void StartShift()
        {
            SwitchJoystick();
            StartCoroutine(ShiftTimer.Timer(GameEventBus.EndOfShift));
            ResetPlayerPosition();
        }

        private void ResetPlayerPosition() => 
            player.gameObject.transform.position = playerSpawnPoint.position;

        private void SwitchJoystick()
        {
            switch (joystick.enabled)
            {
                case true:
                    joystick.OnPointerUp(null);
                    player.Mover.Joystick.enabled = false;
                    break;
                case false:
                    player.Mover.Joystick.enabled = true;
                    break;
            }
        }
    }
}

