using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTAPP.common.component
{
    internal static class Dynamic
    {
        public static void DynamicInsert<V>(Form form, V control, FlowLayoutPanel pannel, string name ="", string text="", int width = 40,int height = 60) where V : Control
        {
            control.Name = $"{name}";
            control.Parent = form;
            control.Size = new Size(width, height);
            control.Text = $"{text}";
            form.Controls.Add(control);
            pannel.Controls.Add(control);
        }

        public static void DynamicLabelInsert(Form form, Label control, FlowLayoutPanel pannel, string name = "", string text = "", int width = 40, int height = 60) 
        {
            control.TextAlign = ContentAlignment.MiddleCenter;
            DynamicInsert<Label>(form, control, pannel, name, text, width, height);
        }

        public static void DynamicAmountInsert(Form form, TextBox control, FlowLayoutPanel pannel, string name = "", string text = "", int width = 40, int height = 60)
        {
            control.TextAlign = HorizontalAlignment.Right;
            control.TextChanged += (sender, e) => SetTxtAmountPretty(form, name);
            DynamicInsert<TextBox>(form, control, pannel, name, text, width, height);
        }

        public static string GetControlValue<T>(Form form, string name) where T : Control
        {
            if (form.Controls.Find(name, true).FirstOrDefault() is T control)
            {
                return control.Text;
            }
            return null;
        }
        public static string GetTxtAmountPretty(Form form, string name)
        {
            if (form.Controls.Find(name, true).FirstOrDefault() is TextBox control)
            {
                return control.Text.Replace(",", "");
            }
            return null;
        }
        public static void SetTxtAmountPretty(Form form, string name)
        {
            // 금액 1,000,000 이렇게 찍어주는 로직
            if (form.Controls.Find(name, true).FirstOrDefault() is TextBox control)
            {
                if (decimal.TryParse(control.Text, out decimal result))
                {
                    control.Text = string.Format("{0:#,##0}", result);
                    control.SelectionStart = control.TextLength;
                    control.SelectionLength = 0;
                }
                else
                {
                    control.Text = "0";
                }

            }
        }
        public static void SetEnumToCombo<V>(ComboBox control) where V : Enum
        {
            // 콤보 박스에다가 ENUM값을 넣어주는 로직
            String[] values = typeof(V).GetEnumNames();
            foreach (String value in values) { control.Items.Add(value); }
        }


        // 개선하고싶은데 실력부족...
        public static void OpenNewForm<T>() where T : Form, new()
        {
            T newform = new T
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            newform.ShowDialog();
        }

        public static void OpenNewForm<T>(T form) where T : Form, new()
        {

            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }


    }
}
