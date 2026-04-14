using System.Collections.Specialized;

namespace Meetzy.Application.Contracts.Repositories
{
    internal interface ISectionsRepository
    {
        Task UpdateAsync(BitVector32.Section? section);
    }
}