﻿namespace Plainion.WhiteRabbit.View
{
    partial class SlimForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SlimForm ) );
            this.panel1 = new System.Windows.Forms.Panel();
            this.myJitterElapsed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.myCategoryList = new System.Windows.Forms.ComboBox();
            this.myTimeElapsed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.myStartRecordBtn = new System.Windows.Forms.Button();
            this.myStopRecordBtn = new System.Windows.Forms.Button();
            this.myPauseRecordBtn = new System.Windows.Forms.Button();
            this.myTaskTxt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add( this.myJitterElapsed );
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Controls.Add( this.myCategoryList );
            this.panel1.Controls.Add( this.myTimeElapsed );
            this.panel1.Controls.Add( this.label4 );
            this.panel1.Controls.Add( this.myStartRecordBtn );
            this.panel1.Controls.Add( this.myStopRecordBtn );
            this.panel1.Controls.Add( this.myPauseRecordBtn );
            this.panel1.Controls.Add( this.myTaskTxt );
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 624, 31 );
            this.panel1.TabIndex = 17;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler( this.panel1_MouseDown );
            // 
            // myJitterElapsed
            // 
            this.myJitterElapsed.AutoSize = true;
            this.myJitterElapsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myJitterElapsed.Location = new System.Drawing.Point( 568, 8 );
            this.myJitterElapsed.Name = "myJitterElapsed";
            this.myJitterElapsed.Size = new System.Drawing.Size( 51, 15 );
            this.myJitterElapsed.TabIndex = 22;
            this.myJitterElapsed.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 530, 8 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 32, 13 );
            this.label3.TabIndex = 23;
            this.label3.Text = "Jitter:";
            // 
            // myCategoryList
            // 
            this.myCategoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.myCategoryList.FormattingEnabled = true;
            this.myCategoryList.Location = new System.Drawing.Point( 61, 5 );
            this.myCategoryList.Name = "myCategoryList";
            this.myCategoryList.Size = new System.Drawing.Size( 150, 21 );
            this.myCategoryList.TabIndex = 25;
            // 
            // myTimeElapsed
            // 
            this.myTimeElapsed.AutoSize = true;
            this.myTimeElapsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTimeElapsed.Location = new System.Drawing.Point( 473, 8 );
            this.myTimeElapsed.Name = "myTimeElapsed";
            this.myTimeElapsed.Size = new System.Drawing.Size( 51, 15 );
            this.myTimeElapsed.TabIndex = 20;
            this.myTimeElapsed.Text = "00:00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 419, 8 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 48, 13 );
            this.label4.TabIndex = 24;
            this.label4.Text = "Elapsed:";
            // 
            // myStartRecordBtn
            // 
            this.myStartRecordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.myStartRecordBtn.Image = ( (System.Drawing.Image)( resources.GetObject( "myStartRecordBtn.Image" ) ) );
            this.myStartRecordBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.myStartRecordBtn.Location = new System.Drawing.Point( 3, 3 );
            this.myStartRecordBtn.Name = "myStartRecordBtn";
            this.myStartRecordBtn.Size = new System.Drawing.Size( 23, 23 );
            this.myStartRecordBtn.TabIndex = 17;
            this.myStartRecordBtn.UseVisualStyleBackColor = true;
            this.myStartRecordBtn.Click += new System.EventHandler( this.myStartRecordBtn_Click );
            // 
            // myStopRecordBtn
            // 
            this.myStopRecordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.myStopRecordBtn.Image = ( (System.Drawing.Image)( resources.GetObject( "myStopRecordBtn.Image" ) ) );
            this.myStopRecordBtn.Location = new System.Drawing.Point( 32, 3 );
            this.myStopRecordBtn.Name = "myStopRecordBtn";
            this.myStopRecordBtn.Size = new System.Drawing.Size( 23, 23 );
            this.myStopRecordBtn.TabIndex = 18;
            this.myStopRecordBtn.UseVisualStyleBackColor = true;
            this.myStopRecordBtn.Click += new System.EventHandler( this.myStopRecordBtn_Click );
            // 
            // myPauseRecordBtn
            // 
            this.myPauseRecordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.myPauseRecordBtn.Image = ( (System.Drawing.Image)( resources.GetObject( "myPauseRecordBtn.Image" ) ) );
            this.myPauseRecordBtn.Location = new System.Drawing.Point( 3, 3 );
            this.myPauseRecordBtn.Name = "myPauseRecordBtn";
            this.myPauseRecordBtn.Size = new System.Drawing.Size( 23, 23 );
            this.myPauseRecordBtn.TabIndex = 19;
            this.myPauseRecordBtn.UseVisualStyleBackColor = true;
            this.myPauseRecordBtn.Click += new System.EventHandler( this.myPauseRecordBtn_Click );
            // 
            // myTaskTxt
            // 
            this.myTaskTxt.Location = new System.Drawing.Point( 217, 5 );
            this.myTaskTxt.Name = "myTaskTxt";
            this.myTaskTxt.Size = new System.Drawing.Size( 196, 20 );
            this.myTaskTxt.TabIndex = 21;
            // 
            // SlimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size( 624, 31 );
            this.ControlBox = false;
            this.Controls.Add( this.panel1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SlimForm";
            this.Text = "SlimForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.SlimForm_MouseDown );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label myJitterElapsed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox myCategoryList;
        private System.Windows.Forms.Label myTimeElapsed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button myStartRecordBtn;
        private System.Windows.Forms.Button myStopRecordBtn;
        private System.Windows.Forms.Button myPauseRecordBtn;
        private System.Windows.Forms.TextBox myTaskTxt;

    }
}