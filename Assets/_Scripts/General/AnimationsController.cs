using UnityEngine;

namespace _Scripts.General
{
    public class AnimationsController : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Melee = Animator.StringToHash("Melee");
        private static readonly int Shoot = Animator.StringToHash("Shoot");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Hit = Animator.StringToHash("Hit");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void PlayRunAnimation()
        {
            _animator.SetBool(Run, true);
        }
    
        public void PlayIdleAnimation()
        {
            _animator.SetBool(Run, false);
        }
    
        public void PlayMeleeAttackAnimation()
        {
            _animator.SetTrigger(Melee);
        }
    
        public void PlayShootAnimation()
        {
            _animator.SetTrigger(Shoot);
        }

        public void PlayHitAnimation()
        {
            _animator.SetTrigger(Hit);
        }
    }
}
