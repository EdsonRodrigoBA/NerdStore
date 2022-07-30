using NerdStore.Core.Messages;
using System.Threading.Tasks;

namespace NerdStore.Core.Buss
{
    public interface IMediatrHandle
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
