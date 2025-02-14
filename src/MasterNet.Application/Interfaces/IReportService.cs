using MasterNet.Domain;

namespace MasterNet.Application.Interface;


public interface IReportService<T> where T : BaseEntity
{
    Task<MemoryStream> GetCsvReport(List<T> records);
}