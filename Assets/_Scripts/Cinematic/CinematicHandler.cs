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
    [SerializeField] List<AudioClip> _vOvers = new List<AudioClip>();
    [SerializeField] AudioSource _soundEmitter;
     void Start()
    {
        _dialogueIndex = 0;
    }

    private void PlayVoiceOver()
    {
        _soundEmitter.clip = _vOvers[_dialogueIndex];
        _soundEmitter.Play();
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
        if (_dialogueIndex == _texts.Count)
        {
            DisableSubtitles();
            return;
        }

        _subtitlesTxt.text = _texts[_dialogueIndex];
        PlayVoiceOver();
        _dialogueIndex++;
    }
}
