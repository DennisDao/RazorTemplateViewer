using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RazorTemplateViewer
{
    /// <summary>
    /// Interaction logic for Rendering_2.xaml
    /// </summary>
    public partial class Rendering_2 : UserControl
    {
        public Rendering_2()
        {
            InitializeComponent();
            DelayStartAnimation();
        }

        private async void DelayStartAnimation()
        {
            await Task.Delay(2000);
            Storyboard blink = (Storyboard)this.Resources["BlinkStoryboard"];
            blink.Begin(line1, true);
            blink.Begin(line2, true);
            blink.Begin(line3, true);
            blink.Begin(line4, true);
            blink.Begin(line5, true);
            blink.Begin(line6, true);
            blink.Begin(line7, true);
            blink.Begin(line8, true);
        }

        private void BlinkingRect_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard blink = (Storyboard)this.Resources["BlinkStoryboard"];
        }

        private void leftPage_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["MarginAnimation"];
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();

        }

        private void rightPage_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["MarginAnimation2"];
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }
    }
}
