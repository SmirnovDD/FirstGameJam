using System;
using UnityEngine;

namespace _Scripts.Player
{
    [Serializable]
    public class PlayerAmmunition
    {
        [SerializeField] private GameObject _model;
        public GameObject Model => _model;
        [SerializeField] private AmmunitionType _type;
        public AmmunitionType Type => _type;
    }
}