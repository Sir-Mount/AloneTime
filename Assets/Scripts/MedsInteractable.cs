using UnityEngine;

public class MedsInteractable : InteractableBase
{
    public float sanityGain = 20f;
    
    public override void Activate() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<playerController>().adjustSanity(sanityGain);
        
        base.Delete();
    }
}
