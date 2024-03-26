﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.domain.account;

namespace TESTAPP.common.component
{

    // 이거 싹다 인터페이스로 옮기고 싶은데 버전이 딸려서 안됨 ...
    internal static class Dynamic
    {

        #region " 일반적인 컨트롤러 생성"
        public static void DynamicInsert<V>(V control, Control parent, string name ="", int width = 40,int height = 60) where V : Control
        {
            control.Name = $"{name}";
            control.Size = new Size(width, height);
            parent.Controls.Add(control);
        }

        #endregion

        #region " 라벨 전용 컨트롤러 생성기"
        public static void DynamicLabelInsert(Label control, Control parent, string name="", string text = "", int width = 40, int height = 60) 
        {
            control.TextAlign = ContentAlignment.MiddleRight;
            control.Text = text;
            DynamicInsert<Label>(control, parent, name, width, height);
        }
        #endregion

        #region "금액 전용 동적 컨트롤러 생성기"
        public static void DynamicAmountInsert(TextBox control, Control parent, string name = "", int width = 40, int height = 60)
        {
            control.TextAlign = HorizontalAlignment.Right;
            control.TextChanged += (sender, e) => SetTxtAmountPretty(parent, name);
            DynamicInsert<TextBox>(control, parent, name, width, height);
        }
        #endregion

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
        public static T GetControl<T>(Control parent, string name) where T : Control
        {
            if (parent.Controls.Find(name, true).FirstOrDefault() is T control)
            {
                return control;
            }
            return null;
        }
        #endregion

        #region "동적 Text 의 금액을 GET/SET 하는 메소드"
        public static string GetTxtAmountPretty(Control form, string name)
        {
            if (form.Controls.Find(name, true).FirstOrDefault() is TextBox control)
            {
                return control.Text.Replace(",", "");
            }
            return null;
        }
        public static void SetTxtAmountPretty(Control form, string name)
        {
            // 금액 1,000,000 이렇게 찍어주는 로직
            if (form.Controls.Find(name, true).FirstOrDefault() is TextBox control)
            {
                if (decimal.TryParse(control.Text, out decimal result) && result >= 0)
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

        #region "이자 추정 및 역추정"
        public static decimal ConvertInterest(SettleType type, string value, double remain, double share)
        {
            // 연간 이자율 <-> 단위기간 이자율 추정하기
            decimal approximation;
            if (type == SettleType.복리)
            {
                decimal number = (decimal.Parse(value) / 100) + 1;
                decimal cubeRoot = (decimal)Math.Pow((double)number, remain / share);
                approximation = (Math.Round(cubeRoot * 100, 8) - 100);
            }
            else
            {
                decimal number = decimal.Parse(value);
                decimal interestResult = number * (decimal)(remain / share);
                approximation = (Math.Round(interestResult, 8));
            }
            return approximation; 
        }

        #endregion

        public static int ConvertSettlePeriodDate(SettlePeriodType type)
        {
            int share = 1;
            switch (type)
            {
                case SettlePeriodType.일:
                    share = 365-105;
                    break;
                case SettlePeriodType.개월:
                    share = 12;
                    break;
                case SettlePeriodType.년:
                    share = 1;
                    break;
            }

            return share;
        }
    }
}
