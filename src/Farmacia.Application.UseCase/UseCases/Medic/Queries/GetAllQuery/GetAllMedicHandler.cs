using Farmacia.Application.Dtos.Medic.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    public class GetAllMedicHandler : IRequestHandler<GetAllMedicQuery, BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMedicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllMedicResponseDto>>();

            try
            {
                var medics = await _unitOfWork.Medic.GetAllMedics(SP.uspMedicList);

                if(medics is not null)
                {
                    response.IsSuccess = true;
                    response.Data = medics;
                    response.Message = "Consulta exitosa";
                }
                
            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
