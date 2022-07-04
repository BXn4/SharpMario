using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SharpMario
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr windowHandle, int hotkeyId, uint modifierKeys, uint virtualKey);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr windowHandle, int hotkeyId);
        public Form1()
        {
            InitializeComponent();
        }

        private void spmariobros_Click(object sender, EventArgs e)
        {

        }
        int selected_index = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            selected_index = 0;
            title.Image = Image.FromFile(@"assets\original\screens\title.png");
            config.Image = Image.FromFile(@"assets\original\text\config.png");
            startgame.Image = Image.FromFile(@"assets\original\text\start_game.png");
            controls.Image = Image.FromFile(@"assets\original\text\controls.png");
            selected.Image = Image.FromFile(@"assets\original\mushroom.png");
        }

        private void checker_Tick(object sender, EventArgs e)
        {

        }
        //1pos : 243, 208
        //2pos : 258, 269
        //3pos : 287, 336
        private void keycheck_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(selected_index == 0)
                {
                    this.Hide();
                    lvl1 lvl1form = new lvl1();
                    lvl1form.ShowDialog();
                }
                if(selected_index == 1)
                {
                    controlsscreen.Visible = true;
                    controlsscreen.Image = Image.FromFile(@"assets\original\screens\controls_screen.png");
                    keycheck.Enabled = false;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                selected_index++;
                if(selected_index == 1)
                {
                    selected.Location = new Point(258, 269);
                }
                if(selected_index == 2)
                {
                    selected.Location = new Point(287, 336);
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                selected_index--;
                if (selected_index == 0)
                {
                    selected.Location = new Point(243, 208);
                }
                if (selected_index == 1)
                {
                    selected.Location = new Point(258, 269);
                }
                if (selected_index == 2)
                {
                    selected.Location = new Point(287, 336);
                }
            }
            if (selected_index >= 2)
            {
                selected_index = 2;
            }
            if (selected_index <= 0)
            {
                selected_index = 0;
            }
        }

        private void keycheck_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
