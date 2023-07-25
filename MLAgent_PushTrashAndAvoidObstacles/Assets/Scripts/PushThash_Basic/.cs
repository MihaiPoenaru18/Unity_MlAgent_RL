namespace Assets.Scripts.PushThash_Basic
{
    internal class RaportCSVModel
    {
        public int Eppisod { get; set; }
        
        public int NumberCollisionTrashObstacles { get; set; }

        public int NumberCollisionAgentObstacles { get; set; }

        public int NumberOfStepForFinish { get; set; }

        public bool ShortStepCount { get; set; }

        public bool FinishEpisod { get; set; }

        public bool ShortRoad { get; set; }

    }
}
