using SmartHorasExtras.Controllers.FormMessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHorasExtras.Controllers.Entities
{
    public partial class ColaboradorAdd
    {
        public static DialogResult Show(MessageBoxButtons button1)
        {
            DialogResult result;
            using (var msgForm = new FormColaboradorAdd(button1))
                result = msgForm.ShowDialog();
            return result;
        }
    }
}
