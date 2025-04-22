using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UILogic.StoreLogic
{
    public class ShiftPanelMover : MonoBehaviour
    {
        private bool isStoreActivate = false;

        [SerializeField] private RectTransform startPosition;
        [SerializeField] private RectTransform finalPosition;
        
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
                transform.DOMoveY(startPosition.position.y, 1.5f)
                    .SetUpdate(true)
                    .OnComplete(() => 
                    {
                        gameObject.SetActive(false);
                        isStoreActivate = false;
                    });
            }
        }
    }
}
