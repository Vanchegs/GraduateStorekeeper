using Internal.Codebase;
using UnityEngine;
using UnityEngine.UI;

public class ProductDisplay : MonoBehaviour
{
    private IssuePoint issuePoint;
    
    [SerializeField] private Image productImage;
    [SerializeField] private ProductSpritesStorage spritesStorage;

    private void Start()
    {
        issuePoint = GetComponent<IssuePoint>();
        
        productImage.sprite = spritesStorage.ProductSprites[issuePoint.Product.ProductType];
    }
}
