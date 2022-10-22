using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CinematicHandler : MonoBehaviour
{
    [SerializeField] GameObject _subtitlesObject;
    [SerializeField] TextMeshProUGUI _subtitlesTxt;
    [SerializeField] private int _dialogueIndex = 0;

    [Header("DialogueLines")]
    [SerializeField] List<string> _texts = new List<string>();
    void Start()
    {
        _dialogueIndex = 0;
    }

    public void EnableSubtitles()
    {
        _subtitlesObject.SetActive(true);
        SetNextDialogueLine();
    }

    public void DisableSubtitles()
    {
        _subtitlesObject.SetActive(false);
        _dialogueIndex = 0;
    }
    public void SetNextDialogueLine()
    {
        _subtitlesTxt.text = _texts[_dialogueIndex];
        _dialogueIndex++;
        if (_dialogueIndex + 1 > _texts.Count)
        {
            DisableSubtitles();
        }
    }
}
