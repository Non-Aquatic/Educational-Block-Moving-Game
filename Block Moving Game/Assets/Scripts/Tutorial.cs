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
        tutorialText.text = "Welcome to the game! Your goal is to move the red blood cell here.";
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
                tutorialText.text = "All the way to the end of the map to the ending space here";
                SetArrow(1);
                timer = 7f;
                break;
            case 2:
                tutorialText.text = "To move a tile Click and hold on any tile to select it";
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
                tutorialText.text = "All cells can move either only horizontally or only vertically, unless they are made not sticky and can not move on top of other cells";
                timer = 7f;
                break;
            case 5:
                tutorialText.text = "Next look at the top of the screen. The ambulance will arrive every 25 seconds to give you a random medicine/powerup";
                SetArrow(4);
                timer = 7f;
                break;
            case 6:
                tutorialText.text = "In the top right here you can also see the amount of time left and amount of moves you have taken";
                SetArrow(5);
                timer = 7f;
                break;
            case 7:
                tutorialText.text = "Now at the bottom are your powerups which each have a different effect ";
                timer = 7f;
                break;
            case 8:
                tutorialText.text = "Hydroxyurea repairs sickle cells meaning it gets rid of a single random sickle cell";
                SetArrow(6);
                timer = 7f;
                break;
            case 9:
                tutorialText.text = "Penicillin prevents other dieseases caused by sickle cell meaning it increases your time left by 15 seconds";
                SetArrow(7);
                timer = 7f;
                break;
            case 10:
                tutorialText.text = "Adakveo makes sickle cells less sticky meaning it lets a random sickle cell vertically and horizaontally";
                SetArrow(8);
                timer = 7f;
                break;
            case 11:
                tutorialText.text = "If you ever need a refersher for the powerups you can hover over them to see what they do";
                timer = 7f;
                break;
            default:
                tutorialText.text = "To finish the tutorial, move the red blood cell to the end tile!";
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
