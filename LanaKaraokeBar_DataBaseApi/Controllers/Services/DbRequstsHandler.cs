using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Services
{
    public class DbRequstsHandler
    {
        #region Fields

        private static DbRequstsHandler _inst;
        private LanakaraokebarContext _context;

        #endregion

        #region Properties

        public static DbRequstsHandler Instance { get { return _inst ??= new(); } }

        #endregion

        #region Constructors

        public DbRequstsHandler()
        {
            _context = new();
        }

        #endregion

        #region Methods

        #region Authorize

        public string Authorize(string login, string password)
        {
            return "";
        }

        #endregion

        #endregion
    }
}
