using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLeg : MonoBehaviour
{
    [SerializeField] private AudioClip _impactSound;
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayImpactSound()
    {
        _source.PlayOneShot(_impactSound);
    }
}
