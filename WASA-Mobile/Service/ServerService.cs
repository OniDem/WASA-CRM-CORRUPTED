using System.Net;

namespace WASA_Mobile.Service
{
    public static class ServerService
    {
        public static string? ResponseCodeToString(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {

                case HttpStatusCode.OK:
                    return "Успешно";
                case HttpStatusCode.NoContent:
                    return "Пустой ответ";
                case HttpStatusCode.BadRequest:
                    return "Плохой запрос";
                case HttpStatusCode.Unauthorized:
                    return "Требуется авторизация";
                case HttpStatusCode.Forbidden:
                    return "Перенаправлен";
                case HttpStatusCode.NotFound:
                    return "Адрес не найден";
                case HttpStatusCode.MethodNotAllowed:
                    return "Запрос не разрешён";
                case HttpStatusCode.RequestTimeout:
                    return "Истекло время запроса";
                case HttpStatusCode.UnsupportedMediaType:
                    return "Не поддерживаемый тип данных";
                case HttpStatusCode.InternalServerError:
                    return "Критическая ошибка на сервере";
                case HttpStatusCode.NotImplemented:
                    return "Запроса не объявлен";
                case HttpStatusCode.BadGateway:
                    return "Запрос не достиг сервера";
                case HttpStatusCode.ServiceUnavailable:
                    return "Сервер временно не доступен";
                case HttpStatusCode.GatewayTimeout:
                    return "Истекло время ответа от сервера";
                case HttpStatusCode.HttpVersionNotSupported:
                    return "Не верная версия протокола HTTP";
                case HttpStatusCode.LoopDetected:
                    return "На сервере обнаружен вечный цикл";
                    default:
                    return null;
            }
        }
    }
}
