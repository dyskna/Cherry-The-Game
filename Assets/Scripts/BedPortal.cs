using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace WorldTime{
    public class BedPortal : MonoBehaviour, IInteractable
    {
        public Animator _animator;
        public GameObject player;
        public bool _isSlept;
        private bool _night = false;
        [SerializeField] private int bedTime;
        [SerializeField] private WorldTime _worldTime;
        
      
        

        void Start()
        {
            if (_worldTime == null)
            {
                Debug.LogError("WorldTime instance not found or not assigned.");
            }
            _animator = GetComponent<Animator>();
           // _worldTime = FindObjectOfType<WorldTime.WorldTime>();
            _worldTime.WorldTimeChanged += NightCheck;
            

        }
        public void Interact()
        {
            
            if(_night== true){
                _isSlept = true;
                player.SetActive(false);
                _animator.SetTrigger("Slept");
                Invoke("SetFalse",5.0f);
            
                _isSlept = false;
            
            }
            
        }

        void SetFalse()
        {
            //player.SetActive(true);
            //SceneManager.LoadScene("Nightmare");
            _isSlept = false;
        }

        private void NightCheck(object sender,TimeSpan newTime)
        {
            if (newTime != null && newTime.TotalHours >= bedTime){_night = true;}
            else{_night = false;}
        }
        public bool CanInteract()
        {
            return ! _isSlept;
        }
    
    }
}