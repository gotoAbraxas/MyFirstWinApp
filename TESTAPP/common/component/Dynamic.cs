using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public static string GetControlValue<T>(Form form, string name) where T : Control
        {
            if (form.Controls.Find(name, true).FirstOrDefault() is T control)
            {
                return control.Text;
            }
            return null;
        }


    }
}
