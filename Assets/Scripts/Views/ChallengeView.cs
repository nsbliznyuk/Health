using Data;
using Helpers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class ChallengeView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI titleText;

        private ChallengeData currentChallengeData;

        public void Initialize(ChallengeData challengeData)
        {
            titleText.text = challengeData.Title;
            currentChallengeData = challengeData;
        }

        public void OpenChallenge()
        {
            EventsManager.OpenChallengeAction.Invoke(currentChallengeData);
            Debug.Log("Open Challenge: " + currentChallengeData.name);
        }
    }
}