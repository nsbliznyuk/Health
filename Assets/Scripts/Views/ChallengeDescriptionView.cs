using System;
using Data;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ChallengeDescriptionView : MonoBehaviour
    {
        public ChallengeView challengeView;
        public CanvasControllerView canvasControllerView;
        public Image challengeDecriptionImage;
        
        
        
        private ChallengeData currentChallengeData;
        
        private void Awake()
        {
            EventsManager.OpenChallengeAction += OpenChallengeAction;
        }

        private void OpenChallengeAction(ChallengeData challengeData)
        {
            currentChallengeData = challengeData;
            challengeDecriptionImage.sprite = challengeData.DescriptionIcon;
            challengeView.Initialize(challengeData);
            canvasControllerView.Show();
        }

        public void StartChallenge()
        {
            canvasControllerView.Hide();
            EventsManager.StartChallenge.Invoke(currentChallengeData);
        }

        private void OnDestroy()
        {
            EventsManager.OpenChallengeAction -= OpenChallengeAction;
        }
    }
}