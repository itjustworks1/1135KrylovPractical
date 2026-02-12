using _1135KrylovPractical.Models.Services;
using _1135KrylovPractical.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace _1135KrylovPractical.Views;

public partial class EmployeeEditorView : Window
{
    public EmployeeEditorView(ApiService api, EmployeeDTO? employee = null)
    {
        InitializeComponent();
        DataContext = new EmployeeEditorViewModel(api, employee);
    }
}