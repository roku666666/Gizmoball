namespace GizmoBall
{
    partial class FormEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
            this.plBoard = new System.Windows.Forms.Panel();
            this.plToolBox = new System.Windows.Forms.Panel();
            this.btnAsb = new System.Windows.Forms.Button();
            this.btnFlpR = new System.Windows.Forms.Button();
            this.btnFlpL = new System.Windows.Forms.Button();
            this.btnBpTrgL_U = new System.Windows.Forms.Button();
            this.btnBpTrgR_U = new System.Windows.Forms.Button();
            this.btnBall = new System.Windows.Forms.Button();
            this.btnBpCir = new System.Windows.Forms.Button();
            this.btnBpTrgR_D = new System.Windows.Forms.Button();
            this.btnBpTrgL_D = new System.Windows.Forms.Button();
            this.btnBpSqr = new System.Windows.Forms.Button();
            this.plToolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBoard
            // 
            this.plBoard.Location = new System.Drawing.Point(20, 13);
            this.plBoard.Name = "plBoard";
            this.plBoard.Size = new System.Drawing.Size(410, 410);
            this.plBoard.TabIndex = 0;
            this.plBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.plBoard_Paint);
            // 
            // plToolBox
            // 
            this.plToolBox.Controls.Add(this.btnAsb);
            this.plToolBox.Controls.Add(this.btnFlpR);
            this.plToolBox.Controls.Add(this.btnFlpL);
            this.plToolBox.Controls.Add(this.btnBpTrgL_U);
            this.plToolBox.Controls.Add(this.btnBpTrgR_U);
            this.plToolBox.Controls.Add(this.btnBall);
            this.plToolBox.Controls.Add(this.btnBpCir);
            this.plToolBox.Controls.Add(this.btnBpTrgR_D);
            this.plToolBox.Controls.Add(this.btnBpTrgL_D);
            this.plToolBox.Controls.Add(this.btnBpSqr);
            this.plToolBox.Location = new System.Drawing.Point(434, 15);
            this.plToolBox.Name = "plToolBox";
            this.plToolBox.Size = new System.Drawing.Size(150, 311);
            this.plToolBox.TabIndex = 1;
            // 
            // btnAsb
            // 
            this.btnAsb.BackgroundImage = global::GizmoBall.Properties.Resources.absorber;
            this.btnAsb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsb.Location = new System.Drawing.Point(13, 135);
            this.btnAsb.Name = "btnAsb";
            this.btnAsb.Size = new System.Drawing.Size(120, 20);
            this.btnAsb.TabIndex = 4;
            this.btnAsb.UseVisualStyleBackColor = true;
            // 
            // btnFlpR
            // 
            this.btnFlpR.BackgroundImage = global::GizmoBall.Properties.Resources.FliperRightDown;
            this.btnFlpR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFlpR.Location = new System.Drawing.Point(85, 161);
            this.btnFlpR.Name = "btnFlpR";
            this.btnFlpR.Size = new System.Drawing.Size(30, 80);
            this.btnFlpR.TabIndex = 3;
            this.btnFlpR.UseVisualStyleBackColor = true;
            // 
            // btnFlpL
            // 
            this.btnFlpL.BackgroundImage = global::GizmoBall.Properties.Resources.FliperLeftDown;
            this.btnFlpL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFlpL.Location = new System.Drawing.Point(13, 161);
            this.btnFlpL.Name = "btnFlpL";
            this.btnFlpL.Size = new System.Drawing.Size(30, 80);
            this.btnFlpL.TabIndex = 3;
            this.btnFlpL.UseVisualStyleBackColor = true;
            // 
            // btnBpTrgL_U
            // 
            this.btnBpTrgL_U.BackgroundImage = global::GizmoBall.Properties.Resources.TriUpLeft;
            this.btnBpTrgL_U.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBpTrgL_U.Location = new System.Drawing.Point(49, 27);
            this.btnBpTrgL_U.Name = "btnBpTrgL_U";
            this.btnBpTrgL_U.Size = new System.Drawing.Size(30, 30);
            this.btnBpTrgL_U.TabIndex = 1;
            this.btnBpTrgL_U.UseVisualStyleBackColor = true;
            // 
            // btnBpTrgR_U
            // 
            this.btnBpTrgR_U.BackgroundImage = global::GizmoBall.Properties.Resources.TriUpRight;
            this.btnBpTrgR_U.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBpTrgR_U.Location = new System.Drawing.Point(85, 27);
            this.btnBpTrgR_U.Name = "btnBpTrgR_U";
            this.btnBpTrgR_U.Size = new System.Drawing.Size(30, 30);
            this.btnBpTrgR_U.TabIndex = 1;
            this.btnBpTrgR_U.UseVisualStyleBackColor = true;
            // 
            // btnBall
            // 
            this.btnBall.BackgroundImage = global::GizmoBall.Properties.Resources.ball;
            this.btnBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBall.Location = new System.Drawing.Point(13, 99);
            this.btnBall.Name = "btnBall";
            this.btnBall.Size = new System.Drawing.Size(30, 30);
            this.btnBall.TabIndex = 1;
            this.btnBall.UseVisualStyleBackColor = true;
            // 
            // btnBpCir
            // 
            this.btnBpCir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBpCir.BackgroundImage")));
            this.btnBpCir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBpCir.Location = new System.Drawing.Point(13, 63);
            this.btnBpCir.Name = "btnBpCir";
            this.btnBpCir.Size = new System.Drawing.Size(30, 30);
            this.btnBpCir.TabIndex = 1;
            this.btnBpCir.UseVisualStyleBackColor = true;
            // 
            // btnBpTrgR_D
            // 
            this.btnBpTrgR_D.BackgroundImage = global::GizmoBall.Properties.Resources.TriDownRight;
            this.btnBpTrgR_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBpTrgR_D.Location = new System.Drawing.Point(85, 63);
            this.btnBpTrgR_D.Name = "btnBpTrgR_D";
            this.btnBpTrgR_D.Size = new System.Drawing.Size(30, 30);
            this.btnBpTrgR_D.TabIndex = 1;
            this.btnBpTrgR_D.UseVisualStyleBackColor = true;
            // 
            // btnBpTrgL_D
            // 
            this.btnBpTrgL_D.BackgroundImage = global::GizmoBall.Properties.Resources.TriDownLeft;
            this.btnBpTrgL_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBpTrgL_D.Location = new System.Drawing.Point(49, 63);
            this.btnBpTrgL_D.Name = "btnBpTrgL_D";
            this.btnBpTrgL_D.Size = new System.Drawing.Size(30, 30);
            this.btnBpTrgL_D.TabIndex = 1;
            this.btnBpTrgL_D.UseVisualStyleBackColor = true;
            // 
            // btnBpSqr
            // 
            this.btnBpSqr.BackgroundImage = global::GizmoBall.Properties.Resources.square;
            this.btnBpSqr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBpSqr.Location = new System.Drawing.Point(13, 27);
            this.btnBpSqr.Name = "btnBpSqr";
            this.btnBpSqr.Size = new System.Drawing.Size(30, 30);
            this.btnBpSqr.TabIndex = 0;
            this.btnBpSqr.UseVisualStyleBackColor = true;
            this.btnBpSqr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBpSqr_MouseDown);
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.plToolBox);
            this.Controls.Add(this.plBoard);
            this.Name = "FormEdit";
            this.Text = "FormEdit";
            this.plToolBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plBoard;
        private System.Windows.Forms.Panel plToolBox;
        private System.Windows.Forms.Button btnBpSqr;
        private System.Windows.Forms.Button btnBpTrgL_D;
        private System.Windows.Forms.Button btnBpTrgL_U;
        private System.Windows.Forms.Button btnBpTrgR_U;
        private System.Windows.Forms.Button btnBpCir;
        private System.Windows.Forms.Button btnBpTrgR_D;
        private System.Windows.Forms.Button btnBall;
        private System.Windows.Forms.Button btnFlpR;
        private System.Windows.Forms.Button btnFlpL;
        private System.Windows.Forms.Button btnAsb;
    }
}