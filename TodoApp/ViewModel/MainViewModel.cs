using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace TodoApp.ViewModel;

public partial class MainViewModel:ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<String> items = new();
    
    [ObservableProperty]
    private string text;

    [RelayCommand]
    void Add()
    {
        if(string.IsNullOrWhiteSpace(Text))
            return;
        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }
   
}