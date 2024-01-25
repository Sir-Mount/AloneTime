using System.Collections;
using UnityEngine;

public class GrabberEnemy : MonoBehaviour
{
    public float attackCooldownTime;
    
    public bool attackOnCooldown = false;

    public float sanityLoss = -10f;

    public IEnumerator Attack() {
        // Debug.Log("whack");
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<playerController>().adjustSanity(sanityLoss);
        
        gameObject.transform.localScale = new Vector3(transform.localScale.x, 2, transform.localScale.z);
        attackOnCooldown = true;
        yield return new WaitForSecondsRealtime(attackCooldownTime);
        gameObject.transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        attackOnCooldown = false;
    }
}
