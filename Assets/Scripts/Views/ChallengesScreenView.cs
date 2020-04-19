using System;
using Data;
using Helpers;
using UnityEngine;

namespace Views
{
    public class ChallengesScreenView : MonoBehaviour
    {
        public CanvasControllerView canvasControllerView;

        private void Awake()
        {
            EventsManager.OpenChallengeAction += OpenChallengeAction;
            EventsManager.ShowChallengesScreen += ShowChallengesScreen;
        }

        private void ShowChallengesScreen()
        {
           canvasControllerView.Show();
        }

        private void OpenChallengeAction(ChallengeData challengeData)
        {
            canvasControllerView.Hide();
        }

        private void OnDestroy()
        {
            EventsManager.OpenChallengeAction -= OpenChallengeAction;
            EventsManager.ShowChallengesScreen -= ShowChallengesScreen;
        }
    }
}