using Data;

namespace Model
{
    public class ChallengeResultModel
    {
        public ChallengeResultModel(ChallengeData challengeData, float timeLeft)
        {
            this.challengeData = challengeData;
            this.timeLeft = timeLeft;
        }

        public ChallengeData ChallengeData => challengeData;
        public float TimeLeft => timeLeft;

        private ChallengeData challengeData;
        private float timeLeft;
        
    }
}