using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Test.ViewModel.Pages;
using Test.ViewModel.Pages.Base;
using Test.Command;
namespace Test.ViewModel
{
    public class WizardViewModelMain : INotifyPropertyChanged
    {
        #region Fields

		//Wizard Pages
        private List<ViewModelPageBase> _crPages;
        private ViewModelPageBase _crCurrentPage;
       
		//Navigation Buttons
		RelayCommand _crCancelCommand;
		RelayCommand _crMoveNextCommand;
		RelayCommand _crMovePreviousCommand;

		#endregion // Fields


		#region Constructor


		public WizardViewModelMain()
		{
			CurrentPage = Pages[0];
		}

		

		#endregion // Constructor

		#region Commands

		#region CancelCommand

		public ICommand CancelCommand
		{
			get { return _crCancelCommand ?? (_crCancelCommand = new RelayCommand(CancelOperation)); }
		}

		

	    private void CancelOperation()
		{
		
			OnRequestClose();
		}

		#endregion // CancelCommand

		#region MovePreviousCommand

		
		public ICommand MovePreviousCommand
		{
			get
			{
			    return _crMovePreviousCommand ?? (_crMovePreviousCommand = new RelayCommand(
			        MoveToPreviousPage,
			        () => CanMoveToPreviousPage));
			}
		}

		

	    private bool CanMoveToPreviousPage
		{
			get { return 0 < CurrentPageIndex; }
		}


	    private void MoveToPreviousPage()
		{
			if (CanMoveToPreviousPage)
			{
				CurrentPage = Pages[CurrentPageIndex - 1];
			}
		}



		#endregion // MovePreviousCommand

		#region MoveNextCommand

		
		public ICommand MoveNextCommand
		{
			get
			{
			    return _crMoveNextCommand ?? (_crMoveNextCommand = new RelayCommand(
			        MoveToNextPage,
			        () => CanMoveToNextPage));
			}
		}

		//=============================================================================

	    private bool CanMoveToNextPage
		{
			get { return CurrentPage != null && CurrentPage.IsPageValid(); }
		}

		//=============================================================================

	    private void MoveToNextPage()
		{
		    if (!CanMoveToNextPage) return;
		    if (CurrentPageIndex < Pages.Count - 1)
		    {
		        CurrentPage = Pages[CurrentPageIndex + 1];
		    }
		    else
		    {
		        OnRequestClose();
		    }
		}

	    //=============================================================================

		#endregion // MoveNextCommand

		#endregion // Commands

		#region Properties

		public ViewModelPageBase CurrentPage
		{
			get { return _crCurrentPage; }
			private set
			{
				if (value == _crCurrentPage)
					return;

				if (_crCurrentPage != null)
				{
					_crCurrentPage.IsCurrentPage = false;
				}

				_crCurrentPage = value;

				if (_crCurrentPage != null)
				{
					_crCurrentPage.IsCurrentPage = true;
				}

				OnPropertyChanged("CurrentPage");
				OnPropertyChanged("IsOnLastPage");
			}
		}

		

		public bool IsOnLastPage
		{
			get { return CurrentPageIndex == Pages.Count - 1; }
		}

		
		public List<ViewModelPageBase> Pages
		{
			get
			{
				if (_crPages == null)
				{
					CreatePages();
				}

				return _crPages;
			}
		}



		#endregion // Properties
		#region Events

	
		public event EventHandler RequestClose;

	
		#endregion // Events

		#region Private Helpers

      
	
	    private void CreatePages()
		{
		    var pages = new List<ViewModelPageBase>
		    {
               new ViewModelWelcomePage(),
		       new ViewModelName(),
               new ViewModelSurname(),
               new ViewModelPhone(),
               new ViewModelAdress(),
             
		    };
	        _crPages = pages;
	        _crPages.Add(new ViewModelSummaryPage(pages));
		}

	    private int CurrentPageIndex
		{
			get
			{
			    if (CurrentPage != null) return Pages.IndexOf(CurrentPage);
			    Debug.Fail("Why is the current page null?");
			    return -1;
			}
		}

	    private void OnRequestClose()
		{
			EventHandler handler = RequestClose;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}

		

		#endregion // Private Helpers

		#region INotifyPropertyChanged Members

		

		public event PropertyChangedEventHandler PropertyChanged;

		

	    private void OnPropertyChanged(string propertyName)
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
