using System.Collections.Generic;
using _Scripts.General;
using StarterAssets;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerAmmunitionController : MonoBehaviour
    {
        [SerializeField] private List<PlayerAmmunition> _ammunition = new List<PlayerAmmunition>();
        public PlayerAmmunition ChosenAmmunition { get; private set; }

        private WeaponSwitcher _weaponSwitcher;
        private StarterAssetsInputs _inputs;
        private float _cooldownOnChange = .5f;
        private float _timer;
        
        private void Awake()
        {
            ChosenAmmunition = _ammunition[1];
            _weaponSwitcher = GetComponent<WeaponSwitcher>();
            _inputs = GetComponent<StarterAssetsInputs>();
        }

        private void Update()
        {
            if (_inputs.ChangeAmmunition && _timer <= 0)
            {
                ChangeAmmunition();
                _timer = _cooldownOnChange;
            }

            _timer -= Time.deltaTime;
        }

        private void ChangeAmmunition()
        {
            var currentAmmunitionIndex = _ammunition.IndexOf(ChosenAmmunition);
            currentAmmunitionIndex++;
            if (currentAmmunitionIndex == _ammunition.Count)
                currentAmmunitionIndex = 0;
            ChosenAmmunition = _ammunition[currentAmmunitionIndex];

            SwitchWeaponModel();
        }

        private void SwitchWeaponModel()
        {
            switch (ChosenAmmunition.Type)
            {
                case AmmunitionType.Crossbow:
                    _weaponSwitcher.SwitchToRanged();
                    break;
                case AmmunitionType.Axe:
                    _weaponSwitcher.SwitchToMelee();
                    break;
            }
        }
    }
}