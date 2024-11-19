using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TileController selectedTile;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    public AudioSource moveSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTile();
            touchStartPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && selectedTile != null)
        {
            touchEndPos = Input.mousePosition;
            DetectSwipe();
            selectedTile = null;
        }
    }

    private void SelectTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("Tile"))
        {
            selectedTile = hit.collider.GetComponent<TileController>();
        }
    }
    
    private void DetectSwipe()
    {
        Vector2 swipeDelta = touchEndPos - touchStartPos;

        swipeDelta.Normalize();
        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > 0 && selectedTile.CanMove(Vector2.right))
            {
                selectedTile.MoveTile(Vector2.right);
                moveSound.Play();
            }
            else if (swipeDelta.x < 0 && selectedTile.CanMove(Vector2.left))
            {
                selectedTile.MoveTile(Vector2.left);
                moveSound.Play();
            }
        }
        else
        {
            if (swipeDelta.y > 0 && selectedTile.CanMove(Vector2.up))
            {
                selectedTile.MoveTile(Vector2.up);
                moveSound.Play();
            }
            else if (swipeDelta.y < 0 && selectedTile.CanMove(Vector2.down))
            {
                selectedTile.MoveTile(Vector2.down);
                moveSound.Play();
            }
        }
    }
}
