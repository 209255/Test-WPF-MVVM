using System.ComponentModel;
using Test.ViewModel.Pages.Base;

namespace Test.ViewModel.Pages
{
    class ViewModelSurname:ViewModelPageBase

    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private string _surnName;
		public string SurnameName
		{
			get
			{
				return _surnName;
			}
			set
			{
			    _surnName = value;
				OnPropertyChanged("FirstName");
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
			    const string namePage = "Surname Page";
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

