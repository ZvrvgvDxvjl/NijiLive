using System.Windows.Controls;
namespace NijiLive.classes
{
    class CustomListBoxItem : ListBoxItem
    {
        public override string ToString()
        {
            return Content.ToString();
        }
    }
}