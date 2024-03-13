namespace DnDSolution
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void ToCommonPage(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommonPage(), true);
        }

        private async void ToUncommonPage(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new UncommonPage(), true);
        }

        private async void toMenuPage(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(), true);
        }


        async void DonateButton_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Переход на сторонний сайт",
                                        "Вы действительно хотите перейти на сайт donationalerts.com?",
                                        "Yes", "No"))
            {
                try
                {
                    await Browser.Default.OpenAsync(new Uri("https://www.donationalerts.com/r/quanty_7"));
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", "Что-то пошло не так", "Ок");
                }
            }
        }

        async void TgButton_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Переход на сторонний сайт",
                                        "Вы действительно хотите перейти на сайт telegram.org?",
                                        "Yes", "No"))
            {
                try
                {
                    await Browser.Default.OpenAsync(new Uri("https://t.me/+UYevoaM7ttNmMzAy"));
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", "Что-то пошло не так", "Ок");
                }
            }
        }
    }

}
