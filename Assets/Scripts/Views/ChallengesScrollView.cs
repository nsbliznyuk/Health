using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ChallengesScrollView : MonoBehaviour
    {
        [SerializeField]
        private GameObject challengeElement;

        private ScrollRect scrollRect;

        private void Awake()
        {
            scrollRect = GetComponent<ScrollRect>();
        }

        private void Start()
        {
            var loadedChallenges = Resources.LoadAll<ChallengeData>("Data/Challenges");

            foreach (var loadedChallenge in loadedChallenges)
            {
                if (loadedChallenge == null) continue;
                var spawnedGameObject = Instantiate(challengeElement, scrollRect.content);
                var challengeView = spawnedGameObject.GetComponent<ChallengeView>();
                challengeView.Initialize(loadedChallenge);
            }
        }
    }
}