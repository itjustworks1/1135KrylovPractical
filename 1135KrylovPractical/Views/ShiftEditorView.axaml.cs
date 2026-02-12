using _1135KrylovPractical.Models.Services;
using _1135KrylovPractical.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace _1135KrylovPractical.Views;

public partial class ShiftEditorView : Window
{
    public ShiftEditorView(ApiService api, ShiftDto? shift = null)
    {
        InitializeComponent();
        DataContext = new ShiftEditorViewModel(api, shift);
    }
}