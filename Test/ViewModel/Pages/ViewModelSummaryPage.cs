using System.Collections.Generic;
using System.ComponentModel;
using Test.ViewModel.Pages.Base;
namespace Test.ViewModel.Pages
{
    class ViewModelSummaryPage:ViewModelPageBase
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private readonly List<ViewModelPageBase> _pages;
        private string _data;
        public ViewModelSummaryPage(List<ViewModelPageBase> pages)
        {
            _pages = pages;
        }
        internal override bool IsPageValid()
		{
			return true;
		}


        private void GetData()
        {
           string temp = null;
            for (int i = 1; i < _pages.Count-1; ++i)
            {
              temp+= _pages[i].DisplayName + ":" + _pages[i].GetProperty + "\n";
            }
            _data = temp;
            OnPropertyChanged("Summary");
        }

        public override string DisplayName
		{
			get
			{
				string helloString1 = "Summary";
                return helloString1;
			}
		}

        public override string GetProperty
        {
            get { GetData(); return _data; }
            set
            {
                _data = value;
            
            }
        }
        protected override void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
 }

