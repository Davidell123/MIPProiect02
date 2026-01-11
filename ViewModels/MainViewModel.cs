using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIPProiect02.Models;
using MIPProiect02.Services;
using MIPProiect02.Views;
using System.Collections.ObjectModel;

namespace MIPProiect02.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly DatabaseService _db;

    [ObservableProperty]
    private bool isRefreshing;

    public ObservableCollection<TodoItem> Items { get; } = new();

    public MainViewModel(DatabaseService db) => _db = db;

    [RelayCommand]
    public async Task LoadTasksAsync()
    {
        IsRefreshing = true;
        try
        {
            var tasks = await _db.GetItemsAsync();
            Items.Clear();
            foreach (var t in tasks) Items.Add(t);
        }
        finally { IsRefreshing = false; }
    }

    [RelayCommand]
    async Task GoToAddTaskAsync() => await Shell.Current.GoToAsync(nameof(TaskDetailPage));

    [RelayCommand]
    async Task DeleteTaskAsync(TodoItem item)
    {
        if (item == null) return;
        await _db.DeleteItemAsync(item);
        Items.Remove(item);
    }

    [RelayCommand]
    async Task ToggleStatusAsync(TodoItem item)
    {
        if (item != null) await _db.SaveItemAsync(item);
    }

    [RelayCommand]
    public async Task SearchTasksAsync(string query)
    {
        var allTasks = await _db.GetItemsAsync();
        Items.Clear();
        if (string.IsNullOrWhiteSpace(query))
        {
            foreach (var t in allTasks) Items.Add(t);
        }
        else
        {
            var filtered = allTasks.Where(t => t.Title.ToLower().Contains(query.ToLower()));
            foreach (var t in filtered) Items.Add(t);
        }
    }
}