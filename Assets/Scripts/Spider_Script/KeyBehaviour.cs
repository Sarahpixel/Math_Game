using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] SwitchBehaviour _SB;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _SB.DoorLockedStatus();
            Destroy(gameObject);
        }
    }
}
