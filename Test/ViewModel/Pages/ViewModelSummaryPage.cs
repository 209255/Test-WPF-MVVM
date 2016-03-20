using Test.ViewModel.Pages.Base;
namespace Test.ViewModel.Pages
{
    class ViewModelSummaryPage:ViewModelPageBase
    {
        //=============================================================================
		public ViewModelSummaryPage()
		{

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
				string helloString1 = "Hello";

				return helloString1;
			}
		}

	}
 }

