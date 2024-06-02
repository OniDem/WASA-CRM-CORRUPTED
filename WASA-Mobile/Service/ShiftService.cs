using Core.Const;

namespace WASA_Mobile.Service
{
    public static class ShiftService
    {
        public static bool ShiftOpen()
        {

            if (Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.ShiftOpen)).Result == "Open")
                return true;
            else
                return false;
        }

        public async static Task<bool> Open()
        {
            //Some code to call api methods
            await SecureStorage.SetAsync(SecureStoragePathConst.ShiftOpen, "Open");
            return true;
        }

        public static bool Close()
        {
            //Some code to call api methods
            SecureStorage.Remove(SecureStoragePathConst.ShiftOpen);
            return true;
        }
    }
}
