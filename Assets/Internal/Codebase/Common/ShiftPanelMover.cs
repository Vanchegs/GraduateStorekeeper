using DG.Tweening;
using Internal.Codebase.Infrastructure;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShiftPanelMover : MonoBehaviour
    {
        private bool isStoreActivate = false;

        [SerializeField] private RectTransform startPosition;
        [SerializeField] private RectTransform finalPosition;

        private void Awake() => 
            GameEventBus.EndOfShift += MovePanel;

        private void OnDisable() => 
            GameEventBus.EndOfShift -= MovePanel;

        public void MovePanel()
        {
            if (isStoreActivate == false)
            {
                transform.DOMoveY(finalPosition.position.y, 1.5f, false);
                isStoreActivate = true;
                gameObject.SetActive(isStoreActivate);
            }
            else
            {
                transform.DOMoveY(startPosition.position.y, 1.5f, false);
                isStoreActivate = false;
            }
        }
    }
}
