using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSoundHandler : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _meleeAttacks = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _crossbowAttacks = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _running = new List<AudioClip>();
    [SerializeField] private AudioSource _animationSource;
    [SerializeField] private AudioSource _playerSource;

    public void PlayCrossbowSound()
    {
        _animationSource.clip = _crossbowAttacks[Random.Range(0, _crossbowAttacks.Count)];
        _animationSource.Play();
    }

    public void PlayMeleeSound()
    {
        _animationSource.clip = _meleeAttacks[Random.Range(0, _meleeAttacks.Count)];
        _animationSource.Play();
    }

    public void PlayRunningSounds()
    {
        _playerSource.clip = _running[Random.Range(0, _running.Count)];
        _animationSource.Play();
    }
}
