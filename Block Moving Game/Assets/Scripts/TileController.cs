using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    public Transform checkUp;
    public Transform checkDown;
    public Transform checkLeft;
    public Transform checkRight;
    private Collider2D tileCollider; 


    public Vector2 checkSize = new Vector2(1f, 1f); 
    public float moveDistance = 1f; 
    public GameObject buttonPrefab; 
    public Canvas canvas; 

    private void Start()
    {
        tileCollider = GetComponent<Collider2D>(); 
        HideMovementOptions();
    }

    private void OnMouseDown()
    {
        ShowMovementOptions();
    }

    private void ShowMovementOptions()
    {
        tileCollider.enabled = false;
        if (CanMove(Vector2.up)) CreateButton(Vector2.up, new Vector3(0, 50, 0));   
        if (CanMove(Vector2.down)) CreateButton(Vector2.down, new Vector3(0, -50, 0)); 
        if (CanMove(Vector2.left)) CreateButton(Vector2.left, new Vector3(-50, 0, 0)); 
        if (CanMove(Vector2.right)) CreateButton(Vector2.right, new Vector3(50, 0, 0)); 
    }


    private void CreateButton(Vector2 direction, Vector3 offset)
    {
        GameObject button = Instantiate(buttonPrefab, canvas.transform);

        Vector3 canvasPosition = Camera.main.WorldToScreenPoint(transform.position);

        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, canvasPosition, Camera.main, out localPoint);

        Vector2 buttonPosition = localPoint + (Vector2)offset;

        button.GetComponent<RectTransform>().anchoredPosition = buttonPosition;

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(() => MoveTile(direction));
        btn.onClick.AddListener(HideMovementOptions); 
    }



    private void MoveTile(Vector2 direction)
    {
        Vector3 newPosition = transform.position + (Vector3)direction * moveDistance;
        transform.position = newPosition; 
    }

    private void HideMovementOptions()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.CompareTag("DirButton"))
            {
                Destroy(child.gameObject);
            }
        }
        tileCollider.enabled = true;
    }

    private bool CanMove(Vector2 direction)
    {
        Transform checkPosition = null;

        if (direction == Vector2.up) checkPosition = checkUp;
        else if (direction == Vector2.down) checkPosition = checkDown;
        else if (direction == Vector2.left) checkPosition = checkLeft;
        else if (direction == Vector2.right) checkPosition = checkRight;

        // Check for collisions
        Collider2D[] hits = Physics2D.OverlapBoxAll(checkPosition.position, checkSize, 0f);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Tile"))
            {
                return false; 
            }
        }

        return true; 
    }

}
