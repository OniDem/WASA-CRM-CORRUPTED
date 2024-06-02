using Core.Const;

namespace WASA_Mobile.Service
{
    public static class ConvertService
    {
        public static string CategoryConvertToString(CategoryEnum category)
        {
            switch (category)
            {
                case CategoryEnum.ScreenProtect:
                    return "Защита экрана";
                case CategoryEnum.Cable:
                    return "Провода";
                case CategoryEnum.Headphones:
                    return "Наушники";
                case CategoryEnum.Another:
                    return "Другое";
                default:
                    return "";
            }
            
        }
    }
}
