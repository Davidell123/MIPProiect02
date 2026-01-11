using MIPProiect02.ViewModels;

namespace MIPProiect02
{
    public partial class MainPage : ContentPage
    {
        
        private readonly MainViewModel _viewModel;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            
            BindingContext = _viewModel = viewModel;
        }

       
        protected override async void OnAppearing()
        {
            base.OnAppearing();


            await _viewModel.LoadTasksAsync();
        }
    }
}