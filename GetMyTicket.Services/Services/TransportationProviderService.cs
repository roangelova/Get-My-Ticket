﻿using GetMyTicket.Common.DTOs.TP;
using GetMyTicket.Common.Entities;
using GetMyTicket.Persistance.UnitOfWork;
using GetMyTicket.Service.Contracts;

namespace GetMyTicket.Service.Services
{
    public class TransportationProviderService : ITransportationProviderService
    {
        private readonly IUnitOfWork unitOfWork;

        public TransportationProviderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<TransportationProvider> Add(CreateTransportationProviderDTO addTpDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(addTpDTO.Name) ||
                    string.IsNullOrWhiteSpace(addTpDTO.Description) ||
                    string.IsNullOrWhiteSpace(addTpDTO.Email) ||
                    string.IsNullOrWhiteSpace(addTpDTO.Address))
                {
                    throw new ArgumentException("A required field was empty.");
                }


                var entity = new TransportationProvider
                {
                    TransportationProviderId = Guid.CreateVersion7(),
                    Name = addTpDTO.Name.Trim(),
                    Description = addTpDTO.Description.Trim(),
                    Address = addTpDTO.Address.Trim(),
                    Email = addTpDTO.Email.Trim()
                };

                await unitOfWork.TransportationProviders.AddAsync(entity);
                await unitOfWork.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<GetTransportationProviderDTO>> GetAll()
        {
            try
            {
                var data = await unitOfWork.TransportationProviders.GetAllAsync();

                return data.Select(x => new GetTransportationProviderDTO(

                   x.TransportationProviderId.ToString(),
                     x.Name,
                    x.Description
                ));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetTransportationProviderDTO> GetById(object Id)
        {
          var entity = await unitOfWork.TransportationProviders.GetByIdAsync(Id);

            if (entity != null)
            {
                return new GetTransportationProviderDTO(
                    entity.TransportationProviderId.ToString(),
                    entity.Name,
                    entity.Description);
            }

            return null;
        }
    }
}
