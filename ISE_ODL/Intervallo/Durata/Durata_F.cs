namespace ISE_ODL.Intervallo.Durata
{
    public static class Durata_F
    {
        public static Durata_VM Create(DateOnly data, TimeSpan ore) => new() { Data = data, Ore = ore };
    }
}
