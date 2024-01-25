using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using MediatR;

namespace Farmacia.Application.UseCase.UseCases.Patient.Commands.DeleteCommand
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response.Data = await _unitOfWork.Patient.ExecAsync(SP.uspPatientDelete, request);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa";
                }
                
            }catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
    }
}
