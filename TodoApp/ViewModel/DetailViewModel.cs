using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoApp.ViewModel;
[QueryProperty("text","text")]
public partial class DetailViewModel:ObservableObject
{
    [ObservableProperty] private string text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}