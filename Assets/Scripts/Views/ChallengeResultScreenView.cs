using System;
using Data;
using Helpers;
using Model;
using TMPro;
using UnityEngine;

namespace Views
{
    public class ChallengeResultScreenView : MonoBehaviour
    {
        public CanvasControllerView canvasControllerView;
        public TextMeshProUGUI resultText;

        private void Awake()
        {
            EventsManager.FinshChallenge += FinishChallengeAction;
        }

        private void FinishChallengeAction(ChallengeResultModel challengeResultModel)
        {
            resultText.text = $"Time Left: {TimeSpan.FromSeconds(challengeResultModel.TimeLeft):mm\\:ss}";
            canvasControllerView.Show();
            
        }

        public void ContinueToChallengesScreen()
        {
            canvasControllerView.Hide();
            EventsManager.ShowChallengesScreen.Invoke();
        }

        private void OnDestroy()
        {
            EventsManager.FinshChallenge -= FinishChallengeAction;
        }
    }
}