using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatable : MonoBehaviour
{
    protected Animator _animator;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void PlayBoolOn(string state)
    {
        _animator.SetBool(state, true);
    }

    public virtual void PlayBoolOff(string state)
    {
        _animator.SetBool(state, false);
    }

    public virtual void PlayTrigger(string state)
    {
        _animator.SetTrigger(state);
    }

    public void ResetTrigger(string state)
    {
        _animator.ResetTrigger(state);
    }

    public virtual void SetFloat(string name, float value)
    {
        _animator.SetFloat(name, value);
    }
}
