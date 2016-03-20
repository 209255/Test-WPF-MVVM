using System.Threading;
using System.ComponentModel;
using Test.ViewModel.Pages.Base;

namespace Test.ViewModel.Pages
{
   class ViewModelName:ViewModelPageBase
    {
       public ViewModelName()
       { }
        public new event PropertyChangedEventHandler PropertyChanged;
        private string _firstName;
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
			    _firstName = value;
			    
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
			    const string namePage = "Name Page";
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
