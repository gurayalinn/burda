using burda.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burda.Views
{
    public partial class HelpDeskPanel : BasePanel
    {
        public HelpDeskPanel()
    {
        InitializeComponent();
    }
    private void HelpDeskPanel_Load(object sender, EventArgs e)
    {
            Logger.Information("Views: HelpDeskPanel loaded.");
        }
    }
}