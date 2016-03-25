using System.ComponentModel;
using Test.ViewModel.Pages.Base;

namespace Test.ViewModel.Pages
{
    class ViewModelSurname:ViewModelPageBase

    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private string _surnName;

  		//=============================================================================

		internal override bool IsPageValid()
		{
			return true;
		}

		//=============================================================================
        public override string GetProperty
        {
            get { return _surnName; }
            set
            {
                _surnName = value;
                OnPropertyChanged("Surname");
            }
        }
		public override string DisplayName
		{
			get
			{
			    const string namePage = "Surname";
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

