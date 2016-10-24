using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace PrismModule1 {
    public class PrismModule1Module : IModule {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public PrismModule1Module(RegionManager regionManager, IUnityContainer container) {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize() {
            var vm = new ViewModels.DesignTimeView1ViewModel();
            _regionManager.RegisterViewWithRegion(Infrastructure.RegionNames.ContentRegion, typeof(Views.UserView1));
            
        }
    }
}