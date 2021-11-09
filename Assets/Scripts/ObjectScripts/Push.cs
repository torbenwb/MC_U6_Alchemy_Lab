using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    Rigidbody rigidbody;

    public float pushStrength = 100.0f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void PushObject()
    {
        if (rigidbody)
        {
            Vector3 pushVector = transform.position - Camera.main.transform.position;

            pushVector.Normalize();

            rigidbody.AddForce(pushVector * pushStrength,ForceMode.VelocityChange);
        }
    }
}
