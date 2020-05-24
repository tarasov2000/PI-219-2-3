using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IStatisticsService
    {
        Statistic GetProductStatistic(int Id);
        Statistic GetStatAllOrder();
        int GetCancelOrder();
    }
}
