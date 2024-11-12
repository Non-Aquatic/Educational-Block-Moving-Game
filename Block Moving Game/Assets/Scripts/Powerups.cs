using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Powerups : MonoBehaviour
{
    public Transform blockHolder;
    public float timeRemaining = 60f;
    private float powerUpCooldown = 25f;
    public TextMeshProUGUI timerText;
    public Sprite AdakveoSprite;
    public Button hydroxyureaButton;
    public Button penicillinButton;
    public Button adakveoButton;
    public TextMeshProUGUI hydroxyureaText;
    public TextMeshProUGUI penicillinText;
    public TextMeshProUGUI adakveoText;
    private int hydroxyureaCount = 0;
    private int penicillinCount = 0;
    private int adakveoCount = 0;
    private void Start()
    {
        hydroxyureaButton.interactable = false;
        penicillinButton.interactable = false;
        adakveoButton.interactable = false;
        UpdateText();
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeRemaining).ToString() + "s left";  
        }
        powerUpCooldown -= Time.deltaTime;
        if (powerUpCooldown <= 0)
        {
            RandomPowerUp();
            powerUpCooldown = 25f; 
        }
        Interaction();
    }
    private void RandomPowerUp()
    {
        int randomPowerUp = Random.Range(0, 3);
        if (randomPowerUp == 0)
        {
            hydroxyureaCount++;
        }
        else if (randomPowerUp == 1)
        {
            penicillinCount++;
        }
        else if (randomPowerUp == 2)
        {
            adakveoCount++;
        }
        UpdateText();
    }
    public void Hydroxyurea()
    {
        int sickleCells = blockHolder.childCount;
        int random = Random.Range(0, sickleCells);
        Transform randomSickleCell = blockHolder.GetChild(random);
        randomSickleCell.gameObject.SetActive(false);
        hydroxyureaCount--;
        UpdateText();
    }
    public void Penicillin()
    {
        timeRemaining += 15f;
        penicillinCount--;
        UpdateText();
    }
    public void Adakveo()
    {
        int sickleCells = blockHolder.childCount;
        int random = Random.Range(0, sickleCells);
        Transform randomSickleCell = blockHolder.GetChild(random);
        TileController tileController = randomSickleCell.GetComponent<TileController>();
        tileController.canMoveVertically = true;
        tileController.canMoveHorizontally = true;
        SpriteRenderer tileSpriteRenderer = randomSickleCell.GetComponentInChildren<SpriteRenderer>();
        tileSpriteRenderer.sprite = AdakveoSprite;
        adakveoCount--;
        UpdateText();
    }
    private void Interaction()
    {
        hydroxyureaButton.interactable = hydroxyureaCount > 0;
        penicillinButton.interactable = penicillinCount > 0;
        adakveoButton.interactable = adakveoCount > 0;
    }
    private void UpdateText()
    {
        hydroxyureaText.text = hydroxyureaCount.ToString();
        penicillinText.text = penicillinCount.ToString();
        adakveoText.text = adakveoCount.ToString();
    }
}
