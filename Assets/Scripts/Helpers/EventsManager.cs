using System;
using Data;

namespace Helpers
{
    public static class EventsManager
    {
        public static Action<ChallengeData> OpenChallengeAction = data => { };
        public static Action<ChallengeData> StartChallenge = data => { };
    }
}