namespace BordoProject.ViewModels
{
    public class TrainingViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bolum1 { get; set; }
        public string Bolum2 { get; set; }


        public string Bolum3 { get; set; }
        public string Bolum4 { get; set; }
        public string Day { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public float? TotalHours { get; set; }

        public bool NonWorkingDay { get; set; } = false;

        public Dictionary<string, Tuple<TimeSpan?, TimeSpan?>> Answer { get; set; } = new Dictionary<string, Tuple<TimeSpan?, TimeSpan?>>();

        public List<DayTimeViewModel> DayTimes { get; set; } = new List<DayTimeViewModel>();

        //public string Description { get; set; }
        //public double Hours { get; set; }

    }
}



    
