using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeSnapshotTrigger : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot _snapshot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerGlobalReference>())
        {
            _snapshot.TransitionTo(0f);
        }
    }
}
