using Internal.Codebase.Infrastructure;
using Internal.Codebase.UILogic.StoreLogic;
using UnityEngine;

namespace Internal.Codebase
{
    public class SystemWorkShift : MonoBehaviour
    {
        [SerializeField] private ShiftPanelMover panelMover;
        [SerializeField] private PlayerComponent player;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Transform playerSpawnPoint;
        
        public ShiftTimer ShiftTimer { get; private set; }
    
        private void OnEnable()
        {
            GameEventBus.EndOfShift += SwitchJoystick;
            GameEventBus.EndOfShift += panelMover.MovePanel;
            GameEventBus.EndOfShift += player.Mover.StaminaSystem.ResetStamina;
        }
    
        private void OnDisable()
        {
            GameEventBus.EndOfShift -= SwitchJoystick;
            GameEventBus.EndOfShift -= panelMover.MovePanel;
            GameEventBus.EndOfShift -= player.Mover.StaminaSystem.ResetStamina;
        }
    
        private void Start()
        {
            ShiftTimer = new ShiftTimer();
            
            StartCoroutine(ShiftTimer.Timer(GameEventBus.EndOfShift));
        }
    
        public void StartShift()
        {
            StartCoroutine(ShiftTimer.Timer(GameEventBus.EndOfShift));
            ResetPlayerPosition();
            SwitchJoystick();
        }

        private void ResetPlayerPosition() => 
            player.gameObject.transform.position = playerSpawnPoint.position;

        private void SwitchJoystick()
        {
            player.Mover.Joystick.enabled = joystick.enabled switch
            {
                true => false,
                false => true
            };
        }
    }
}

