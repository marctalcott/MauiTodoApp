namespace TodoApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        // since not part of the shell (ie flyouts etc), we must add it here
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }
}