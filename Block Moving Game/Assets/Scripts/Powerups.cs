using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Powerups : MonoBehaviour
{
    public Transform blockHolder;
    private float powerUpCooldown = 25f;
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
    public Timer timer;
    public RectTransform ambulance;
    public float ambulanceSpeed = 1f;
    public Transform ambulanceEndPoint; 
    public RectTransform progressBar; 
    private Vector3 ambulanceStartPos; 
    private Vector3 ambulanceEndPos;
    public AudioSource blips;
    public AudioSource pop;
    private void Start()
    {
        ambulanceStartPos = ambulance.position;
        ambulanceEndPos = ambulanceEndPoint.position;
        hydroxyureaButton.interactable = false;
        penicillinButton.interactable = false;
        adakveoButton.interactable = false;
        UpdateText();
    }
    void Update()
    {
        MoveAmbulance();
        UpdateProgressBar();
        powerUpCooldown -= Time.deltaTime;
        if (powerUpCooldown <= 0)
        {
            RandomPowerUp();
            powerUpCooldown = 25f;
            ambulance.position = ambulanceStartPos;
            blips.Play();
        }
        Interaction();
    }
    private void MoveAmbulance()
    {
        if (powerUpCooldown > 0)
        {
            float t = 1 - (powerUpCooldown / 25f); 
            ambulance.position = Vector3.Lerp(ambulanceStartPos, ambulanceEndPos, t); 
        }
    }
    private void UpdateProgressBar()
    {
        // Calculate the ratio of how far along the cooldown we are (from 0 to 1)
        float t = 1 - (powerUpCooldown / 25f); // t = 1 when cooldown is full (25), and t = 0 when it's done (0)

        // Update the width of the grey progress bar proportionally to the cooldown
        progressBar.localScale = new Vector3(t, 1, 1); // Adjust the scale's X to change the width
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
        pop.Play();
        randomSickleCell.gameObject.SetActive(false);
        hydroxyureaCount--;
        UpdateText();
    }
    public void Penicillin()
    {
        timer.AddTime(15f);
        pop.Play();
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
        pop.Play();
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
