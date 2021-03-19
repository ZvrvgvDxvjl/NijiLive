using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using NijiLive.classes;
namespace NijiLive
{
    public partial class AddEditChannelWindow : Window
    {
        private readonly MainWindow caller;
        private readonly Channel edit;
        private readonly string placeholderUrl;
        private readonly string placeholderAgency;
        private readonly string placeholderRegion;
        private readonly string placeholderGen;
        private bool hasCanceled;
        public AddEditChannelWindow(MainWindow _caller, Channel _edit)
        {
            InitializeComponent();
            caller = _caller;
            //gets the default text from the XML
            placeholderUrl = TxtBoxURL.Text;
            placeholderAgency = TxtBoxAgency.Text;
            placeholderRegion = TxtBoxRegion.Text;
            placeholderGen = TxtBoxGen.Text;
            edit = _edit;
            hasCanceled = true;
            if (edit == null)
            {
                //sets the initial font color to gray
                TxtBoxURL.Foreground = Brushes.Gray;
                TxtBoxAgency.Foreground = Brushes.Gray;
                TxtBoxRegion.Foreground = Brushes.Gray;
                TxtBoxGen.Foreground = Brushes.Gray;
                Title += "Add Channel";
            }
            else
            {
                TxtBoxURL.Text = edit.URL;
                TxtBoxName.Text = edit.Name;
                TxtBoxAgency.Text = edit.Agency;
                TxtBoxRegion.Text = edit.Region;
                if (!edit.Generation.Equals(string.Empty))
                {
                    TxtBoxGen.Text = edit.Generation;
                }
                else
                {
                    TxtBoxGen.Foreground = Brushes.Gray;
                }
                Title += "Edit Channel";
                LabelMessage.Content = "Edit channel info.";
                ButtonAdd.Content = "Edit";
            }
        }
        private void ButonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //The channel that is send for editing is deleted from the chnnale list afterwards so if the edit is canceled
            //the channel has to be added back to the list.
            if (edit != null && hasCanceled)
            {
                caller.AddChannel(edit);
                caller.LabelMessage.Content = "Canceled editing channel.";
            }else if (hasCanceled)
            {
                caller.LabelMessage.Content = "Canceled adding channel.";
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtBoxEntriesValid())
                {
                    if (!TxtBoxGen.Text.Equals(placeholderGen))
                    {
                        caller.AddChannel(new Channel(TxtBoxURL.Text, TxtBoxName.Text, TxtBoxAgency.Text, 
                            TxtBoxRegion.Text, TxtBoxGen.Text));
                    }
                    else
                    {
                        caller.AddChannel(new Channel(TxtBoxURL.Text, TxtBoxName.Text, TxtBoxAgency.Text, 
                            TxtBoxRegion.Text, string.Empty));
                    }
                    if (edit == null)
                    {
                        caller.LabelMessage.Content = "Successfully added channel.";
                    }
                    else
                    {
                        caller.LabelMessage.Content = "Successfully edited channel.";
                    }
                    hasCanceled = false;
                    Close();
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error trying to add channel.";
            }
        }
        private bool TxtBoxEntriesValid()
        {
            TxtBoxURL.Background = Brushes.White;
            TxtBoxName.Background = Brushes.White;
            TxtBoxAgency.Background = Brushes.White;
            TxtBoxRegion.Background = Brushes.White;
            bool retVal = true;
            //Reverse order so that error messages are shown descending from the top TextBox.
            //region isn't empty, only 2 chars long
            if (TxtBoxRegion.Text.Equals(string.Empty) || TxtBoxRegion.Text.Equals(placeholderRegion)
                || TxtBoxRegion.Text.Length != 2)
            {
                retVal = false;
                TxtBoxRegion.Background = Brushes.Red;
                LabelMessage.Content = "Enter valid country code.";
            }
            //agency isn't empty
            if (TxtBoxAgency.Text.Equals(string.Empty) || TxtBoxAgency.Text.Equals(placeholderAgency))
            {
                retVal = false;
                TxtBoxAgency.Background = Brushes.Red;
                LabelMessage.Content = "Enter an agency";
            }
            //URL isn't empty, starts with youtube link, doesn't end in /live or /, isn't the same as existing in list
            if (TxtBoxURL.Text.Equals(string.Empty) || TxtBoxURL.Text.Equals(placeholderUrl) ||
                !TxtBoxURL.Text.StartsWith("https://www.youtube.com/channel/") || 
                TxtBoxURL.Text.EndsWith("/live") || TxtBoxURL.Text.EndsWith("/") || 
                caller.URLExistsInList(TxtBoxURL.Text))
            {
                retVal = false;
                TxtBoxURL.Background = Brushes.Red;
                if(TxtBoxURL.Text.Equals(string.Empty) || TxtBoxURL.Text.Equals(placeholderUrl))
                {
                    LabelMessage.Content = "Enter channel URL.";
                }else if(!TxtBoxURL.Text.StartsWith("https://www.youtube.com/channel/") ||
                TxtBoxURL.Text.EndsWith("/live") || TxtBoxURL.Text.EndsWith("/"))
                {
                    LabelMessage.Content = "Enter valid channel URL - see ReadMe.txt for details.";
                }else if (caller.URLExistsInList(TxtBoxURL.Text))
                {
                    LabelMessage.Content = "Channel with this URL already on the list.";
                }
            }
            //name isn't empty, isn't the same as existing in list
            if (TxtBoxName.Text.Equals(string.Empty) || caller.NameExistsInList(TxtBoxName.Text))
            {
                retVal = false;
                TxtBoxName.Background = Brushes.Red;
                if (TxtBoxName.Text.Equals(string.Empty))
                {
                    LabelMessage.Content = "Enter a name.";
                }else if (caller.NameExistsInList(TxtBoxName.Text))
                {
                    LabelMessage.Content = "Channel with this name already on the list.";
                }
            }
            return retVal;
        }
        #region Handling of TextBox placeholder text.
        private void TxtBoxURL_GotFocus(object sender, RoutedEventArgs e)
        {
            if(TxtBoxURL.Text.Equals(placeholderUrl))
            {
                TxtBoxURL.Text = string.Empty;
                TxtBoxURL.Foreground = Brushes.Black;
            }
        }
        private void TxtBoxURL_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxURL.Text.Equals(string.Empty))
            {
                TxtBoxURL.Text = placeholderUrl;
                TxtBoxURL.Foreground = Brushes.Gray;
            }
        }
        private void TxtBoxAgency_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxAgency.Text.Equals(placeholderAgency))
            {
                TxtBoxAgency.Text = string.Empty;
                TxtBoxAgency.Foreground = Brushes.Black;
            }
        }
        private void TxtBoxAgency_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxAgency.Text.Equals(string.Empty))
            {
                TxtBoxAgency.Text = placeholderAgency;
                TxtBoxAgency.Foreground = Brushes.Gray;
            }
        }
        private void TxtBoxRegion_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxRegion.Text.Equals(placeholderRegion))
            {
                TxtBoxRegion.Text = string.Empty;
                TxtBoxRegion.Foreground = Brushes.Black;
            }
        }
        private void TxtBoxRegion_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxRegion.Text.Equals(string.Empty))
            {
                TxtBoxRegion.Text = placeholderRegion;
                TxtBoxRegion.Foreground = Brushes.Gray;
            }
        }
        private void TxtBoxGen_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxGen.Text.Equals(placeholderGen))
            {
                TxtBoxGen.Text = string.Empty;
                TxtBoxGen.Foreground = Brushes.Black;
            }
        }
        private void TxtBoxGen_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtBoxGen.Text.Equals(string.Empty))
            {
                TxtBoxGen.Text = placeholderGen;
                TxtBoxGen.Foreground = Brushes.Gray;
            }
        }
        #endregion
        #region Handling of TextBox keyboard navigation.
        private void TxtBoxName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Up)
                {
                    e.Handled = true;
                    TxtBoxGen.Focus();
                }
                else if (e.Key == Key.Down)
                {
                    e.Handled = true;
                    TxtBoxURL.Focus();
                }
                else if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    ButtonAdd.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error during keyboard navigation.";
            }
        }
        private void TxtBoxURL_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Up)
                {
                    e.Handled = true;
                    TxtBoxName.Focus();
                }
                else if (e.Key == Key.Down)
                {
                    e.Handled = true;
                    TxtBoxAgency.Focus();
                }
                else if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    ButtonAdd.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error during keyboard navigation.";
            }
        }
        private void TxtBoxAgency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Up)
                {
                    e.Handled = true;
                    TxtBoxURL.Focus();
                }
                else if (e.Key == Key.Down)
                {
                    e.Handled = true;
                    TxtBoxRegion.Focus();
                }
                else if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    ButtonAdd.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error during keyboard navigation.";
            }
        }
        private void TxtBoxRegion_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Up)
                {
                    e.Handled = true;
                    TxtBoxAgency.Focus();
                }
                else if (e.Key == Key.Down)
                {
                    e.Handled = true;
                    TxtBoxGen.Focus();
                }
                else if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    ButtonAdd.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error during keyboard navigation.";
            }
        }
        private void TxtBoxGen_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Up)
                {
                    e.Handled = true;
                    TxtBoxRegion.Focus();
                }
                else if (e.Key == Key.Down)
                {
                    e.Handled = true;
                    TxtBoxName.Focus();
                }
                else if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    ButtonAdd.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                }
            }
            catch (Exception)
            {
                LabelMessage.Content = "Error during keyboard navigation.";
            }
        }
        #endregion
    }
}