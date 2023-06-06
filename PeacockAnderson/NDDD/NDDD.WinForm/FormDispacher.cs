namespace NDDD.WinForm
{
    internal class FormDispacher
    {
        public static ApplicationContext Context { get; } = new(new Views.LoginView());

        private static readonly Views.LatestView _form = new();
        public static void ShowLatest()
        {
            Context.MainForm = _form;
            _form.Show();
        }
    }
}
