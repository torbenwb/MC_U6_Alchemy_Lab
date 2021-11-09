using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerObjectives : MonoBehaviour
{
    // Components //
    public Text objectiveText;

    // Fields //
    public List<Objective> objectives = new List<Objective>();

    // Methods //

    // Used to add new objectives to our list 
    // Add objective complete callback to newObjective.OnCompleteObjective event
    // Updated objective text
    public void NewObjective(Objective newObjective)
    {
        objectives.Add(newObjective);
        newObjective.OnCompleteObjective.AddListener(ObjectiveCompleteCallback);
        UpdateObjectiveText();
    }

    private void ObjectiveCompleteCallback(Objective objective)
    {
        if (objectives.Contains(objective))
        {
            objectives.Remove(objective);

            UpdateObjectiveText();
        }
    }

    private void UpdateObjectiveText()
    {
        if (objectiveText)
        {
            string newObjectiveText = "";

            foreach(Objective o in objectives)
            {
                if (o.objectiveComplete)
                {
                    newObjectiveText += "\n" + o.completeText;
                }
                else
                {
                    newObjectiveText += "\n" + o.incompleteText;
                }
                
            }

            objectiveText.text = newObjectiveText;
        }
        
    }
}
