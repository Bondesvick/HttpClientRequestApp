using Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MainUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUsersData allAuthors { get; }

        public MainWindow(IUsersData allAuthors)
        {
            this.allAuthors = allAuthors;
            InitializeComponent();
        }

        // When the main window is loaded
        private async void Main_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await allAuthors.GetNames(@"https://jsonmock.hackerrank.com/api/article_users/search?page=");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
            this.DataContext = allAuthors;
        }

        // Gets name of users ordered by their Submission count
        private void BySubmission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int threshold = int.Parse(this.SubmitThresh.Text);
                this.Values.ItemsSource = allAuthors.BySubmission(threshold);
                this.Status.Text = $"Names of the most active authors (using submission count as the criteria) according to a set threshold not less than {threshold}:";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
        }

        // Gets name of user with the highest Comment count
        private void ByComment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Values.ItemsSource = allAuthors.ByComment();
                this.Status.Text = "Name of the author with the highest comment count:";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
        }

        // Gets names ordered by when article was created
        private void ByCreated_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Values.ItemsSource = allAuthors.ByCreated(Picker.DisplayDate);
                this.Status.Text = $"Names of authors sorted in Ascending order by when their record was created, according to a set threshold of on or after {Picker.DisplayDate.ToLongDateString()}:";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
    }
}