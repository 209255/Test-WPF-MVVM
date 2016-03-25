using System;
using System.Windows;
using Test.ViewModel;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window

{
    public MainWindow()
    {
        var wizardViewModelMain = new WizardViewModelMain();
        
        InitializeComponent();
        wizardViewModelMain.RequestClose += OnViewModelRequestClose;
        this.DataContext = wizardViewModelMain;
       
    }


    private void OnViewModelRequestClose(object sender, EventArgs e)
    {
        Close();
    }
}
}
