using RazorTemplateViewer.ViewModels.Base;
using System.Windows.Input;
using System.Windows;

namespace RazorTemplateViewer.ViewModels.MainWindow
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Public properties
        /// <summary>
        /// The current view of the application
        /// </summary>
        public BaseViewModel CurrentView { get; set; }

      
        /// <summary>
        /// Relay command to change the window state Maximized
        /// </summary>
        public ICommand MaximizedWindowCommand { get; set; }

        /// <summary>
        /// Relay command to change the window state Minimized
        /// </summary>
        public ICommand MinimizedWindowCommand { get; set; }

        /// <summary>
        /// Relay command to change the window state Minimized
        /// </summary>
        public ICommand ExitAppCommand { get; set; }

        /// <summary>
        /// The main window of the application
        /// </summary>
        public Window Window { get; set; }

        /// <summary>
        /// The resize state of the main window
        /// </summary>
        public ResizeMode ResizeMode { get; set; } = ResizeMode.NoResize;

        /// <summary>
        /// The window curvature
        /// </summary>
        public CornerRadius TitleBarCornerRadius { get; set; } = new CornerRadius(10, 10, 0, 0);

        /// <summary>
        /// The window width
        /// </summary>
        public int WindowWidth { get; set; } = 1200;

        /// <summary>
        /// The window height
        /// </summary>
        public int WindowHeight { get; set; } = 800;

        /// <summary>
        /// The window gutter width
        /// </summary>
        public int WindowGutterWidth { get; set; } = 10;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// 
        public MainWindowViewModel(Window window)
        {
            Window = window;
            SetupCommand();
        }
 

    
        public void SetupCommand()
        {
            MaximizedWindowCommand = new RelayCommand(() => {
                if (ResizeMode == ResizeMode.NoResize) return;
                WindowGutterWidth = 0;
                TitleBarCornerRadius = new CornerRadius(0, 0, 0, 0);
                Window.WindowState = WindowState.Maximized;
            });

            MinimizedWindowCommand = new RelayCommand(() =>
            {
                WindowGutterWidth = 10;
                TitleBarCornerRadius = new CornerRadius(10, 10, 0, 0);
                Window.WindowState = WindowState.Minimized;
            });

            ExitAppCommand = new RelayCommand(() => Window.Close());
        }
        #endregion
    }
}
