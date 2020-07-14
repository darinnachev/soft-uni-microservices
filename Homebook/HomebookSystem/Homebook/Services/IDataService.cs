using System.Threading.Tasks;
using Homebook.Data.Models;

namespace Homebook.Services
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task MarkMessageAsPublished(int id);

        Task Save(TEntity entity, params Message[] messages);
    }
}
