using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NcoVAppUpdate
{
    public class FeelingSickVM
    {
        string telephonenumber = "(02) 8651 7800";
        string smsnumber = "+639188888364";
        string messageText = "";
        public Command Call { get; }
        public Command SMS { get; }

        void CallDOH()
        {
            try
            {
                PhoneDialer.Open(telephonenumber);
            }
            catch
            {

            }
        }
        async Task TextDOH()
        {
            try
            {
                SmsMessage message = new SmsMessage(messageText, new[] { smsnumber });
                await Sms.ComposeAsync(message);
            }
            catch (Exception)
            {

            }
        }
        public FeelingSickVM()
        {
            Call = new Command(CallDOH);
            SMS = new Command(async () => await TextDOH());
        }
    }
}
