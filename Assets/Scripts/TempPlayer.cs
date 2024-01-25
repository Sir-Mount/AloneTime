using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Grabber" && !other.gameObject.GetComponent<GrabberEnemy>().attackOnCooldown)
        {
            StartCoroutine(other.gameObject.GetComponent<GrabberEnemy>().Attack());
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Interactable") {
            other.gameObject.GetComponent<InteractableBase>().Activate();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Interactable") {
            other.gameObject.GetComponent<InteractableBase>().Deactivate();
        }
    }
}
