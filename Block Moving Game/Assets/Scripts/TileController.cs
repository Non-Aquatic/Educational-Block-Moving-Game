using TMPro;
using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{
    public Transform checkUp;
    public Transform checkDown;
    public Transform checkLeft;
    public Transform checkRight;

    // New variable to determine movement direction
    public bool canMoveVertically = true; // Allow vertical movement by default
    public bool canMoveHorizontally = false; // Allow horizontal movement by default

    public void Start()
    {
        SetCheckPositionsActive(false);
    }

    public void MoveTile(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction;
        StartCoroutine(SmoothMoveToPosition(newPosition));
    }
    private IEnumerator SmoothMoveToPosition(Vector3 targetPosition)
    {
        float timeElapsed = 0f;
        Vector3 startingPosition = transform.position;

        while (timeElapsed < .1)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, timeElapsed / .1f);
            timeElapsed += Time.deltaTime;
            yield return null; 
        }
        transform.position = targetPosition;
    }
    public bool CanMove(Vector2 direction)
    {
        // Allow movement checks based on allowed direction
        if ((direction == Vector2.up || direction == Vector2.down) && !canMoveVertically) return false;
        if ((direction == Vector2.left || direction == Vector2.right) && !canMoveHorizontally) return false;

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