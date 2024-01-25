using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Utilities.Constants
{
    public class SP
    {
        #region uspAnalysis
        public const string uspAnalysisChangeState = "uspAnalysisChangeState";
        public const string uspAnalysisRegister = "uspAnalysisRegister";
        public const string uspAnalysisDelete = "uspAnalysisDelete";
        public const string uspAnalysisEdit = "uspAnalysisEdit";
        public const string uspAnalysisList = "uspAnalysisList";
        public const string uspAnalysisById = "uspAnalysisById";
        #endregion

        #region uspExams

        public const string uspExamList = "uspExamList";
        public const string uspExamById = "uspExamById";
        public const string uspExamRegister = "uspExamRegister";
        public const string uspExamEdit = "uspExamEdit";
        public const string uspExamDelete = "uspExamDelete";
        public const string uspExamChangeState = "uspExamChangeState";

        #endregion

        #region uspPatient
        public const string uspPatientList = "uspPatientList";
        public const string uspPatientById = "uspPatientById";
        public const string uspPatientRegister = "uspPatientRegister";
        public const string uspPatientEdit = "uspPatientEdit";
        public const string uspPatientDelete = "uspPatientDelete";
        #endregion

    }
}
