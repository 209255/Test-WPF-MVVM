using System.ComponentModel;

namespace Test.ViewModel.Pages.Base
{
    public abstract class ViewModelPageBase:INotifyPropertyChanged
    {
         bool _bIsCurrentPage;

		protected ViewModelPageBase()
		{
			Initilize();
		}

		

		protected virtual void Initilize()
		{

		}

	

		#region Properties		

		public abstract string DisplayName { get; }

		public bool IsCurrentPage
		{
			get { return _bIsCurrentPage; }
			set
			{
			    if (value == _bIsCurrentPage) return;
			    _bIsCurrentPage = value;

			    OnPropertyChanged("IsCurrentPage");
			}
		}

		
		
		

		#endregion // Properties

		#region Methods

		
		internal abstract bool IsPageValid();

		#endregion // Methods

		#region INotifyPropertyChanged Members



		public event PropertyChangedEventHandler PropertyChanged;



		protected virtual void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}


		#endregion // INotifyPropertyChanged Members


	}
 }
