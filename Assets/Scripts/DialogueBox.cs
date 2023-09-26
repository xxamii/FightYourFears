using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Text _dialogueText;
    [SerializeField] private float _typingSpeed;
    [SerializeField] private float _sentenceWaitTime;

    private DialogueEntity _currentDialogue;
    private int _currentSentence;

    public static DialogueBox Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartDialogue(DialogueEntity dialogue)
    {
        _currentDialogue = dialogue;
        _dialogueText.text = string.Empty;
        _currentSentence = 0;

        StopAllCoroutines();
        StartCoroutine(DialogueRoutine());
    }

    private IEnumerator DialogueRoutine()
    {
        while (_currentSentence < _currentDialogue.Sentences.Length)
        {
            string sentence = _currentDialogue.Sentences[_currentSentence];

            StopCoroutine("SentenceRoutine");
            yield return StartCoroutine(SentenceRoutine(sentence));
            yield return new WaitForSeconds(_sentenceWaitTime);
            _dialogueText.text = string.Empty;

            _currentSentence++;
        }

        _currentDialogue = null;
    }

    private IEnumerator SentenceRoutine(string sentence)
    {
        foreach (char c in sentence)
        {
            _dialogueText.text += c;
            yield return new WaitForSeconds(_typingSpeed);
        }
    }    
}
