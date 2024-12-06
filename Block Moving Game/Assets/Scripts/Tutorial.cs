using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;  
    public GameManager gameManager; 
    public AudioSource move;

    public GameObject[] arrows;  

    private int currentStep = 0; 

    private float timer = 7f; 

    void Start()
    {
        tutorialText.text = "Welcome, medical student! Today, I'll guide you through managing a case of sickle cell disease. Your goal is to help the red blood cell.";
        DeactivateAllArrows();
        SetArrow(0);
    }

    void Update()
    {
        if (currentStep == 0 || currentStep == 1 || currentStep == 4 || currentStep == 5 || currentStep == 6 || currentStep == 7 || currentStep == 8 || currentStep == 9 || currentStep == 10 || currentStep == 11)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ProceedToNextStep();
            }
        }

        if (currentStep == 2 && gameManager.selectedTile != null)
        {
            ProceedToNextStep();
        }

        if (currentStep == 3 && move.isPlaying)
        {
            ProceedToNextStep();
        }
    }
    private void ProceedToNextStep()
    {
        currentStep++;

        DeactivateAllArrows();

        switch (currentStep)
        {
            case 1:
                tutorialText.text = "by guiding it from one end of the vein to the other, until it reaches the final space ";
                SetArrow(1);
                timer = 7f;
                break;
            case 2:
                tutorialText.text = "To move a cell, you first have to click and hold on that cell to select it";
                SetArrow(0);
                SetArrow(2);
                SetArrow(3);
                timer = 7f;
                break;
            case 3:
                tutorialText.text = "Now, swipe in the direction you want to move the tile, the arrows will tell you which direction they can move in";
                timer = 7f;
                break;
            case 4:
                tutorialText.text = "All cells can move either only horizontally or only vertically and can not move on top of other cells";
                timer = 7f;
                break;
            case 5:
                tutorialText.text = "Next look at the top of the screen. The ambulance will arrive every 25 seconds to give you a random treatment that will help you manage sickle cell disease";
                SetArrow(4);
                timer = 10f;
                break;
            case 6:
                tutorialText.text = "In the top right here you can also see the amount of time left and amount of moves you have left. If they reach zero,you lose";
                SetArrow(5);
                timer = 7f;
                break;
            case 7:
                tutorialText.text = "Now at the bottom are your treaments, each one has a different effect that can help treat sickle cell disease";
                timer = 7f;
                break;
            case 8:
                tutorialText.text = "Hydroxyurea is a treatment that repairs sickle cells. It will remove a single random sickle cell from the vein";
                SetArrow(6);
                timer = 10f;
                break;
            case 9:
                tutorialText.text = "Penicillin helps prevent infections caused by sickle cell disease. It will give you 20 seconds more seconds to guide the red blood cell"; ;
                SetArrow(7);
                timer = 10f;
                break;
            case 10:
                tutorialText.text = "Adakveo helps make sickle cells less \"sticky\", allowing them to move more freely. This power-up will let a random sickle cell move vertically and horizontally";
                SetArrow(8);
                timer = 10f;
                break;
            case 11:
                tutorialText.text = "If you ever need a refersher for the powerups you can hover over them to see what they do";
                timer = 7f;
                break;
            default:
                tutorialText.text = "To finish the tutorial move the healthy red blood cell to the end of the vein to restore blood flow";
                timer = 7f;
                break;
        }
    }

    private void SetArrow(int number)
    {
        arrows[number].SetActive(true);
    }
    private void DeactivateAllArrows()
    {
        foreach (var arrow in arrows)
        {
            arrow.SetActive(false);
        }
    }
}
