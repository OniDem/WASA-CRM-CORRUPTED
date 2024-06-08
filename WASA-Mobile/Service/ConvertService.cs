using Core.Const;
using System.Collections.ObjectModel;

namespace WASA_Mobile.Service
{
    public static class ConvertService
    {
        public static string CategoryToString(CategoryEnum category)
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

        public static CategoryEnum StringToCategory(string category)
        {
            switch (category)
            {
                case "Защита экрана":
                    return CategoryEnum.ScreenProtect;
                case "Провода":
                    return CategoryEnum.Cable;
                case "Наушники":
                    return CategoryEnum.Headphones;
                default:
                    return CategoryEnum.Another;
            }
        }

    }
}
