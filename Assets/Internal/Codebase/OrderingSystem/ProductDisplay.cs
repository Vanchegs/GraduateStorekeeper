using Internal.Codebase;
using UnityEngine;
using UnityEngine.UI;

public class ProductDisplay : MonoBehaviour
{
    private IssuePoint issuePoint;
    
    [SerializeField] private Image image;
    [SerializeField] private ProductSpritesStorage spritesStorage;

    private void Start()
    {
        issuePoint = GetComponent<IssuePoint>();
        
        image.sprite = spritesStorage.ProductSprites[issuePoint.Product.ProductType];
    }
}
