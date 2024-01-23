using AutoMapper;
using Farmacia.Application.Dtos.Exam.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using MediatR;

namespace Farmacia.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamHandler : IRequestHandler<GetAllExamQuery, BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllExamResponseDto>>();

            try
            {
                var Exams = await _unitOfWork.Exams.GetAllExams(SP.uspExamList);

                if(Exams is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllExamResponseDto>>(Exams);
                    response.Message = "Consulta exitosa";
                }



            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
