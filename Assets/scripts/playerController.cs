using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    private float sanity = 100f;
    public float sanityDepletion = 1f;
    
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        sanity -= sanityDepletion * Time.deltaTime;
        sanity = Mathf.Clamp(sanity, 0f, 100f);
        
        print(sanity.ToString());
    }

    public void adjustSanity(float amount) {
        sanity += amount;
        sanity = Mathf.Clamp(sanity, 0f, 100f);
    }
}
