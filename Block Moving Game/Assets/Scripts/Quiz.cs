using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Button mainMenuButton;

    string[] questions = {
        "What causes sickle cell disease?\nA) A mutation in the HBB gene\nB) A bacterial infection\nC) Cancer\nD) Mutation in the X chromosome",
        "What is a major complication of sickle cell disease?\nA) Increased red blood cell flexibility\nB) Blockage of small blood vessels\nC) Improved oxygen delivery\nD) Decreased risk of infections",
        "How many people worldwide are estimated to be affected by sickle cell disease?\nA) 16 million\nB) 50 million\nC) 100,000\nD) 8 million",
        "What is one potential cure for sickle cell disease?\nA) Bone marrow transplants\nB) Hydroxyurea\nC) Radiation therapy\nD) Adakveo",
        "Which of the following is a feature of the new gene therapy called exa-cel?\nA) It breaks down all sickle cells\nB) It corrects the mutation in the patient's brain\nC) It modifies stem cells\nD) It requires a long-term treatment plan",
        "Which of the following is a complication that can occur due to sickle cell disease if not properly managed?\nA) Blindness\nB) Hearing loss\nC) Lung cancer\nD) Strokes",
        "Sickle cell disease is most commonly found in regions where which disease was historically prevalent?\nA) Tuberculosis\nB) Malaria\nC) Polio\nD) Influenza"
    };

    string[] correctAnswers = { "A", "B", "D", "A", "C", "D", "B" };

    string[,] feedback = {
        { "Correct!\n\n Sickle cell disease is caused by a mutation in the HBB gene.",
          "Incorrect!\n\n Sickle cell disease is caused by a mutation in the HBB gene, not by a bacterial infection.",
          "Incorrect!\n\n Cancer does not cause sickle cell disease, it's a genetic condition.",
          "Incorrect!\n\n While mutations do cause sickle cell disease, it's not in the X chromosome." },

        { "Incorrect!\n\n Sickle cell disease causes red blood cells to becomes LESS flexible",
          "Correct!\n\n Blockage of blood vessels is a major complication caused by sickled red blood cells.",
          "Incorrect!\n\n Sickle cell disease leads to blocked blood flow, deteriorating oxygen delivery.",
          "Incorrect!\n\n Sickle cell disease causes higher risks of infections, not a decrease in risk." },

        { "Incorrect!\n\n While 16 million people might be affected by other genetic conditions, sickle cell disease affects around 8 million people worldwide.",
          "Incorrect!\n\n 50 million is an extreme overestimate.",
          "Incorrect!\n\n 100,000 is the estimated number of Americans affected by sickle cell disease, not the people worldwide.",
          "Correct!\n\n It is estimated that 8 million people worldwide are affected by sickle cell disease."},

        { "Correct!\n\n Bone marrow transplants offer a potential cure for sickle cell disease with the correct donor.",
          "Incorrect!\n\n Hydroxyurea is used to manage symptoms, not to cure sickle cell disease.",
          "Incorrect!\n\n Radiation therapy is not a treatment for sickle cell disease.",
          "Incorrect!\n\n Adakveo is used to reduce the number of sickle cell crises by making them less \"sticky\", but it is not a cure for sickle cell disease." },

        { "Incorrect!\n\n Exa-cel does not break down sickle cells. Instead, it modifies stem cells to correct the mutation causing sickle cell disease.",
          "Incorrect!\n\n Exa-cel corrects the mutation in the bone marrow, not the brain.",
          "Correct!\n\n Exa-cel modifies stem cells using CRISPR technology to correct the mutation in the patient's bone marrow, offering a potential cure for sickle cell disease.",
          "Incorrect!\n\n Exa-cel is a one-time treatment, not a long-term treatment plan." },

        { "Incorrect!\n\n Blindness is not a common complication of sickle cell disease it can occur in certain cases due to other factors.",
          "Incorrect!\n\n Hearing loss is unrelated to sickle cell disease.",
          "ncorrect!\n\n Lung cancer is not a complication of sickle cell disease. Sickle cell can affects the lungs but it is not linked to cancer.",
          "Correct!\n\n Stroke is a major complication of sickle cell disease, as the sickled red blood cells can block blood flow to the brain, leading to strokes" },

        { "Incorrect!\n\n Tuberculosis is a significant infectious disease, but it is not related sickle cell disease.",
          "Correct!\n\n Malaria is historically associated with areas where sickle cell disease is prevalent.",
          "Incorrect!\n\n Polio is not linked to sickle cell disease.",
          "Incorrect!\n\n Influenza is not linked to sickle cell disease." }
    };

    int currentQuestionIndex = 0;
    int score = 0;

    void Start()
    {
        buttonA.onClick.AddListener(() => CheckAnswer("A"));
        buttonB.onClick.AddListener(() => CheckAnswer("B"));
        buttonC.onClick.AddListener(() => CheckAnswer("C"));
        buttonD.onClick.AddListener(() => CheckAnswer("D"));
        mainMenuButton.onClick.AddListener(() => Main());

        mainMenuButton.gameObject.SetActive(false);
        StartCoroutine(DisplayQuestion());
    }

    IEnumerator DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];

            scoreText.text = "Score: " + score;
        }
        else
        {
            EvaluatePerformance();
        }
        yield return null;
    }

    void CheckAnswer(string selectedAnswer)
    {
        string correctAnswer = correctAnswers[currentQuestionIndex];
        StartCoroutine(ShowFeedback(selectedAnswer, correctAnswer));
    }

    IEnumerator ShowFeedback(string selectedAnswer, string correctAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            score++;
            questionText.text = "Correct!";
        }
        int answerIndex = Array.IndexOf(new string[] { "A", "B", "C", "D" }, selectedAnswer);
        questionText.text = feedback[currentQuestionIndex, answerIndex];

        yield return new WaitForSeconds(4f);

        currentQuestionIndex++;

        StartCoroutine(DisplayQuestion());
    }

    void EvaluatePerformance()
    {
        if (score >= 5)
        {
            questionText.text = "You passed! Score: " + score + "/7";
        }
        else
        {
            questionText.text = "You failed. Better luck next time. Score: " + score + "/7";
        }
        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
        buttonC.gameObject.SetActive(false);
        buttonD.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(true);
    }
    public void Main()
    {
        SceneManager.LoadScene("Main Menu");
    }
}