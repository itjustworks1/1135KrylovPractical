using _1135KrylovPractical.Models.Services;
using _1135KrylovPractical.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace _1135KrylovPractical.Views;

public partial class LoginWindow : Window
{
    public LoginWindow(ApiService api, AuthService auth)
    {
        InitializeComponent();
        DataContext = new LoginViewModel(api, auth);
    }
}