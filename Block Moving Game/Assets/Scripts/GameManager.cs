using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileController selectedTile;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    public AudioSource moveSound;

    public GameObject movesObject;
    public GameObject dimming;
    public int moveLimit;
    public TMP_Text movesText;

    private void Start()
    {
        movesObject.SetActive(false);
        dimming.SetActive(false);
        movesText.text = "Moves: " + moveLimit.ToString();
        Time.timeScale = 1f;
    }

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

        movesText.text = "Moves: " + moveLimit.ToString();
        if (moveLimit == 0)
        {
            EnableOOM();
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
                moveLimit -= 1;
            }
            else if (swipeDelta.x < 0 && selectedTile.CanMove(Vector2.left))
            {
                selectedTile.MoveTile(Vector2.left);
                moveSound.Play();
                moveLimit -= 1;
            }
        }
        else
        {
            if (swipeDelta.y > 0 && selectedTile.CanMove(Vector2.up))
            {
                selectedTile.MoveTile(Vector2.up);
                moveSound.Play();
                moveLimit -= 1;
            }
            else if (swipeDelta.y < 0 && selectedTile.CanMove(Vector2.down))
            {
                selectedTile.MoveTile(Vector2.down);
                moveSound.Play();
                moveLimit -= 1;
            }
        }
    }

    void EnableOOM()
    {
        movesObject.SetActive(true);
        dimming.SetActive(true);
        Time.timeScale = 0f;
    }
}
