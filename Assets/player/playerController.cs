using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    float sanity = 100f;
    public float sanityDepletion = 1f;

    public AudioSource heartbeat;
    
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        sanity -= sanityDepletion * Time.deltaTime;
        sanity = Mathf.Clamp(sanity, 0f, 100f);

        heartbeat.volume = map(sanity, 75f, 0f, 0f, 0.75f);
        
        print(heartbeat.volume.ToString());
    }

    public void adjustSanity(float amount) {
        sanity += amount;
        sanity = Mathf.Clamp(sanity, 0f, 100f);
    }
    
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
}
