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

namespace Farmacia.Application.UseCase.UseCases.Medic.Commands.UpdateCommand
{
    public class UpdateMedicHandler : IRequestHandler<UpdateMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var medic = _mapper.Map<Entity.Medic>(request);
                var parameters = medic.GetPropertiesWithValues();

                response.Data = await _unitOfWork.Medic.ExecAsync(SP.uspMedicEdit, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Modificado con exito";
                }
                
            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
