using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneTransitionTrigger : MonoBehaviour
{
    [SerializeField] private Scene _sceneToLoad;

    private SceneTransitions _sceneTransitions;

    private void Start()
    {
        _sceneTransitions = SceneTransitions.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneTransitioner traveler = other.GetComponent<SceneTransitioner>();

        if (traveler != null)
        {
            _sceneTransitions.LoadScene(_sceneToLoad);
            traveler.Freeze();
        }
    }
}
