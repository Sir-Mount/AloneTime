using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    float sanity = 100f;
    public float sanityDepletion = -2f;

    public AudioSource heartbeat;
    public AudioSource breathing;

    public Text clock;
    public float minute = 0;
    public int hour = 1;
    
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        sanity -= sanityDepletion * Time.deltaTime;
        sanity = Mathf.Clamp(sanity, 0f, 100f);

        heartbeat.volume = map(sanity, 50f, 0f, 0f, 1f);
        breathing.volume = map(sanity, 75f, 0f, 0f, 0.5f);
        
        print(sanity.ToString());

        doTime();
    }
    
    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Grabber" && !other.gameObject.GetComponent<GrabberEnemy>().attackOnCooldown){
            StartCoroutine(other.gameObject.GetComponent<GrabberEnemy>().Attack());
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Interactable") {
            other.gameObject.GetComponent<InteractableBase>().Activate();
        }
        
        if (other.gameObject.tag == "Ghost"){
            adjustSanity(other.gameObject.GetComponent<GhostEnemy>().sanityLoss);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Interactable") {
            other.gameObject.GetComponent<InteractableBase>().Deactivate();
        }
    }

    void doTime() {
        minute += Time.deltaTime;
        float actualMinute = Mathf.Floor(minute);

        if(minute >= 60f){
            minute = 0f;
            hour++;
        }
        
        clock.text = hour.ToString("00") + ":" + actualMinute.ToString("00");
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