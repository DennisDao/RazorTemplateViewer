using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace RazorTemplateViewer
{
    /// <summary>
    /// Interaction logic for Rendering.xaml
    /// </summary>
    public partial class Rendering : UserControl
    {
        public Rendering()
        {
            InitializeComponent();
        }

        private void BlinkingRect_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard blink = (Storyboard)this.Resources["BlinkStoryboard"];
            blink.Begin(line1, true);
            blink.Begin(line2, true);
            blink.Begin(line3, true);
            blink.Begin(line4, true);
        }

    }
}
