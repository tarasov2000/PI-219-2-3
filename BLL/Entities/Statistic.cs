namespace BLL.Entities
{
    public class Statistic
    {
        public double Money { get; set; }
        public int Count { get; set; }

        public Statistic()
        {
            Money = 0;
            Count = 0;
        }
    }
}
