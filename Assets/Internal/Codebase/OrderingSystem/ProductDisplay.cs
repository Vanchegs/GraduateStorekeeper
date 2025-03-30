using Internal.Codebase;
using UnityEngine;

public class ProductDisplay : MonoBehaviour
{
    private IssuePoint issuePoint;
    
    [SerializeField] private SpriteRenderer productSprite;
    [SerializeField] private ProductSpritesStorage spritesStorage;

    private void Start()
    {
        issuePoint = GetComponent<IssuePoint>();
        
        productSprite.sprite = spritesStorage.ProductSprites[issuePoint.Product.ProductType];
    }
}
