namespace BordoProject.ViewModels
{
    public class DayTimeViewModel
    {

        public string Day { get; set; } // Gün adı (örneğin: Pazartesi, Salı, vs.)
        public TimeSpan? StartTime { get; set; } // Başlangıç saati
        public TimeSpan? EndTime { get; set; } // Bitiş saati
    }
}
