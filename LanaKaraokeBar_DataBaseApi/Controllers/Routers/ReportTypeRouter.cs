using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class ReportTypeRouter
    {
        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public ReportTypeRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<Reporttype> ComposeGetRoute()
        {
            return _requester.GetAllReportTypes();
        }

        public bool ComposePostRoute(Reporttype value)
        {
            if (_validator.CheckReportTypeIsValid(value))
                return _requester.AddReportType(value);

            return _invalidValueFlag;
        }

        public bool ComposePutRoute(Reporttype value)
        {
            if (_validator.CheckReportTypeIsValid(value))
                return _requester.EditReportType(value);

            return _invalidValueFlag;
        }

        public bool ComposeDeleteRoute(Reporttype value)
        {
            if (_validator.CheckReportTypeIsValid(value))
                return _requester.DeleteReportType(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}
