using System;
using Data;
using Helpers;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ChallengeProcessingScreenView : MonoBehaviour
    {
        public ChallengeView challengeView;
        public CanvasControllerView canvasControllerView;
        public TextMeshProUGUI timerText;
        public Image timerRadialImage;

        public GameObject restartButton;
        public GameObject finishButton;

        public Color startColor;
        public Color endColor;
        
        private ChallengeData currentChallengeData;
        private bool timerIsRunning = false;
        private float currentTime = 0f;

        private void Awake()
        {
            EventsManager.StartChallenge += StartChallengeAction;
        }

        private void StartChallengeAction(ChallengeData challengeData)
        {
            restartButton.SetActive(false);
            finishButton.SetActive(true);
            currentChallengeData = challengeData;
            challengeView.Initialize(challengeData);
            canvasControllerView.Show();
            StartTimer(challengeData.Duration);
        }

        private void StartTimer(float duration)
        {
            currentTime = duration;
            timerIsRunning = true;
            Debug.Log("Старт таймера на: " + duration);
        }

        public void StopTimer()
        {
            timerIsRunning = false;
        }

        private void Update()
        {
            if (!timerIsRunning) return;
            currentTime -= Time.deltaTime;

            timerText.text = TimeSpan.FromSeconds(currentTime).ToString(@"mm\:ss");

            var t = Mathf.InverseLerp(0, currentChallengeData.Duration, currentTime);


            timerRadialImage.fillAmount = t;

            timerRadialImage.color = Color.Lerp(endColor, startColor, t);

            Debug.Log("Таймер: " + currentTime);

            if (currentTime <= 0f)
            {
                timerIsRunning = false;
                failChallenge();
                Debug.Log("Таймер остановлен!");
            }
        }

        public void FinishChallenge()
        {
            StopTimer();
            canvasControllerView.Hide();
            var result = new ChallengeResultModel(currentChallengeData, currentTime);
            EventsManager.FinshChallenge.Invoke(result);
        }

        public void RestartChallenge()
        {
            EventsManager.StartChallenge.Invoke(currentChallengeData);
        }

        private void failChallenge()
        {
            finishButton.SetActive(false);
            restartButton.SetActive(true);
            EventsManager.FailChallenge.Invoke(currentChallengeData);
        }

        private void OnDestroy()
        {
            EventsManager.StartChallenge -= StartChallengeAction;
        }
    }
}