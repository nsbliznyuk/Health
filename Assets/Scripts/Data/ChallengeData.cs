using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    [Serializable]
    public class ChallengeData : ScriptableObject
    {
        public string Title => title;

        public string Description => description;

        public float Duration => duration;

        [SerializeField]
        private string title;

        [SerializeField]
        private string description;

        [SerializeField]
        private float duration;
    }
}