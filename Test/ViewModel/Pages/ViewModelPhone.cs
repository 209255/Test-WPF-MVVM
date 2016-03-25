using System.ComponentModel;
using Test.ViewModel.Pages.Base;

namespace Test.ViewModel.Pages
{
    public class ViewModelPhone:ViewModelPageBase
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private string _phone;       

		//=============================================================================

		internal override bool IsPageValid()
		{
			return true;
		}

		//=============================================================================
        public override string GetProperty
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
		public override string DisplayName
		{
			get
			{
			    const string namePage = "Phone";
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