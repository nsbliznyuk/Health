using Data;
using Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ChallengeView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI titleText;

        [SerializeField]
        private Image iconImage;

        private ChallengeData currentChallengeData;

        public void Initialize(ChallengeData challengeData)
        {
            titleText.text = challengeData.Title;
            iconImage.sprite = challengeData.Icon;
            currentChallengeData = challengeData;
        }

        public void OpenChallenge()
        {
            EventsManager.OpenChallengeAction.Invoke(currentChallengeData);
            Debug.Log("Open Challenge: " + currentChallengeData.name);
        }
    }
}