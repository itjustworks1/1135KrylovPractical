using _1135KrylovPractical.Models.Services;
using _1135KrylovPractical.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace _1135KrylovPractical.Views;

public partial class EmployeesView : Window
{
    public EmployeesView(ApiService api, EmployeeDto? employee = null)
    {
        InitializeComponent();
        DataContext = new EmployeeEditorViewModel(api, employee);
}