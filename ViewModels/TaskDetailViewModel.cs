using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MIPProiect02.Models;
using MIPProiect02.Services;

namespace MIPProiect02.ViewModels
{
    public partial class TaskDetailViewModel : ObservableObject
    {
        private readonly DatabaseService _db;

        [ObservableProperty]
        private string taskTitle = string.Empty;

        public TaskDetailViewModel(DatabaseService db) => _db = db;

        [RelayCommand]
        private async Task SaveTaskAsync()
        {
            if (string.IsNullOrWhiteSpace(TaskTitle)) return;
            await _db.SaveItemAsync(new TodoItem { Title = TaskTitle, DueDate = DateTime.Now });
            await Shell.Current.GoToAsync("..");
        }
    }
}