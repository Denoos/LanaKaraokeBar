using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class GenreRouter
    {
        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public GenreRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<Genre> ComposeGetRoute()
        {
            return _requester.GetAllGenres();
        }

        public bool ComposePostRoute(Genre value)
        {
            if (_validator.CheckGenreIsValid(value))
                return _requester.AddGenre(value);

            return _invalidValueFlag;
        }

        public bool ComposePutRoute(Genre value)
        {
            if (_validator.CheckGenreIsValid(value))
                return _requester.EditGenre(value);

            return _invalidValueFlag;
        }

        public bool ComposeDeleteRoute(Genre value)
        {
            if (_validator.CheckGenreIsValid(value))
                return _requester.DeleteGenre(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}
