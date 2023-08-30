using System.Collections.ObjectModel;
using Practica17_2431186.Models;
using Practica17_2431186.Data;


namespace Practica17_2431186.Views;

public partial class TodoListPage : ContentPage
{
    TodoItemDatabase database;
    
    public ObservableCollection<TodoItem> Items { get; set; } = new();
    
    public TodoListPage(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        database = todoItemDatabase;
        BindingContext = this;
    }

    private async void AddSurveyButton_Clicked(object sender, EventArgs e)
    {
        
        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new TodoItem()
        });
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
      
        var items = await database.GetItemsAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item); 
        });
    }
    
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not TodoItem item)
            return;

        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}