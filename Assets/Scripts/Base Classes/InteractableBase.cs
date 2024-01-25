using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    public virtual void Activate() {
        transform.localScale = transform.localScale*1.2f;
    }

    public virtual void Deactivate() {
        transform.localScale = transform.localScale/1.2f;
    }

    public virtual void Delete() {
        Destroy(gameObject);
    }
}
