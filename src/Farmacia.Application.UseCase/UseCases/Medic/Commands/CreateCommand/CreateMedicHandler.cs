using AutoMapper;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using Farmacia.Utilities.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.UseCases.Medic.Commands.CreateCommand
{
    public class CreateMedicHandler : IRequestHandler<CreateMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var Medic = _mapper.Map<Entity.Medic>(request);
                var parameters = Medic.GetPropertiesWithValues();

                response.Data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicRegister, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
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
