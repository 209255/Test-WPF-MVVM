using System.ComponentModel;
using Test.ViewModel.Pages.Base;

namespace Test.ViewModel.Pages
{
    class ViewModelAdress:ViewModelPageBase
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private string _adress;
        public string Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
                OnPropertyChanged("Adress");
            }
        }
      

        //=============================================================================

        internal override bool IsPageValid()
        {
            return true;
        }

        //=============================================================================

        public override string DisplayName
        {
            get
            {
                const string namePage = "Adress Page";
                return namePage;
            }
        }
        protected override void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
