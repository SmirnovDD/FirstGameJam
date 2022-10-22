using UnityEngine;

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
    }
}