using UnityEngine;

public class FireballFlight : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position += _transform.forward * (Time.deltaTime * _speed);
    }
}
