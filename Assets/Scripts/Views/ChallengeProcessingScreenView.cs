using System;
using Data;
using Helpers;
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

        private ChallengeData currentChallengeData;
        private bool timerIsRunning = false;
        private float currentTime = 0f;
        
        private void Awake()
        {
            EventsManager.StartChallenge += StartChallengeAction;
        }

        private void StartChallengeAction(ChallengeData challengeData)
        {
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

        private void Update()
        {
            if(!timerIsRunning) return;
            currentTime -= Time.deltaTime;

            timerText.text = TimeSpan.FromSeconds(currentTime).ToString(@"mm\:ss");

            timerRadialImage.fillAmount = Mathf.InverseLerp(0, currentChallengeData.Duration, currentTime);
            
            Debug.Log("Таймер: " + currentTime);
            
            if (currentTime <= 0f)
            {
                timerIsRunning = false;
                Debug.Log("Таймер остановлен!");
            }

        }

        private void OnDestroy()
        {
            EventsManager.StartChallenge -= StartChallengeAction;
        }
    }
}