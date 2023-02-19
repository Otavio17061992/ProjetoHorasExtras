using SmartHorasExtras.Controllers.FormMessageBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHorasExtras.Controllers.Entities
{
    public abstract class Atencao
    {
        // construtor mensagem de atencao
        public static DialogResult Show(string titulo, string mensagem, Image imagem, MessageBoxButtons button1)
        {
            DialogResult result;
            using (var msgForm = new FormMessage(titulo, mensagem, imagem, button1))
                result = msgForm.ShowDialog();
            return result;
        }
    }
}
