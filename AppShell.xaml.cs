using MIPProiect02.Views;

namespace MIPProiect02
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
            InitializeComponent();
        }
    }
}
