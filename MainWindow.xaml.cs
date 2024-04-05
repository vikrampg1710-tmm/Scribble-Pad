using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ScribblePad;

public partial class MainWindow : Window {
   public MainWindow () {
      InitializeComponent ();
   }
   private Point mCurrentPoint = new ();

   private void ScribblePad_MouseDown (object sender, MouseButtonEventArgs e) {
      if (e.ButtonState == MouseButtonState.Pressed) mCurrentPoint = e.GetPosition (this);
   }

   private void ScribblePad_MouseMove (object sender, MouseEventArgs e) {
      if (e.LeftButton == MouseButtonState.Pressed) {
         Line line = new () {
            Stroke = System.Windows.Media.Brushes.White,
            X1 = mCurrentPoint.X,
            Y1 = mCurrentPoint.Y,
            X2 = e.GetPosition (this).X,
            Y2 = e.GetPosition (this).Y,
         };
         mCurrentPoint = e.GetPosition (this);
         scribblePad.Children.Add (line);
      }
   }
}