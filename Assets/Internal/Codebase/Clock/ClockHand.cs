using UnityEngine;
using DG.Tweening;

public class ClockHand : MonoBehaviour
{
    // [Header("Settings")]
    // [SerializeField] private float rotationDuration = 0.5f;
    // [SerializeField] private Ease easeType = Ease.OutElastic;
    // [SerializeField] private bool smoothMovement = true;

    private RectTransform rectTransform;
    private Vector2 originalPivot;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        
        originalPivot = rectTransform.pivot;
        
        rectTransform.pivot = new Vector2(0f, originalPivot.y);
    }

    private void Start()
    {
        StartContinuousRotation(ShiftTimer.ShiftDuration);
    }
    
    private void OnDisable()
    {
        if (rectTransform != null) 
            rectTransform.pivot = originalPivot;
    }
    
    public void StartContinuousRotation(float secondsPerRotation)
    {
        transform.rotation = Quaternion.identity;
        
        transform.DORotate(new Vector3(0, 0, -360), secondsPerRotation, RotateMode.FastBeyond360)
                 .SetEase(Ease.Linear)
                 .SetLoops(-1, LoopType.Restart);
    }
    
    public void ResetClock()
    { 
        rectTransform.DOKill(); 
        rectTransform.rotation = Quaternion.Euler(0, 0, 0); 
        
        StartContinuousRotation(ShiftTimer.ShiftDuration);
    }
}