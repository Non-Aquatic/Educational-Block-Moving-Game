using UnityEngine;

public class TileController : MonoBehaviour
{
    public Transform checkUp;
    public Transform checkDown;
    public Transform checkLeft;
    public Transform checkRight;

    public void Start()
    {
        SetCheckPositionsActive(false);
    }
    public void MoveTile(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction; 
        transform.position = newPosition; 
    }

    public bool CanMove(Vector2 direction)
    {
        Transform checkPosition = null;
        if (direction == Vector2.up) checkPosition = checkUp;
        else if (direction == Vector2.down) checkPosition = checkDown;
        else if (direction == Vector2.left) checkPosition = checkLeft;
        else if (direction == Vector2.right) checkPosition = checkRight;

        BoxCollider2D checkCollider = checkPosition.GetComponent<BoxCollider2D>();

        SetCheckPositionsActive(true);

        Collider2D[] hits = Physics2D.OverlapBoxAll(checkPosition.position, checkCollider.size, 0f);

        SetCheckPositionsActive(false);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Tile") && hit.gameObject != gameObject) 
            {
                return false; 
            }
        }

        return true; 
    }

    private void SetCheckPositionsActive(bool isActive)
    {
        checkUp.gameObject.SetActive(isActive);
        checkDown.gameObject.SetActive(isActive);
        checkLeft.gameObject.SetActive(isActive);
        checkRight.gameObject.SetActive(isActive);
    }
}