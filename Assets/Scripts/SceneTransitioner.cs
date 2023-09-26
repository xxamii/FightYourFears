using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitioner : MonoBehaviour
{
    private CharacterMovement _movement;
    private PlayerInput _input;

    private void Start()
    {
        _movement = GetComponent<CharacterMovement>();
        _input = GetComponent<PlayerInput>();
    }

    public void Freeze()
    {
        _input.BlockInput();
        _movement.Stop();
    }
}
