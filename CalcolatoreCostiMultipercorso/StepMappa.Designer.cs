namespace CalcolatoreCostiMultipercorso;

partial class StepMappa {
    /// <summary> 
    /// Variabile di progettazione necessaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Pulire le risorse in uso.
    /// </summary>
    /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Codice generato da Progettazione componenti

    /// <summary> 
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent() {
        checkBox1 = new CheckBox();
        label1 = new Label();
        numericUpDown1 = new NumericUpDown();
        label2 = new Label();
        numericUpDown2 = new NumericUpDown();
        label3 = new Label();
        numericUpDown3 = new NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
        SuspendLayout();
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.CheckAlign = ContentAlignment.MiddleRight;
        checkBox1.Location = new Point(1, 4);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(32, 19);
        checkBox1.TabIndex = 0;
        checkBox1.Text = "8";
        checkBox1.UseVisualStyleBackColor = true;
        checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(26, 28);
        label1.Name = "label1";
        label1.Size = new Size(62, 15);
        label1.TabIndex = 58;
        label1.Text = "84 risorsa1";
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new Point(43, 2);
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new Size(40, 23);
        numericUpDown1.TabIndex = 57;
        numericUpDown1.TextAlign = HorizontalAlignment.Right;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(110, 28);
        label2.Name = "label2";
        label2.Size = new Size(62, 15);
        label2.TabIndex = 60;
        label2.Text = "84 risorsa2";
        // 
        // numericUpDown2
        // 
        numericUpDown2.Location = new Point(127, 2);
        numericUpDown2.Name = "numericUpDown2";
        numericUpDown2.Size = new Size(40, 23);
        numericUpDown2.TabIndex = 59;
        numericUpDown2.TextAlign = HorizontalAlignment.Right;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(195, 28);
        label3.Name = "label3";
        label3.Size = new Size(62, 15);
        label3.TabIndex = 62;
        label3.Text = "84 risorsa3";
        // 
        // numericUpDown3
        // 
        numericUpDown3.Location = new Point(212, 2);
        numericUpDown3.Name = "numericUpDown3";
        numericUpDown3.Size = new Size(40, 23);
        numericUpDown3.TabIndex = 61;
        numericUpDown3.TextAlign = HorizontalAlignment.Right;
        // 
        // StepMappa
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(label3);
        Controls.Add(numericUpDown3);
        Controls.Add(label2);
        Controls.Add(numericUpDown2);
        Controls.Add(label1);
        Controls.Add(numericUpDown1);
        Controls.Add(checkBox1);
        Name = "StepMappa";
        Size = new Size(284, 47);
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private CheckBox checkBox1;
    private Label label1;
    private NumericUpDown numericUpDown1;
    private Label label2;
    private NumericUpDown numericUpDown2;
    private Label label3;
    private NumericUpDown numericUpDown3;
}
