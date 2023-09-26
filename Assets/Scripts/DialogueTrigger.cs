using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueEntity _dialogue;

    private DialogueBox _dialogueBox;

    private void Start()
    {
        _dialogueBox = DialogueBox.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>())
        {
            _dialogueBox.StartDialogue(_dialogue);
            Destroy(gameObject);
        }
    }
}
