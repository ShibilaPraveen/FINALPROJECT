using apiifinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiifinal.Repository
{
    public interface IPortRepository
    {
        Task<List<PortSlot>> GetAvalSlotsAsync();
        Task<PortUser> AddUserAsync(PortUser usersModel);
        Task UpdateSlot(int slotId, PortSlot slotsModel);
    }
}
