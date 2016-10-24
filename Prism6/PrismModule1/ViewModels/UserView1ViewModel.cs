using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace PrismModule1.ViewModels {
    public class UserView1ViewModel:BindableBase {
        private string _titel;
        public string Titel {
            get { return _titel; }
            set { SetProperty(ref _titel, value); }
        }
        public UserView1ViewModel() {
            Titel = "Titel von View1";
        }
    }
}
