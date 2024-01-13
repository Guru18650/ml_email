namespace ml_email
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        FileResult fr;

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Email.Default.IsComposeSupported)
            {

                string subject = topicE.Text;
                string body = contentE.Text;
                string[] recipients = new[] { emailE.Text };
                    var message = new EmailMessage
                    {
                        Subject = subject,
                        Body = body,
                        BodyFormat = EmailBodyFormat.PlainText,
                        To = new List<string>(recipients)
                    };
                if (!btnD.IsEnabled)
                    message.Attachments.Add(new EmailAttachment(fr.FullPath));
               

                await Email.Default.ComposeAsync(message);
            } else
            {
                await DisplayAlert("Błąd", "Sprawdź możliwość wysyłania EMAIL na telefonie", "OK");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            fr = await MediaPicker.PickPhotoAsync();
            btnD.IsEnabled = false;
            btnD.Text = fr.FileName;
        }
    }
}