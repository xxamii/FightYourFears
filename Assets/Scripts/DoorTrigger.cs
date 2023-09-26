using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerGlobalReference>())
        {
            _door.Close();
            Destroy(gameObject);
        }
    }
}
