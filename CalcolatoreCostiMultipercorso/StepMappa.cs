using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcolatoreCostiMultipercorso;

public partial class StepMappa : UserControl {
    public StepMappa() {
        InitializeComponent();
    }
    public void SetStep(Step step) {
        checkBox1.Checked = false;
        checkBox1.Text = step.Id + "";
        label1.Text = step.N_Risorsa1 + " " + step.Risorsa1;
        label2.Text = step.N_Risorsa2 + " " + step.Risorsa2;
        label3.Text = step.N_Risorsa3 + " " + step.Risorsa3;
        numericUpDown1.Maximum = step.N_Risorsa1;
        numericUpDown2.Maximum = step.N_Risorsa2;
        numericUpDown3.Maximum = step.N_Risorsa3;
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e) {
        if (checkBox1.Checked) {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }
        numericUpDown1.Enabled = !checkBox1.Checked;
        label1.Enabled = !checkBox1.Checked;
        numericUpDown2.Enabled = !checkBox1.Checked;
        label2.Enabled = !checkBox1.Checked;
        numericUpDown3.Enabled = !checkBox1.Checked;
        label3.Enabled = !checkBox1.Checked;
    }
    public bool isChecked {
        get { return checkBox1.Checked; }
        set { checkBox1.Checked = value; }
    }
    public string ID {
        get { return checkBox1.Text; }
        set { checkBox1.Text = value; }
    }
    public string Label1 {
        get { return label1.Text; }
        set { label1.Text = value; }
    }
    public int Value1 {
        get {
            return checkBox1.Checked ? 0 : (int)(numericUpDown1.Value);
        }
        set {
            if (!checkBox1.Checked)
                numericUpDown1.Value = value;
        }
    }
    public string Label2 {
        get { return label2.Text; }
        set { label2.Text = value; }
    }
    public int Value2 {
        get {
            return checkBox1.Checked ? 0 : (int)(numericUpDown2.Value);
        }
        set {
            if (!checkBox1.Checked)
                numericUpDown2.Value = value;
        }
    }
    public string Label3 {
        get { return label3.Text; }
        set { label3.Text = value; }
    }
    public int Value3 {
        get {
            return checkBox1.Checked ? 0 : (int)(numericUpDown3.Value);
        }
        set {
            if (!checkBox1.Checked)
                numericUpDown3.Value = value;
        }
    }
}
