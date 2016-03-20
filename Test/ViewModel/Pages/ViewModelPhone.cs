using System.ComponentModel;
using Test.ViewModel.Pages.Base;

namespace Test.ViewModel.Pages
{
    public class ViewModelPhone:ViewModelPageBase
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private string _phone;
		public string Phone
		{
			get
			{
				return _phone;
			}
			set
			{
			    _phone = value;
				OnPropertyChanged("Phone");
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
			    const string namePage = "Phone Page";
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