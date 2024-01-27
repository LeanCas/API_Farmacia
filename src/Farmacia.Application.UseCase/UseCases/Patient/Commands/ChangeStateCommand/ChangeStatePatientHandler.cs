using AutoMapper;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using Farmacia.Utilities.HelperExtensions;
using MediatR;
using Entity = Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand
{
    public class ChangeStatePatientHandler : IRequestHandler<ChangeStatePatientCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStatePatientCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var patient = _mapper.Map<Entity.Patient>(request);
                var parameters = patient.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Patient.ExecAsync(SP.uspPatientChangeState, parameters);


                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Cambio de estado exitoso";
                }


            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;        }
    }
}
