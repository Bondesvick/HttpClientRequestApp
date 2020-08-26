using System.Windows;
using Data;

namespace MainUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUsersData usersData = Injector.Inject();
            //await usersData.GetNames(@"https://jsonmock.hackerrank.com/api/article_users/search?page=");
            MainWindow mw = new MainWindow(Injector.Inject());
            mw.Show();
        }
    }
}