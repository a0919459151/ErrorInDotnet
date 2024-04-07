using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Core.Helpers
{
    public class ToasterHelper
    {
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ToasterHelper(
            ITempDataDictionaryFactory tempDataDictionaryFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Success()
        {
            const string success = "成功";
            Success(success);
        }

        public void Success(string message)
        {
            var tempData = GetTempData();
            tempData["IsSucess"] = true;
            tempData["Message"] = message;
        }

        public void Error(List<string> messages)
        {
            var message = string.Join("<br>", messages);
            Error(message);
        }

        public void Error(string message)
        {
            var tempData = GetTempData();
            tempData["IsSucess"] = false;
            tempData["Message"] = message;
        }

        public (bool, string?) GetModelValidatorResult()
        {
            var tempData = GetTempData();
            var isSuccess = tempData["IsSucess"] as bool? ?? false;
            var message = tempData["Message"] as string;
            return (isSuccess, message);
        }

        private ITempDataDictionary GetTempData()
        {
            return _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);
        }
    }
}

