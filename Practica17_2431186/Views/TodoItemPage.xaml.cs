using Practica17_2431186.Data;
using Practica17_2431186.Models;

namespace Practica17_2431186.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{

    TodoItem item;
    public TodoItem Item
    {
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }
    TodoItemDatabase database;
   
    public TodoItemPage(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        database = todoItemDatabase;
       
    }

    private async void OkButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name)||string.IsNullOrWhiteSpace(Item.FavoriteTeam))
        {
            await DisplayAlert("Error","Por favor ingresa todos los datos", "OK");
            return;
        }
        
        var newtodo = new TodoItem()
        {
            Name = NameEntry.Text,
            Birthdate=Birthdates.Date,
            FavoriteTeam = FavoriteTeamLabel.Text
        

        };
        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");

    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}