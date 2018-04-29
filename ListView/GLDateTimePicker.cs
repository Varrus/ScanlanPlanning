using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;


namespace GlacialComponents.Controls
{
	/// <summary>
	/// Summary description for GLDateTimePicker.
	/// </summary>
	internal class GLDateTimePicker : System.Windows.Forms.DateTimePicker, GLEmbeddedControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private bool ClearDate { get; set; }

		public GLDateTimePicker()
		{
            ClearDate = false;
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // GLDateTimePicker
            // 
            this.CustomFormat = "MM/dd/yyyy";
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GLDateTimePicker_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

		#region GLEmbeddedControl Members

		public GLItem	 Item 
		{ 
			get
			{
				return m_item;
			}
			set
			{
				m_item = value;
			}
		}

		public GLSubItem SubItem
		{ 
			get
			{
				return m_subItem;
			}
			set
			{
				m_subItem = value;
			}
		}

		public GlacialList	 ListControl
		{ 
			get
			{
				return m_Parent;
			}
			set
			{
				m_Parent = value;
			}
		}

		public string GLReturnText()
		{
			return this.Text;
		}

		protected GLItem m_item = null;
		protected GLSubItem m_subItem = null;
		protected GlacialList m_Parent = null;

		public bool GLLoad(GLItem item, GLSubItem subItem, GlacialList listctrl)
		{
			//this.Format = DateTimePickerFormat.Long;
			try
			{
				m_item = item;
				m_subItem = subItem;
				m_Parent = listctrl;

				this.Text = subItem.Text;

				//this.Value = subItem.Text;
			}
			catch ( Exception ex )
			{
				Debug.WriteLine( ex.ToString() );

				this.Text = DateTime.Now.ToString();
			}

			return true;
		}

		public void GLUnload()
		{
            if (ClearDate)
                m_subItem.Text = string.Empty;
            else
			    m_subItem.Text = this.Text;
		}



		#endregion

        private void GLDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q && Control.ModifierKeys == Keys.Control)
            {
                ClearDate = true;
            }
        }

	}
}
