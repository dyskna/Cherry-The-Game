using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    bool CanInteract();
}
public class chest : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    private Animator _animator;
    private bool _isOpened;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void Interact()
    {
        _isOpened = true;
        _animator.SetTrigger("open");
    }
    public bool CanInteract()
    {
        return ! _isOpened;
    }

}
