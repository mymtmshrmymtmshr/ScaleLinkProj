namespace ScaleLink.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(30, 30, 30);
        ClientSize = new Size(1264, 985);
        IsMdiContainer = true;
        KeyPreview = true;
        Name = "MainForm";
        Text = "ScaleLink - Œv—Ê•[“ü—Í";
        ResumeLayout(false);
    }
}
