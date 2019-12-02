using KymetaCodingTest.Helpers;
using System;
using System.Text.RegularExpressions;
using System.Timers;

using System.Windows;
using System.Windows.Input;

namespace KymetaCodingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer;
        public int counter = 0;
        public int second = 0;
        public int newVal = 0;
        Helper helper = new Helper();

        // lock handle for shared result
        private static object lockHandle = new object();

        // event wait handles
        private readonly System.Threading.ManualResetEvent setResult = new System.Threading.ManualResetEvent(false);

        public MainWindow()
        {
            InitializeComponent();
            resultTextBlock.Text = counter.ToString();

            System.Threading.Thread task = new System.Threading.Thread(backgroundTask);
            task.IsBackground = true; // execute the task in background
            task.Start();

        }

        private void backgroundTask()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Elapsed += onTimeElapsed;
            timer.Start();
            setResult.WaitOne();
        }
        private void onTimeElapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                ((Timer)sender).Stop();
                second += 1;
                resultOfNumberOfSecond.Text = string.Format("{0}", second.ToString());
                ((Timer)sender).Start();
            });
        }

        /// <summary>
        /// Reset the timer at the beginning zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetNumberOfSecond_Click(object sender, RoutedEventArgs e)
        {
            second = 0;
            resultOfNumberOfSecond.Text = second.ToString();
        }

        /// <summary>
        /// Set the timer to new value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setArbitraryValue_Click(object sender, RoutedEventArgs e)
        {
            newVal = helper.ConvertStringToNumber(arbitraryValueTextBox.Text);
            if (newVal != -1)
            {
                lock (lockHandle)
                {
                    second = newVal;
                }
                resultOfNumberOfSecond.Text = second.ToString();
                setResult.Set();
            }
        }

        /// <summary>
        /// Increment the counter by 1 when clicking on the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void incrementCounter_Click(object sender, RoutedEventArgs e)
        {
            lock(lockHandle)
            {
                counter++;
            }
            resultTextBlock.Text = counter.ToString();
            setResult.Set();
        }

        // This method allows to validate the input. Only numeric value is allowed
        private void validateNumberTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !helper.IsNumeric(e.Text);
        }
    }
}
