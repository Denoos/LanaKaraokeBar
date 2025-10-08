using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class PaymentTypeRouter
    {
        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public PaymentTypeRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<Paymenttype> ComposeGetRoute()
        {
            return _requester.GetAllPaymentTypes();
        }

        public bool ComposePostRoute(Paymenttype value)
        {
            if (_validator.CheckPaymentTypeIsValid(value))
                return _requester.AddPaymentType(value);

            return _invalidValueFlag;
        }

        public bool ComposePutRoute(Paymenttype value)
        {
            if (_validator.CheckPaymentTypeIsValid(value))
                return _requester.EditPaymentType(value);

            return _invalidValueFlag;
        }

        public bool ComposeDeleteRoute(Paymenttype value)
        {
            if (_validator.CheckPaymentTypeIsValid(value))
                return _requester.DeletePaymentType(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}
