using System;
using ABSoftware.UI;

namespace Client
{
    public partial class MessagePopupForm : DraggableForm
    {
        public MessagePopupForm()
        {
            InitializeComponent();
        }

        public static void ShowMessage(string text)
        {
            MessagePopupForm messagePopup = new MessagePopupForm();
            messagePopup.MessageText.Text = text;

            messagePopup.ShowDialog();
        }
    }
}
