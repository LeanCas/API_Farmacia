using AutoMapper;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;
using Farmacia.Utilities.Constants;
using Farmacia.Utilities.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.UseCases.Medic.Commands.DeleteCommand
{
    public class DeleteMedicHandler : IRequestHandler<DeleteMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse <bool>();

            try
            {
                var medic = _mapper.Map<Entity.Medic>(request);
                var parameters = medic.GetPropertiesWithValues();

                response.Data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicDelete, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa";
                    return response;
                }

            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
