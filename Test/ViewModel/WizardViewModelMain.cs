using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ReadOnlyCollection<ViewModelPageBase> _crPages;
        private ViewModelPageBase _crCurrentPage;

		//Navigation Buttons
		RelayCommand _crCancelCommand;
		RelayCommand _crMoveNextCommand;
		RelayCommand _crMovePreviousCommand;

		#endregion // Fields


		#region Constructor

		//=============================================================================

		public WizardViewModelMain()
		{
			CurrentPage = Pages[0];
		}

		//=============================================================================

		#endregion // Constructor

		#region Commands

		#region CancelCommand

		//=============================================================================
		/// <summary>
		/// Returns the command which, when executed, cancels the order 
		/// and causes the Wizard to be removed from the user interface.
		/// </summary>
		public ICommand CancelCommand
		{
			get { return _crCancelCommand ?? (_crCancelCommand = new RelayCommand(CancelOperation)); }
		}

		//=============================================================================

	    private void CancelOperation()
		{
			//_cupOfCoffee = null;
			OnRequestClose();
		}

		#endregion // CancelCommand

		#region MovePreviousCommand

		//=============================================================================

		/// <summary>
		/// Returns the command which, when executed, causes the CurrentPage 
		/// property to reference the previous page in the workflow.
		/// </summary>
		public ICommand MovePreviousCommand
		{
			get
			{
			    return _crMovePreviousCommand ?? (_crMovePreviousCommand = new RelayCommand(
			        MoveToPreviousPage,
			        () => CanMoveToPreviousPage));
			}
		}

		//=============================================================================

	    private bool CanMoveToPreviousPage
		{
			get { return 0 < CurrentPageIndex; }
		}

		//=============================================================================

	    private void MoveToPreviousPage()
		{
			if (CanMoveToPreviousPage)
			{
				CurrentPage = Pages[CurrentPageIndex - 1];
			}
		}

		//=============================================================================

		#endregion // MovePreviousCommand

		#region MoveNextCommand

		//=============================================================================
		/// <summary>
		/// Returns the command which, when executed, causes the CurrentPage 
		/// property to reference the next page in the workflow.  If the user
		/// is viewing the last page in the workflow, this causes the Wizard
		/// to finish and be removed from the user interface.
		/// </summary>
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

		
		public ReadOnlyCollection<ViewModelPageBase> Pages
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

		//=============================================================================

		#endregion // Properties



		#region Events

		//=============================================================================
		/// <summary>
		/// Raised when the wizard should be removed from the UI.
		/// </summary>
		public event EventHandler RequestClose;

		//=============================================================================
		#endregion // Events

		#region Private Helpers

		//=============================================================================
	    private void CreatePages()
		{
		    var pages = new List<ViewModelPageBase>
		    {
               new ViewModelWelcomePage(),
		       new ViewModelName(),
               new ViewModelSurname(),
               new ViewModelPhone(),
               new ViewModelAdress(),
               new ViewModelSummaryPage()
		    };
             _crPages = new ReadOnlyCollection<ViewModelPageBase>(pages);
		}

		//=============================================================================

	    private int CurrentPageIndex
		{
			get
			{
			    if (CurrentPage != null) return Pages.IndexOf(CurrentPage);
			    Debug.Fail("Why is the current page null?");
			    return -1;
			}
		}

       

        //=============================================================================

	    private void OnRequestClose()
		{
			EventHandler handler = RequestClose;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}

		//=============================================================================

		#endregion // Private Helpers

		#region INotifyPropertyChanged Members

		//=============================================================================

		public event PropertyChangedEventHandler PropertyChanged;

		//=============================================================================

	    private void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		//=============================================================================


		#endregion // INotifyPropertyChanged Members
	}
 }
