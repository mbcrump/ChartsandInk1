using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace telerikcontrols
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.InkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch | CoreInputDeviceTypes.Mouse;
        }

        private void PenButton_Click(object sender, RoutedEventArgs e)
        {
            this.InkCanvas.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Inking;

            var drawingAttributes = new InkDrawingAttributes
            {
                DrawAsHighlighter = false
            };

            this.InkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        }

        private async void RecognizeButton_Click(object sender, RoutedEventArgs e)
        {
            var inkRecognizer = new InkRecognizerContainer();
            if (null != inkRecognizer)
            {
                var recognitionResults = await inkRecognizer.RecognizeAsync(this.InkCanvas.InkPresenter.StrokeContainer, InkRecognitionTarget.All);
                string recognizedText = string.Join(" ", recognitionResults.Select(i => i.GetTextCandidates()[0]));

                if (recognizedText == "O") //This navigates to the Pie Chart (Combine Mode)
                {
                    //this.Frame.Navigate(typeof(dynamicseries));
                }

                if (recognizedText == "L") //This navigates to the Stacked Bar Chart (Combine Mode)
                {
                    this.Frame.Navigate(typeof(dynamicseries));
                }
            }
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(dynamicseries));
        }
    }
}
