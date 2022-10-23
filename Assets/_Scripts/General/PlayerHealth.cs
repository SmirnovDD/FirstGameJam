using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.General
{
    public class PlayerHealth : Health
    {
        [SerializeField] private float _healPerSecond;
        
        private void Update()
        {
            Current += _healPerSecond * Time.deltaTime;
            Current = Mathf.Min(Current, _initial);
        }

        private void OnDestroy()
        {
            SceneManager.LoadScene(1);
        }
    }
}