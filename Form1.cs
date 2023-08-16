using System.Runtime.InteropServices;

namespace HesapMakinesi_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        decimal number;
        string operations = "";
        int sayi = 0;
        decimal txtNumber = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(304, 456);
            txtCalculate.Focus();
        }

        #region Navigation
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTÝON = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void pnlNavi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTÝON, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region NumpadOperators
        private void txtCalculate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //lbResult.Text = txtCalculate.Text;
            }
            if (e.KeyChar == 43)
            {
                e.Handled = true;
                btnPlus_Click(sender, e);
            }
            if (e.KeyChar == 45)
            {
                e.Handled = true;
                btnMinus_Click(sender, e);
            }
            if (e.KeyChar == 42)
            {
                e.Handled = true;
                btnMultiply_Click(sender, e);
            }
        }
        #endregion

        #region Numbers
        private void btnOne_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "2";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "0";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "9";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtCalculate.Text = txtCalculate.Text + "3";
        }
        #endregion

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (txtCalculate.Text != "")
            {
                if (operations == "")
                {
                    operations = txtCalculate.Text;
                }
                else
                {
                    operations += " + " + txtCalculate.Text;
                    lstHistory.Items.Add(operations);
                }
                
            }
            decimal txtNumber = txtCalculate.Text == "" ? 0 : Convert.ToDecimal(txtCalculate.Text);
            number += txtNumber;
            lbResult.Text = Convert.ToString(number);
            lstHistory.Items.Add(operations + " = " + lbResult.Text);
            lbOperations.Text = operations;
            txtCalculate.Clear();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (txtCalculate.Text != "")
            {
                decimal txtNumber = Convert.ToDecimal(txtCalculate.Text);

                if (operations == "")
                {
                    number = txtNumber;
                    operations = txtNumber.ToString();
                }
                else
                {
                    number -= txtNumber;
                    operations = operations + " - " + txtNumber.ToString();
                    
                }

                lbOperations.Text = operations;
                lbResult.Text = Convert.ToString(number);
                lstHistory.Items.Add(operations + " = " + lbResult.Text);
                txtCalculate.Clear();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCalculate.Clear();
            lbOperations.Text = "";
            lbResult.Text = "";
            number = 0;
            operations = "";
            // decimal txtNumber = 0;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (txtCalculate.Text != "")
            {
                decimal txtNumber = Convert.ToDecimal(txtCalculate.Text);

                if (operations == "")
                {
                    number = txtNumber;
                    operations = txtNumber.ToString();
                }
                else
                {
                    number *= txtNumber;
                    operations = operations + " * " + txtNumber.ToString();
                    
                }

                lbOperations.Text = operations;
                lbResult.Text = Convert.ToString(number);
                lstHistory.Items.Add(operations + " = " + lbResult.Text);
                txtCalculate.Clear();
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (txtCalculate.Text != "")
            {
                decimal txtNumber = Convert.ToDecimal(txtCalculate.Text);

                if (operations == "")
                {
                    number = txtNumber;
                    operations = txtNumber.ToString();
                }
                else
                {
                    number /= txtNumber;
                    operations = operations + " / " + txtNumber.ToString();
                    
                }

                lbOperations.Text = operations;
                lbResult.Text = Convert.ToString(number);
                lstHistory.Items.Add(operations + " = " + lbResult.Text);
                txtCalculate.Clear();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.Size = new Size(615, 456);
        }
    }
}