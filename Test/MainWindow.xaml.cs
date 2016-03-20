using System;
using System.Windows;
using System.Windows.Controls;
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
        InitializeComponent();
        var wizardViewModelMain = new WizardViewModelMain();
        wizardViewModelMain.RequestClose += OnViewModelRequestClose;
        this.DataContext = wizardViewModelMain;

    }


    private void OnViewModelRequestClose(object sender, EventArgs e)
    {
        Close();
    }
}
}
