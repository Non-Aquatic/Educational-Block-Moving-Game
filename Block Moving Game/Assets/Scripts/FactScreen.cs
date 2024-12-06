using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FactScreen : MonoBehaviour
{
    public Button skipButton;
    private string[] facts = new string[6];
    public TMP_Text factText;
    private int factIndex;
    string lastScene = "";
    
    void Start()
    {
        skipButton.onClick.AddListener(SkipToNextScene);

        facts[0] = " • Sickle cell disease is a genetic blood disorder that is caused by a mutation in the HBB gene. \n" +
                   " • This gene instructs the body on how to make hemoglobin which is the protein in red blood cells that carries oxygen. \n" +
                   " • This mutation causes red blood cells to form a rigid, sickle-like shape that can cause various complications.";
        facts[1] = " • Sickled red blood cells are less flexible, which can can lead to small blood vessels becoming blocked.\n\n" +
                   " • This causes severe pain in episodes known as \"sickle cell crises.\"\n\n" +
                   " • Other complications include increased risk of infections, organ damage, and anemia.";
        facts[2] = " • Sickle cell disease is particularly common among people of African descent.\n\n" +
                   " • It is estimated to affect about 100,000 Americans and 8 million worldwide.\n\n" +
                   " • It is especially common in areas where malaria is or was previously common.";
        facts[3] = " • Traditional treatments, such as blood transfusions and medications like hydroxyurea, focus on managing symptoms, including pain relief and anemia.\n" +
                   " • Bone marrow transplants offer a potential cure for sickle cell disease, but success depends on finding a donor with matching human leukocyte antigen (HLA) markers.\n" +
                   " • If these markers don’t match, the body may reject the transplant or attack the new cells, leading to serious complications like graft-versus-host disease.";
        facts[4] = " • In 2023, a new gene therapy called exa-cel was developed by CRISPR Therapeutics and Vertex Pharaceuticals and received regulatory approval in some regions.\n" +
                   " • This therapy uses CRISPR gene-editing technology to modify stem cells and correct the mutation in the patient's bone marrow.\n" +
                   " • This breakthrough offers new hope as a one-time treatment that could potentially cure sickle cell disease.";
        facts[5] = " • Over time, sickle cell disease can damage organs such as the kidneys, liver, heart, and lungs due to lack of oxygen and blood flow." +
                   " • It can also lead to complications like acute chest syndrome, strokes, and delayed growth in children if not properly handled.";


        factIndex = (factIndex + 1) % facts.Length;
        lastScene = PlayerPrefs.GetString("lastSceneName");
        int levelNumber = 0;
        if (lastScene.StartsWith("Level"))
        {
            int.TryParse(lastScene.Substring(6), out levelNumber);
        }
        factIndex = levelNumber;
        factText.fontSize = 35;

        if (lastScene == "Main Menu" || lastScene == "Tutorial")
           
        {
            factIndex = 0;
        }
        
        factText.text = facts[factIndex];
        Invoke("LoadNextScene", 20);
    }

    void SkipToNextScene()
    {
        lastScene = PlayerPrefs.GetString("lastSceneName");

        SceneManager.LoadScene("Level Select");
    }

    void LoadNextScene()
    {
        lastScene = PlayerPrefs.GetString("lastSceneName");

        SceneManager.LoadScene("Level Select");
    }
}
