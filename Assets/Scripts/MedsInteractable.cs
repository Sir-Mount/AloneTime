using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedsInteractable : InteractableBase
{
    public override void Activate() {
        // hier logic voor sanity++, daarna delete
        base.Delete();
    }
}
