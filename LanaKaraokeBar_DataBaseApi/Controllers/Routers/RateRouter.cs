using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class RateRouter
    {

        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public RateRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<Rate> ComposeGetRoute()
        {
            return _requester.GetAllRates();
        }

        public bool ComposePostRoute(Rate value)
        {
            if (_validator.CheckRateIsValid(value))
                return _requester.AddRate(value);

            return _invalidValueFlag;
        }

        public bool ComposePutRoute(Rate value)
        {
            if (_validator.CheckRateIsValid(value))
                return _requester.EditRate(value);

            return _invalidValueFlag;
        }

        public bool ComposeDeleteRoute(Rate value)
        {
            if (_validator.CheckRateIsValid(value))
                return _requester.DeleteRate(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}
