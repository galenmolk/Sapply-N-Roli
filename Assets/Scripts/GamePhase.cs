using System;

namespace GGJ
{
    [Serializable]
    public class GamePhase
    {
        public int Threshold;
        public int Cap;

        public RequestData[] possibleRequests;
    }
}
