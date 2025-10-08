using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class ProductRouter
    {

        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public ProductRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<Product> ComposeGetRoute()
        {
            return _requester.GetAllProducts();
        }

        public bool ComposePostRoute(Product value)
        {
            if (_validator.CheckProductIsValid(value))
                return _requester.AddProduct(value);

            return _invalidValueFlag;
        }

        public bool ComposePutRoute(Product value)
        {
            if (_validator.CheckProductIsValid(value))
                return _requester.EditProduct(value);

            return _invalidValueFlag;
        }

        public bool ComposeDeleteRoute(Product value)
        {
            if (_validator.CheckProductIsValid(value))
                return _requester.DeleteProduct(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}
