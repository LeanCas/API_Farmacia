using Farmacia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.Interface
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> ListAnalysis();

        Task<Analysis> AnalysisPorID(int analysisId);

        Task<bool> AnalysisRegister(Analysis analysis); 

        Task<bool> AnalysisEdit(Analysis analysis);
    }
}
