using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objective : MonoBehaviour
{
    // Fields //
    public string incompleteText = "";
    public string completeText = "";
    public bool objectiveComplete = false;
    public bool enableOnStart = false;

    // Events //
    public UnityEvent<Objective> OnCompleteObjective = new UnityEvent<Objective>();

    // Methods //

    private void Start()
    {
        if (enableOnStart)
        {
            EnableObjective();
        }
    }

    // Use this function to enable the objective from the editor using Events
    public void EnableObjective()
    {
        // Find the player objectives script in the scene
        PlayerObjectives playerObjectives = FindObjectOfType<PlayerObjectives>();

        // Check if reference is valid
        if (playerObjectives)
        {
            
            playerObjectives.NewObjective(this);
        }
    }

    public void CompleteObjective()
    {
        objectiveComplete = true;
        OnCompleteObjective.Invoke(this);
    }
}
