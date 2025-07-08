using com.calitha.goldparser;

namespace PLD_Project
{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p = new MyParser("PLD_proj.cgt", listBox1 , listBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            p.Parse(textBox1.Text);


        }
    }
}
