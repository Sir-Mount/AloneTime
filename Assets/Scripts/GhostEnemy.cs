using UnityEngine;

public class GhostEnemy : MonoBehaviour {

    public float moveSpeed;
    public CharacterController controller;

    public float sanityLoss = -20f;

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        
        if (player) {
            Vector3 targetDirection = player.transform.position - transform.position;
            controller.Move(targetDirection.normalized * moveSpeed *Time.deltaTime);
        }

    }
}
