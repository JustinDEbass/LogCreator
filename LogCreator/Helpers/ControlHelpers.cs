using LogCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogCreator.Helpers
{
    /// <summary>
    /// Помощники для управляющих элементов
    /// </summary>
    public static class ControlHelpers
    {
        /// <summary>
        /// Выбрать элемент
        /// </summary>
        /// <param name="comboBox">Управляющий элемент "Список"</param>
        /// <param name="lambda">Выражение для определения элемента, который необходимо выбрать в списке</param>
        /// <returns>Индекс выбранного элемента</returns>
        public static int SelectItem(this ComboBox comboBox, Func<ComboBoxItem, bool> lambda)
        {
            var result = -1;

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = (ComboBoxItem)comboBox.Items[i];

                if (lambda(item))
                {
                    comboBox.SelectedIndex = i;
                    result = comboBox.SelectedIndex;

                    break;
                }
            }

            return result;
        }
    }
}
