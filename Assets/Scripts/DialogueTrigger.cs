using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool _isRead = false;

    //private bool playerInRange;

    private void Awake()
    {   
        //playerInRange = false;
        visualCue.SetActive(true);
    }


    public void Interact()
    {
        if(_isRead == false){
        _isRead = true;
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        visualCue.SetActive(false);
    }
        }
       

    public bool CanInteract()
    {
        return ! _isRead;
    }
    
}
