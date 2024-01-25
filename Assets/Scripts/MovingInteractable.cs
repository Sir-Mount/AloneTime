using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInteractable : InteractableBase
{
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    private bool isMoving;

    void Update()
    {
        if (isMoving) {
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, endMarker.position, step);
        }
    }

    public override void Activate()
    {
        isMoving = true;
    }
}
