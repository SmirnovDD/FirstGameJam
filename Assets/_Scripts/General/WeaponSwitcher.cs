using UnityEngine;

namespace _Scripts.General
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _melee;
        [SerializeField] private GameObject _ranged;

        public void SwitchToMelee()
        {
            _melee.SetActive(true);
            _ranged.SetActive(false);
        }

        public void SwitchToRanged()
        {
            _melee.SetActive(false);
            _ranged.SetActive(true);
        }
    }
}