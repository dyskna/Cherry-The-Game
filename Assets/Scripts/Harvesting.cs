using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Harvesting : MonoBehaviour, IInteractable
{
    //animka
    public Animator _animator;
    private bool _isHarvested = false;
    public GameObject player;
    //text
    [SerializeField] private string[] _messages;
    [SerializeField] private GameObject _messagePrefab;
    
    

    void Start()
    {
        _animator = GetComponent<Animator>();

    }

    public void Interact()
    {

        //odpowiada za animke i znikanie postaci na 5 sec
        player.SetActive(false);
        
        
        _animator.SetTrigger("Harvested");

        //Invoke("SetFalse",5.0f);
        player.SetActive(true);
        _isHarvested = true;
        //text
        var randomIndex = Random.Range(0, _messages.Length);
        var message = _messages[randomIndex];
        var msgObject = Instantiate(_messagePrefab, transform.position, Quaternion.identity);
        msgObject.GetComponentInChildren<TMP_Text>().SetText(message);
        
        //zbieranie
        Collector collector = player.GetComponent<Collector>();
        collector.CherryCollector();


    }

//po 5 sekundach sie pojawia
    void SetFalse()
    {
        player.SetActive(true);
    }



    public bool CanInteract()
    {
        return ! _isHarvested && _messages != null && _messages.Length > 0;
    }

}
