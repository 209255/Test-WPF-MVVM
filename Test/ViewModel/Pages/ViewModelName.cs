using System.ComponentModel;
using Test.ViewModel.Pages.Base;

namespace Test.ViewModel.Pages
{
   class ViewModelName:ViewModelPageBase
    {
        
        public new event PropertyChangedEventHandler PropertyChanged;
        private string _firstName;
	
		//=============================================================================

		internal override bool IsPageValid()
		{
			return true;
		}

		//=============================================================================
       public override string GetProperty
        {
           get { return _firstName; }
           set
           {
               _firstName = value;
               OnPropertyChanged("FirstName");
           }
        }

       public override string DisplayName
		{
			get
			{
			    const string namePage = "Name";
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
