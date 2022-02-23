using System.Threading.Tasks;
using TaxJarClient.Models;

namespace TaxJarClient.Services
{
    public interface ITaxService
    {
        Task<OrderTaxRes> GetOrderTaxAsync(OrderTaxReq order);
        Task<RateRes> GetRateAsync(RateReq rate);
    }
}