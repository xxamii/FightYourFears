using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueEntity", menuName = "DialogueEntity")]
public class DialogueEntity : ScriptableObject
{
    [SerializeField] private string[] _sentences;

    public string[] Sentences => _sentences;
}
