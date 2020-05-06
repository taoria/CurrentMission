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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentMission
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        private bool editing =false;
        private bool working = false;
        private void DoWork()
        {
            working = true;
            commitWork.Visibility = Visibility.Visible;
        }
        private void FinishWork()
        {
            working = false;
            textBoxWhenEdit.Text = "Mission to be set";
            labelShow.Content = "Mission to be set";
            commitWork.Visibility = Visibility.Hidden;

        }
        private void Toggle()
        {
            editing = !editing;
            viewBoxLabel.Visibility = editing?Visibility.Hidden:Visibility.Visible;
            viewBoxTextBox.Visibility = editing ? Visibility.Visible : Visibility.Hidden;
            if (editing)
            {
                textBoxWhenEdit.Text = labelShow.Content.ToString();
            }
            else
            {
                //Hardcode code to be refactor in letter version

                if (textBoxWhenEdit.Text.Length > 0 && textBoxWhenEdit.Text.Equals("Mission to be set") == false)
                {
                    labelShow.Content = textBoxWhenEdit.Text;
                    if (!working)
                    {
                        DoWork();
                    }
                }

            }
        }
        private void MenuEditClick(object sender, RoutedEventArgs e)
        {
            if (editing == false)
            {
                Toggle();
            }
        }

        private void WhenDoubleClickOnItem(object sender, MouseButtonEventArgs e)
        {
            Toggle();
        }

        private void textBoxWhenEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            Toggle();
        }

        private void TextBoxWhenEidt_PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                Toggle();
            }
        }

        private void CommitWork_Click(object sender, RoutedEventArgs e)
        {
            FinishWork();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
