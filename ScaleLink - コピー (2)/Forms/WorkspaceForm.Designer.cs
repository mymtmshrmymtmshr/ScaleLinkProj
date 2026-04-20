namespace ScaleLink.Forms;

partial class WorkspaceForm
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
        this.components = new System.ComponentModel.Container();
        this.SuspendLayout();
        // 
        // WorkspaceForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        this.ClientSize = new System.Drawing.Size(1190, 1024);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "WorkspaceForm";
        this.Text = "WorkspaceForm";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.ResumeLayout(false);
    }
}
