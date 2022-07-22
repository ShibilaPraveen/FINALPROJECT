using apiifinal.Data;
using apiifinal.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiifinal.Repository
{
    public class PortRepository : IPortRepository
    {
        private readonly PortDbContext _Context;
        private readonly IMapper mapper;
        public PortRepository(PortDbContext context, IMapper mapper)
        {
            this._Context = context;
            this.mapper = mapper;
        }
        public async Task UpdateSlot(int slotId, PortSlot slotsModel)
        {
            var slot = await _Context.Pslots.FindAsync(slotId);
            if (slot != null)
            {
                slot.RUID = slotsModel.RUID;
                slot.status = 0;
                slot.cost = slot.cost + slotsModel.cost;
                slot.Sdate = slotsModel.Sdate;
                slot.Edate = slotsModel.Edate;
                await _Context.SaveChangesAsync();
            }
        }
        public async Task<List<PortSlot>> GetAvalSlotsAsync()
        {
            var records = await _Context.Pslots.Where(x => x.status == 1).Select(x => new PortSlot()
            {
                SlotId = x.SlotId,
                SLUserID=x.SLUserID,
                status = x.status
            }).ToListAsync();
            return records;
        }
        public async Task<PortUser> AddUserAsync(PortUser usersModel)
        {
            if (usersModel.usertype =="SL")
               {
                var user = new PortUsers()
                {               
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    usertype = usersModel.usertype,
                    StartDate = usersModel.StartDate,
                    EndDate = usersModel.EndDate,
                    cost = usersModel.cost,
                    
                };
                _Context.Pusers.Add(user);
                await _Context.SaveChangesAsync();
                var slot = new PortSlots
                {
                    status = 1,
                    SLUserID = user.ID,
                    RUID = 0
                };
                _Context.Pslots.Add(slot);
                await _Context.SaveChangesAsync();
                return mapper.Map<PortUser>(user);
            }
              else
            {
                var user = new PortUsers()
                {
                    ID = usersModel.ID,
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    usertype = usersModel.usertype,
                };
                _Context.Pusers.Add(user);
                await _Context.SaveChangesAsync();
                return mapper.Map<PortUser> (user);
            };
        }
    }
}

