using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentDoorTeleport;
    public Animator transition;
    public float TransitionTime = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
     if (Input.GetButtonDown("Interact"))
        {
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DoorTeleport"))
        {
            currentDoorTeleport = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DoorTeleport"))
        {
            if (collision.gameObject == currentDoorTeleport)
            {
                currentDoorTeleport = null;
            }
        }
    }
    private IEnumerator Teleport()
    {
        if (currentDoorTeleport != null)
            {
                transition.SetBool("Start", true);
                yield return new WaitForSeconds(TransitionTime);
                transform.position = currentDoorTeleport.GetComponent<DoorTeleport>().GetDestination().position;
                transition.SetBool("Start", false);
            }
    }
}
