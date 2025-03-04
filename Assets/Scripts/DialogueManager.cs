using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}
    private bool wybor = false ;
    private bool gg = false;




  private static DialogueManager instance;

    private void Awake()
    {

        if( instance != null)
         {
            Debug.LogWarning("More than one Dialogue Manager in the scene");
         }
         instance = this;
    
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }


    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        
     
        
        if (Input.GetButtonDown("Interact") && wybor == false && dialogueIsPlaying == true)
        {
            Debug.Log("twojastara");
            ContinueStory();
        }
        
        
    }

   

    
    public void EnterDialogueMode(TextAsset inkJSON) //1
    {
        currentStory = new Story(inkJSON.text);
        
        dialoguePanel.SetActive(true);
        gg = false;
        dialogueIsPlaying = true;
        ContinueStory();
       
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
    private void ContinueStory()
    { 
        if(currentStory.canContinue )
        {
            dialogueText.text = currentStory.Continue();
            
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }

    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices than can be supported. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
            if(index == 1)
            {
                wybor = true;
            }
        }
        
        for (int i = index; i < choices.Length ; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        
       
    }

    

    public void MakeChoice(int choiceIndex)
    {
        
        currentStory.ChooseChoiceIndex(choiceIndex);
        if(choiceIndex == 1)
        {
            ContinueStory();
            Invoke("Quit",5.0f);
            
        }
        else
        {
            ContinueStory();
            Debug.Log("dziala");
            wybor = false;
        }
        
    }

    void Quit()
    {
        Application.Quit();
    }
}
