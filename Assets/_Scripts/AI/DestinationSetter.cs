using System;
using _Scripts.General;
using UnityEngine;

namespace _Scripts.AI
{
    public class DestinationSetter : MonoBehaviour
    {
        private UnityEngine.AI.NavMeshAgent _agent;
        private Transform _destination;
        private bool _initialized;
        private AnimationsController _animationsController;

        private void Awake()
        {
            _animationsController = GetComponent<AnimationsController>();
        }

        public void Init(Transform destination)
        {
            _destination = destination;
            _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            _agent.destination = destination.position;
            _initialized = true;
        }

        private void FixedUpdate()
        {
            if (_initialized && _destination != null)
                _agent.destination = _destination.position;
        }

        private void Update()
        {
            if (_agent.velocity.sqrMagnitude > 0)
                _animationsController.PlayRunAnimation();
            else
                _animationsController.PlayIdleAnimation();
        }
    }
}
