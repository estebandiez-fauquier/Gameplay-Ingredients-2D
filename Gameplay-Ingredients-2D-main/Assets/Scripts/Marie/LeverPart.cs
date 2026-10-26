
using UnityEngine;

public class LeverPart : MonoBehaviour
{
    public GameObject interactionUI;

    public KeyCode interactKey = KeyCode.E;

    private bool playerInRange = false;

    private void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void Update()
    {
        
    }

}
