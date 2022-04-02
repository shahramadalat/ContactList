using AppWithdatabase.Models;
using System;
using Xamarin.Forms;

namespace AppWithdatabase
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Age = int.Parse(ageEntry.Text),
                    Telephone= telEntry.Text,
                    Detail = detailEntry.Text
                });

                nameEntry.Text = ageEntry.Text = detailEntry.Text=telEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }


        private async void collectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection!=null)
            {
                var action = await DisplayAlert("ensure", "do you want to delete this?", "yes", "no");
                if (action)
                {
                    var agenda = collectionView.SelectedItem as Person;
                    await App.Database.DeletePersonAsync(agenda);
                    collectionView.ItemsSource = await App.Database.GetPeopleAsync();

                }
            }
            
        }
    }
}
