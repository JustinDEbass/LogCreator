using LogCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogCreator.Helpers
{
    public static class ControlHelper
    {
        public static int SelectItem(this ComboBox comboBox, Func<ComboBoxItem, bool> lambda)
        {
            var result = -1;

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = (ComboBoxItem)comboBox.Items[i];

                if (lambda(item))
                {
                    comboBox.SelectedIndex = i;

                    break;
                }
            }

            return result;
        }
    }
}
