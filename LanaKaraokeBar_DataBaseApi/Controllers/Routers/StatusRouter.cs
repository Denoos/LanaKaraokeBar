using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class StatusRouter
    {
        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public StatusRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<Status> ComposeGetStatusRoute()
        {
            return _requester.GetAllStatuses();
        }

        public bool ComposePostStatusRoute(Status value)
        {
            if (_validator.CheckStatusIsValid(value))
                return _requester.AddStatus(value);

            return _invalidValueFlag;
        }

        public bool ComposePutStatusRoute(Status value)
        {
            if (_validator.CheckStatusIsValid(value))
                return _requester.EditStatus(value);

            return _invalidValueFlag;
        }

        public bool ComposeDeleteStatusRoute(Status value)
        {
            if (_validator.CheckStatusIsValid(value))
                return _requester.DeleteStatus(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}
