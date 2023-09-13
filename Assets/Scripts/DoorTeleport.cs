using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    // Transform of object set as destination from object.
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }
}
