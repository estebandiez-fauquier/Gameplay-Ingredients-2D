
using UnityEngine;
using static Unity.U2D.Physics.PhysicsComposer;

public class Lever : MonoBehaviour
{
    [Header("Lever State")]
    public bool repaired = false;
    public bool activated = false;

    [Header("Sprites")]
    public Sprite brokenSprite;
    public Sprite repairedSprite;
    public Sprite activatedSprite;

    [Header("Interaction")]
    public GameObject interactionUI;

    [Header("Bridge")]
    public Animator bridgeAnimator;

    public PlayerInventory playerInventory;
    private SpriteRenderer spriteRenderer;
    private bool playerInRange = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (interactionUI != null)
            interactionUI.SetActive(false);

        if (spriteRenderer != null && brokenSprite != null)
            spriteRenderer.sprite = brokenSprite;
    }

    private void Update()
    {
        if (!playerInRange)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!repaired)
            {
                RepairLever();
            }
            else if (!activated)
            {
                ActivateLever();
            }
        }
    }

    private void RepairLever()
    {
        if (!playerInventory.IsInInventory("LEVERHANDLE"))
        {
            Debug.Log("You need the lever part first!");
            return;
        }

        repaired = true;
        playerInventory.RemoveItemFromInventory("LEVERHANDLE");

        if (spriteRenderer != null && repairedSprite != null)
            spriteRenderer.sprite = repairedSprite;

        Debug.Log("Lever repaired!");
    }

    private void ActivateLever()
    {
        activated = true;

        if (spriteRenderer != null && activatedSprite != null)
            spriteRenderer.sprite = activatedSprite;

        if (bridgeAnimator != null)
            bridgeAnimator.SetTrigger("Down");

        Debug.Log("Lever activated! Bridge is moving down.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
