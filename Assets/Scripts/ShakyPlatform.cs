using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyPlatform : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private AudioClip _crackSound;
    [SerializeField] private GameObject _crackPartickles;
    private AudioSource _source;

    private bool _isDestroying;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerGlobalReference>() && !_isDestroying)
        {
            StartCoroutine(DestroyRoutine());
            _source.PlayOneShot(_crackSound);
            _isDestroying = true;
        }
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        DestroySelf();
    }

    private void DestroySelf()
    {
        Instantiate(_crackPartickles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
