using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // Game object used to take the transform of teleport destination
    private GameObject currentDoorTeleport;
    // Attachment for transition effect
    public Animator transition;
    // Adjustable delay for transition effect
    public float TransitionTime = 0.3f;
    
    // Input check
    void Update()
    {
     if (Input.GetButtonDown("Interact"))
        {
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // grabs destination on entering location of tagged object.
        if (collision.CompareTag("DoorTeleport"))
        {
            currentDoorTeleport = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // nulls destination on exit of area to prevent teleport when not over object
        if (collision.CompareTag("DoorTeleport"))
        {
            if (collision.gameObject == currentDoorTeleport)
            {
                currentDoorTeleport = null;
            }
        }
    }
    // Coroutine used to delay teleport only after transition effect is started 
    private IEnumerator Teleport()
    {
        // uses destination from DoorTP script to move player
        if (currentDoorTeleport != null)
            {
                transition.SetBool("Start", true);
                yield return new WaitForSeconds(TransitionTime);
                transform.position = (currentDoorTeleport.GetComponent<DoorTeleport>().GetDestination().position);
                transition.SetBool("Start", false);
            }
    }
}
