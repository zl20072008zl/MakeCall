using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace week9
{
    [Activity(Label = "week9", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText txtMessage;
        Button btnCall;
        Button btnSms;
        Button btnEmail;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnCall = FindViewById<Button>(Resource.Id.btnCall);
            btnSms = FindViewById<Button>(Resource.Id.btnSms);
            btnEmail = FindViewById<Button>(Resource.Id.btnEmail);
            txtMessage = FindViewById<EditText>(Resource.Id.txtMessage);

            btnCall.Click += BtnCall_Click;
            btnSms.Click += BtnSms_Click;
            btnEmail.Click += BtnEmail_Click;
        }

        private void BtnCall_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this,"123",ToastLength.Short).Show();

            var uri1 = Android.Net.Uri.Parse("tel:212354567");
            var intent = new Intent(Intent.ActionDial,uri1);
            //var intent = new Intent(Intent.ActionCall, uri1); //take call
            StartActivity(intent);
        }

        private void BtnSms_Click(object sender, EventArgs e)
        {
            //string txtNumber = "tel:" + txtMessage.Text;
            var smsUri = Android.Net.Uri.Parse("smsto:12312321");
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            var smsContent = txtMessage.Text;
            smsIntent.PutExtra("sms_body", smsContent);
            StartActivity(smsIntent);
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            Intent email = new Intent(Intent.ActionSend);
            email.SetType("message/rfc822");
            email.PutExtra(Intent.ExtraEmail,
                new String[] { "person1@xamarin.com", "person2@xamrin.com" });

            email.PutExtra(Intent.ExtraCc,
                new String[] { "person3@xamarin.com" });

            email.PutExtra(Intent.ExtraSubject, "Hello Email");

            email.PutExtra(Intent.ExtraText,
            "Hello from Xamarin.Android");

            StartActivity(Intent.CreateChooser(email, "Send mail"));
        }
    }
}

