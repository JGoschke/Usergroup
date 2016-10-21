using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism6.Views;
using System.Windows;

namespace Prism6 {
    class Bootstrapper : UnityBootstrapper {
        protected override DependencyObject CreateShell() {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell() {
            Application.Current.MainWindow.Show();
        }
    }
}
