namespace TPL.RabbitMQ.Sub.Domain.Extensions
{
    public static class CommonExtensions
    {
        private static bool DiaEHoraValido (DateTime date) => !FinalDeSemana(date) && HorarioComercial(date.TimeOfDay);
        private static bool FinalDeSemana(DateTime date) => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        private static bool HorarioComercial(TimeSpan time) => time > new TimeSpan(7,59,59) && time < new TimeSpan(22,0,1);
    }
}
