using System;
using Data;
using Model;

namespace Helpers
{
    public static class EventsManager
    {
        public static Action<ChallengeData> OpenChallengeAction = data => { };
        public static Action<ChallengeData> StartChallenge = data => { };
        public static Action<ChallengeData> FailChallenge = data => { };
        public static Action<ChallengeResultModel> FinshChallenge = data => { };
        
        public static Action ShowChallengesScreen = () => { };
    }
}