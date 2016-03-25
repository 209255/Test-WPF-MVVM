using Test.ViewModel.Pages.Base;
namespace Test.ViewModel.Pages
{
    class ViewModelWelcomePage:ViewModelPageBase
    {
        

		internal override bool IsPageValid()
		{
			return true;
		}

		

        public override string GetProperty { get; set; }

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

