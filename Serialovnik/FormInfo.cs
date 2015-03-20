using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Serialovnik
{
    public partial class FormInfo : Form
    {
        FormMain formMain;

        public FormInfo(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }
    }
}
