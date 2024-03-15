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

        #region " 일반적인 컨트롤러 생성"
        public static void DynamicInsert<V>(Form form, V control, FlowLayoutPanel pannel, string name ="", int width = 40,int height = 60) where V : Control
        {
            control.Name = $"{name}";
            control.Parent = form;
            control.Size = new Size(width, height);
            form.Controls.Add(control);
            pannel.Controls.Add(control);
        }

        #endregion

        #region " 라벨 전용 컨트롤러 생성기"
        public static void DynamicLabelInsert(Form form, Label control, FlowLayoutPanel pannel,string name="", string text = "", int width = 40, int height = 60) 
        {
            control.TextAlign = ContentAlignment.MiddleRight;
            control.Text = text;
            DynamicInsert<Label>(form, control, pannel, "", width, height);
        }
        #endregion

        #region "금액 전용 동적 컨트롤러 생성기"
        public static void DynamicAmountInsert(Form form, TextBox control, FlowLayoutPanel pannel, string name = "", int width = 40, int height = 60)
        {
            control.TextAlign = HorizontalAlignment.Right;
            control.TextChanged += (sender, e) => SetTxtAmountPretty(form, name);
            DynamicInsert<TextBox>(form, control, pannel, name, width, height);
        }
        #endregion

        public static void DynamicCheckBox(Form form, CheckBox checkBox, FlowLayoutPanel pannel,bool value, string name = "", int width = 40, int height = 60)
        {

            checkBox.Checked = value;
            DynamicInsert<CheckBox>(form, checkBox, pannel, name, width, height);
        }

        #region "이름으로 Text 값을 가져옴"
        public static string GetControlValue<T>(Form form, string name) where T : Control
        {
            if (form.Controls.Find(name, true).FirstOrDefault() is T control)
            {
                return control.Text;
            }
            return null;
        }
        #endregion

        #region "이름으로 컨트롤을 가져옴"
        public static T GetControl<T>(Form form, string name) where T : Control
        {
            if (form.Controls.Find(name, true).FirstOrDefault() is T control)
            {
                return control;
            }
            return null;
        }
        #endregion

        #region "동적 Text 의 금액을 GET/SET 하는 메소드"
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
        #endregion

        #region "콤보박스에 Enum 을 세팅해주는 녀석"
        public static void SetEnumToCombo<V>(ComboBox control) where V : Enum
        {
            // 콤보 박스에다가 ENUM값을 넣어주는 로직
            /*
            typeof(V)
            String[] values = typeof(V).GetEnumNames();
            foreach (String value in values) { control.Items.Add(value); }
            */

            // displayname 을 외부에서 받아오면 어떨까?
            Array enumValues = Enum.GetValues(typeof(V));
            control.DisplayMember = "Name";
            foreach (V enumValue in enumValues)
            {
                control.Items.Add(enumValue);
            }
        }
        #endregion

        #region " 폼을 생성해서 키거나.. 받아와서 키거나"
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
        #endregion


    }
}
