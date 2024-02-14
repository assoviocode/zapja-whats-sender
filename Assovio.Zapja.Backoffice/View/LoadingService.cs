namespace Backoffice.View
{
    public class LoadingService
    {

        protected static Loading? loading;

        public static void LoadingShow()
        {
            if (loading == null)
                loading = new Loading();


            loading.Start();
        }

        public static void LoadingClose()
        {

            Thread.Sleep(1000);

            if (loading != null)
                loading.Stop();

            loading = null;
        }
    }
}
