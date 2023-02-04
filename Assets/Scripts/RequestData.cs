using System;

namespace GGJ 
{
    [Serializable]
    public class RequestData
    {
        public int Water;
        public int Sunlight;

        public RequestData(int water, int sunlight)
        {
            Water = water;
            Sunlight = sunlight;
        }
    }
}
