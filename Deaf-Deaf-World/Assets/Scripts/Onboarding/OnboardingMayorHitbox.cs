using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingMayorHitbox : MonoBehaviour {
    private BoxCollider colliderHitbox;
    [SerializeField]
    private OnboardingManager onboardingManager;

    // Start is called before the first frame update
    void Start() {
        colliderHitbox = gameObject.GetComponent<BoxCollider>();
        colliderHitbox.isTrigger = false;
    }

    public void Activate() {
        // Set the collider hitbox to be a trigger
        colliderHitbox.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            // Let the OnboardingManager know that it's time to change stage
            onboardingManager.AdvanceStage3();
        }
    }
}
