using LanaKaraokeBar_ConceptionWPF.Pages;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LanaKaraokeBar_ConceptionWPF
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Page CurrentPage { get => currentPage; set { currentPage = value; Signal(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private Page currentPage;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SetCurrentPage(new WelcomePage());
        }

        private void Signal(string? prop = null)
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void SetCurrentPage(Page page)
        {
            CurrentPage = page;
        }

        private void ShowConcept_Click(object sender, RoutedEventArgs e)
        {
            SetCurrentPage(new ConceptPage());
        }

        private void ShowWireFrame_Click(object sender, RoutedEventArgs e)
        {
            SetCurrentPage(new WireFramePage());
        }

        private void ShowStructure_Click(object sender, RoutedEventArgs e)
        {
            SetCurrentPage(new StructurePage());
        }

        private void Exit_Click(object sender, RoutedEventArgs e) 
        {
            Close();
        }
    }
}