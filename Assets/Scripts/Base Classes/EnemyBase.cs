using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class EnemyBase : MonoBehaviour
{

    public bool activated = true;
    public bool damageable;
    public int enemyHitPoints;
    public float invincibilityTime;
    public float speed;

    public Rigidbody rb;

    [CanBeNull] public GameObject drop;
    public float dropChance = 1;

    protected Vector3 direction;
    protected bool invincible = false;

    protected void Start()
    {

    }

    IEnumerator takeDamage(int damage)
    {
        invincible = true;
        enemyHitPoints -= damage;
        yield return new WaitForSecondsRealtime(invincibilityTime);
        invincible = false;
    }

    protected void FixedUpdate()
    {
        if (enemyHitPoints <= 0 && damageable)
        {
            Destroy(gameObject);
            if (drop && Random.Range(0f, 1f) < dropChance)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
        }
    }
}
