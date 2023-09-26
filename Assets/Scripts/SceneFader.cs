using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        _animator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        _animator.SetTrigger("FadeOut");
    }

    public void LoadLevel()
    {
        SceneTransitions.Instance.LoadCurrent();
    }
}
