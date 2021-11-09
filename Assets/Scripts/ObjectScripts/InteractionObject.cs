using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    // Components //

    // Fields //
    
    public string interactionText = "Hello";
    public bool canInteract = false;

    // Events //
    public UnityEvent OnInteract = new UnityEvent();

    // Methods //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (canInteract)
        {
            OnInteract.Invoke();
        }
    }

    public void SetCanInteract(bool value)
    {
        canInteract = value;
    }
}
