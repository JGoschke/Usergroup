using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism6.Views;
using System.Windows;
using Prism.Modularity;

namespace Prism6 {
    class Bootstrapper : UnityBootstrapper {
        protected override DependencyObject CreateShell() {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell() {
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureModuleCatalog() {
            base.ConfigureModuleCatalog();
            var mc = new DirectoryModuleCatalog();
            mc.ModulePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Module");
            ModuleCatalog = mc;
        }
    }
}
