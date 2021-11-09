using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // Components //
    public Text textComponent;

    Camera mainCamera;

    // Fields //

    public float raycastDistance = 3.0f;
    
    // Methods //

    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check that our camera component reference is valid
        if (mainCamera)
        {
            // define the hit variable we're going to use
            RaycastHit hit = new RaycastHit();
            Vector3 raycastStart = mainCamera.transform.position;
            Vector3 raycastDirection = mainCamera.transform.forward;

            // if we hit something 
            if (Physics.Raycast(raycastStart,raycastDirection, out hit, raycastDistance))
            {
                // get the name of the gameObject our raycast hit
                GameObject hitGameObject = hit.transform.gameObject;
                InteractionObject interactionObject = hitGameObject.GetComponent<InteractionObject>();

                if (interactionObject)
                {
                    // if the game object we hit with our raycast has an interaction
                    // object component 

                    ChangeText(interactionObject.interactionText);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactionObject.Interact();
                    }
                }
                else
                {
                    // if the game object we hit with our raycast doesn't have an
                    // interaction object component

                    ChangeText("");
                }


            }
            else
            {
                // if we didn't hit anything with our raycast
                // change our text component text to nothing
                ChangeText("");
            }
        }
    }

    // use this function to check if our text component reference is valid
    // save space elsewhere
    void ChangeText(string newText)
    {
        if (textComponent)
        {
            textComponent.text = newText;
        }   
    }

}
