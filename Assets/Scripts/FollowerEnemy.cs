using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyBase
{
    public float rotationSpeed;
    public float accelerationSpeed;
    public float moveSpeed;

    new void Start()
    {
        base.Start();
    }

    new void FixedUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player) //turn towards player
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(new Vector3(0f, newDirection.y, 0f));
            // transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

            if (GetComponent<Rigidbody>().velocity.magnitude < moveSpeed) rb.AddForce(Vector3.Normalize(targetDirection) * accelerationSpeed);
        }

        base.FixedUpdate();
    }
}
