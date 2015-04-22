//-------------------------------------------------------------------------------
// OPC-DA .NET Interface
// =====================
// Sample program using the Wrapper for OPC Data Access Server Interface Functions
// Write Item Dialog
//
// Author:   KHa    Sep-6-02
//
// 10-22-02  KHa	Read from Device Checkbox added
//
// Copyright 2002	Advosol Inc.   (www.advosol.com)
// All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//-------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using OPC;
using OPCDA;
using OPCDA.NET;



namespace VCSSampleClient
{
	/// <summary>
	/// Summary description for WriteItem.
	/// </summary>
	public class ItemRW : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbItemId;
		private System.Windows.Forms.TextBox tbValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.TextBox tbQuality;
		private System.Windows.Forms.TextBox tbTimestamp;
		private System.Windows.Forms.TextBox tbError;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbAccRights;
		private System.Windows.Forms.TextBox tbDatatype;
		private System.Windows.Forms.TextBox tbServerHandle;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbReadN;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnWrite;
		private System.Windows.Forms.Button btnAddRefresh;
		private System.Windows.Forms.Button btnReadN;
		
		ListView		lvRefresh ;
		ItemDef			ItemData ;
		SyncIOGroup		Grp ;
		private System.Windows.Forms.CheckBox cbReadDevice;
		RefreshGroup	rGrp ;

		//------------------------------------------------------ constructor
		public ItemRW( SyncIOGroup grp, RefreshGroup rgrp, 
						BrowseTree iTree, string itemId, ListView refresh )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Grp  = grp ;
			rGrp = rgrp ;
			lvRefresh = refresh;
			tbItemId.Text = itemId ;		// show item name
			ItemData = Grp.Item( itemId );
			if( ItemData == null )
				Grp.Add( itemId );				// add item if not found

			ItemData = Grp.Item( itemId );
			if( ItemData == null )
			{
				tbError.Text		= "Item not found.";
				btnRead.Enabled	= false ;
				btnWrite.Enabled	= false ;
			}
			else
			{
				tbAccRights.Text	= ItemData.OpcIInfo.AccessRights.ToString();
				tbDatatype.Text		= ItemData.OpcIInfo.CanonicalDataType.ToString();
				tbServerHandle.Text = ItemData.OpcIInfo.HandleServer.ToString();
				if( (ItemData.OpcIRslt != null ) && (ItemData.OpcIRslt.DataValue != null ) )
				{
					tbValue.Text		= ItemData.OpcIRslt.DataValue.ToString();
					tbQuality.Text		= ItemData.OpcIRslt.Quality.ToString();
					tbTimestamp.Text	= ItemData.OpcIRslt.TimeStamp.ToString();
					tbError.Text		= ItemData.OpcIRslt.Error.ToString();
				}
				btnRead.Enabled	= true ;
				btnWrite.Enabled	= true ;
			}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.tbItemId = new System.Windows.Forms.TextBox();
         this.tbValue = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.btnOK = new System.Windows.Forms.Button();
         this.tbQuality = new System.Windows.Forms.TextBox();
         this.tbTimestamp = new System.Windows.Forms.TextBox();
         this.tbError = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.tbAccRights = new System.Windows.Forms.TextBox();
         this.tbDatatype = new System.Windows.Forms.TextBox();
         this.tbServerHandle = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.btnRead = new System.Windows.Forms.Button();
         this.btnWrite = new System.Windows.Forms.Button();
         this.btnAddRefresh = new System.Windows.Forms.Button();
         this.btnReadN = new System.Windows.Forms.Button();
         this.tbReadN = new System.Windows.Forms.TextBox();
         this.label9 = new System.Windows.Forms.Label();
         this.cbReadDevice = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // tbItemId
         // 
         this.tbItemId.Location = new System.Drawing.Point(48, 16);
         this.tbItemId.Name = "tbItemId";
         this.tbItemId.ReadOnly = true;
         this.tbItemId.Size = new System.Drawing.Size(248, 18);
         this.tbItemId.TabIndex = 0;
         this.tbItemId.Text = "";
         // 
         // tbValue
         // 
         this.tbValue.Location = new System.Drawing.Point(368, 16);
         this.tbValue.Name = "tbValue";
         this.tbValue.Size = new System.Drawing.Size(176, 18);
         this.tbValue.TabIndex = 1;
         this.tbValue.Text = "";
         // 
         // label1
         // 
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label1.Location = new System.Drawing.Point(8, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 16);
         this.label1.TabIndex = 2;
         this.label1.Text = "ItemId";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label2
         // 
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label2.Location = new System.Drawing.Point(320, 16);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(40, 16);
         this.label2.TabIndex = 4;
         this.label2.Text = "Value";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // btnOK
         // 
         this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.btnOK.Location = new System.Drawing.Point(480, 168);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(64, 24);
         this.btnOK.TabIndex = 5;
         this.btnOK.Text = "OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // tbQuality
         // 
         this.tbQuality.Location = new System.Drawing.Point(368, 48);
         this.tbQuality.Name = "tbQuality";
         this.tbQuality.Size = new System.Drawing.Size(176, 18);
         this.tbQuality.TabIndex = 6;
         this.tbQuality.Text = "";
         // 
         // tbTimestamp
         // 
         this.tbTimestamp.Location = new System.Drawing.Point(368, 80);
         this.tbTimestamp.Name = "tbTimestamp";
         this.tbTimestamp.Size = new System.Drawing.Size(176, 18);
         this.tbTimestamp.TabIndex = 7;
         this.tbTimestamp.Text = "";
         // 
         // tbError
         // 
         this.tbError.AcceptsReturn = true;
         this.tbError.Location = new System.Drawing.Point(248, 112);
         this.tbError.Multiline = true;
         this.tbError.Name = "tbError";
         this.tbError.ReadOnly = true;
         this.tbError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.tbError.Size = new System.Drawing.Size(296, 40);
         this.tbError.TabIndex = 8;
         this.tbError.Text = "";
         // 
         // label3
         // 
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label3.Location = new System.Drawing.Point(320, 48);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(40, 16);
         this.label3.TabIndex = 9;
         this.label3.Text = "Quality";
         this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label4
         // 
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label4.Location = new System.Drawing.Point(304, 80);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(56, 16);
         this.label4.TabIndex = 10;
         this.label4.Text = "Timestamp";
         this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label5
         // 
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label5.Location = new System.Drawing.Point(208, 112);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(32, 16);
         this.label5.TabIndex = 11;
         this.label5.Text = "Error";
         this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // tbAccRights
         // 
         this.tbAccRights.Location = new System.Drawing.Point(120, 48);
         this.tbAccRights.Name = "tbAccRights";
         this.tbAccRights.ReadOnly = true;
         this.tbAccRights.Size = new System.Drawing.Size(179, 18);
         this.tbAccRights.TabIndex = 12;
         this.tbAccRights.Text = "";
         // 
         // tbDatatype
         // 
         this.tbDatatype.Location = new System.Drawing.Point(120, 80);
         this.tbDatatype.Name = "tbDatatype";
         this.tbDatatype.ReadOnly = true;
         this.tbDatatype.Size = new System.Drawing.Size(176, 18);
         this.tbDatatype.TabIndex = 13;
         this.tbDatatype.Text = "";
         // 
         // tbServerHandle
         // 
         this.tbServerHandle.Location = new System.Drawing.Point(120, 112);
         this.tbServerHandle.Name = "tbServerHandle";
         this.tbServerHandle.ReadOnly = true;
         this.tbServerHandle.Size = new System.Drawing.Size(72, 18);
         this.tbServerHandle.TabIndex = 14;
         this.tbServerHandle.Text = "";
         // 
         // label6
         // 
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label6.Location = new System.Drawing.Point(8, 80);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(104, 16);
         this.label6.TabIndex = 15;
         this.label6.Text = "Canonical Datatype";
         this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label7
         // 
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label7.Location = new System.Drawing.Point(32, 48);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(80, 16);
         this.label7.TabIndex = 16;
         this.label7.Text = "Access Right";
         this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label8
         // 
         this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label8.Location = new System.Drawing.Point(32, 112);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(80, 16);
         this.label8.TabIndex = 17;
         this.label8.Text = "Server handle";
         this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // btnRead
         // 
         this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.btnRead.Location = new System.Drawing.Point(128, 168);
         this.btnRead.Name = "btnRead";
         this.btnRead.Size = new System.Drawing.Size(88, 24);
         this.btnRead.TabIndex = 18;
         this.btnRead.Text = "Read";
         this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
         // 
         // btnWrite
         // 
         this.btnWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.btnWrite.Location = new System.Drawing.Point(224, 168);
         this.btnWrite.Name = "btnWrite";
         this.btnWrite.Size = new System.Drawing.Size(80, 24);
         this.btnWrite.TabIndex = 19;
         this.btnWrite.Text = "Write";
         this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
         // 
         // btnAddRefresh
         // 
         this.btnAddRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.btnAddRefresh.Location = new System.Drawing.Point(328, 168);
         this.btnAddRefresh.Name = "btnAddRefresh";
         this.btnAddRefresh.Size = new System.Drawing.Size(128, 24);
         this.btnAddRefresh.TabIndex = 20;
         this.btnAddRefresh.Text = "Add to Refresh Group";
         this.btnAddRefresh.Click += new System.EventHandler(this.btnAddRefresh_Click);
         // 
         // btnReadN
         // 
         this.btnReadN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.btnReadN.Location = new System.Drawing.Point(8, 168);
         this.btnReadN.Name = "btnReadN";
         this.btnReadN.Size = new System.Drawing.Size(96, 24);
         this.btnReadN.TabIndex = 21;
         this.btnReadN.Text = "Read  N times";
         this.btnReadN.Click += new System.EventHandler(this.btnReadN_Click);
         // 
         // tbReadN
         // 
         this.tbReadN.Location = new System.Drawing.Point(40, 144);
         this.tbReadN.Name = "tbReadN";
         this.tbReadN.Size = new System.Drawing.Size(64, 18);
         this.tbReadN.TabIndex = 22;
         this.tbReadN.Text = "100";
         this.tbReadN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label9
         // 
         this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label9.Location = new System.Drawing.Point(16, 144);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(16, 16);
         this.label9.TabIndex = 23;
         this.label9.Text = "N";
         this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // cbReadDevice
         // 
         this.cbReadDevice.Location = new System.Drawing.Point(128, 144);
         this.cbReadDevice.Name = "cbReadDevice";
         this.cbReadDevice.Size = new System.Drawing.Size(104, 16);
         this.cbReadDevice.TabIndex = 24;
         this.cbReadDevice.Text = "Read from Device";
         // 
         // ItemRW
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 11);
         this.ClientSize = new System.Drawing.Size(554, 200);
         this.ControlBox = false;
         this.Controls.Add(this.cbReadDevice);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.tbReadN);
         this.Controls.Add(this.btnReadN);
         this.Controls.Add(this.btnAddRefresh);
         this.Controls.Add(this.btnWrite);
         this.Controls.Add(this.btnRead);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.tbServerHandle);
         this.Controls.Add(this.tbDatatype);
         this.Controls.Add(this.tbAccRights);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.tbError);
         this.Controls.Add(this.tbTimestamp);
         this.Controls.Add(this.tbQuality);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.tbValue);
         this.Controls.Add(this.tbItemId);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.Name = "ItemRW";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
         this.Text = "Read / Write the selected  Item";
         this.ResumeLayout(false);

      }
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		//-------------------------------------------------------------------------------
		private void btnRead_Click(object sender, System.EventArgs e)
		{
			OPCItemState Rslt ;
			OPCDATASOURCE dsrc = OPCDATASOURCE.OPC_DS_CACHE ;
			if( cbReadDevice.Checked )	dsrc = OPCDATASOURCE.OPC_DS_DEVICE ;
			int rtc = Grp.Read( dsrc, ItemData, out Rslt );
		
			if( HRESULTS.Succeeded(rtc) )		// read from OPC server successful
			{
            if( Rslt != null )
            {
               if( HRESULTS.Succeeded(Rslt.Error) )	// item read successful
               {
                  tbValue.Text		= Rslt.DataValue.ToString();
                  tbError.Text		= "";
               }
               else			// the item could not be read
               {
                  tbValue.Text		= "";
                  tbError.Text		= Grp.GetErrorString( Rslt.Error );
               }
               // show item Quality and timestamp
               tbQuality.Text		= Grp.GetQualityString( Rslt.Quality );
               DateTime  dt = DateTime.FromFileTime( Rslt.TimeStamp );
               tbTimestamp.Text	= dt.ToString();
            }
            else
            {
               tbError.Text		= "No data could be read";
            }
			}
			else		// OPC server read error
			{
				tbValue.Text		= "";		// clear the previously displayed
				tbQuality.Text		= "";		//     item data
				tbTimestamp.Text	= "";
				tbError.Text		= Grp.GetErrorString( rtc );
			}

		}

		//---------------------------------------------------------------------------
      private void btnWrite_Click(object sender, System.EventArgs e)
      {
         object val = tbValue.Text ;
         int rtc = Grp.Write( ItemData, val );
         tbQuality.Text		= "";		// clear the displayed read
         tbTimestamp.Text	= "";		// quality and timestamp
         tbError.Text		= Grp.GetErrorString( rtc );
      }


		//--------------------------------------------------------------------------
		private void btnAddRefresh_Click(object sender, System.EventArgs e)
		{
			int rtc = rGrp.Add( ItemData.OpcIDef.ItemID );	// add to list and OPC group
			if( HRESULTS.Failed(rtc) )
				tbError.Text		= Grp.GetErrorString( rtc );
			else
			{	// show the item in the refresh list view
				lvRefresh.Items.Add( ItemData.OpcIDef.ItemID );
			}
		}


		//------------------------------------------------------------------------
		// Read the selected item N times and show the measured access time
		private void btnReadN_Click(object sender, System.EventArgs e)
		{
			OPCItemState Rslt ;
			tbValue.Text		= "";		// clear the previously displayed
			tbQuality.Text		= "";		//     item data
			tbTimestamp.Text	= "";
			tbError.Text		= "";
			btnReadN.Enabled   = false ;
			btnRead.Enabled    = false ;
			btnWrite.Enabled   = false ;
			btnAddRefresh.Enabled = false ;
			btnOK.Enabled		= false ;
			this.Update();

			// read the item once through the SyncIO group to make sure it' added
			OPCDATASOURCE dsrc = OPCDATASOURCE.OPC_DS_CACHE ;
			if( cbReadDevice.Checked )	dsrc = OPCDATASOURCE.OPC_DS_DEVICE ;
			int rtc = Grp.Read( dsrc, ItemData, out Rslt );
			if( HRESULTS.Failed(rtc) )
				tbError.Text		= Grp.GetErrorString( rtc );
			if( HRESULTS.Failed(Rslt.Error) )
				tbError.Text		= Grp.GetErrorString( Rslt.Error );
			if( HRESULTS.Failed(Rslt.Error) || HRESULTS.Failed(rtc ) )
			{
				btnReadN.Enabled   = true ;
				btnRead.Enabled    = true ;
				btnWrite.Enabled   = true ;
				btnAddRefresh.Enabled = true ;
				btnOK.Enabled		= true ;
				return;
			}

			// read the item n times using the OPC sync read function
			int loops = Convert.ToInt32( tbReadN.Text );	// number of reads from textbox
			int[] hnd = new int[1] ;
			hnd[0] = ItemData.OpcIInfo.HandleServer ;
			OPCItemState[] iState = new OPCItemState[1];
            DateTime sTim = DateTime.Now;

			for( int i=0; i<loops ; ++i )
			{
				rtc = Grp.OpcGrp.Read( OPCDATASOURCE.OPC_DS_CACHE, hnd, out iState );
			}
		
			DateTime eTim = DateTime.Now;
			if( HRESULTS.Failed(rtc))
				tbError.Text		= Grp.GetErrorString( rtc );
			else
				tbError.Text		= Grp.GetErrorString( iState[0].Error );

			TimeSpan durT = eTim - sTim ;
			double dur1 = durT.TotalMilliseconds / loops ;
			tbError.Text = tbError.Text + "\r\nPerformance:  " + dur1.ToString( "F")
				+ " ms per read call" ;
			tbValue.Text		= iState[0].DataValue.ToString();
			tbQuality.Text		= Grp.GetQualityString( iState[0].Quality );
			DateTime  dt = DateTime.FromFileTime( iState[0].TimeStamp );
			tbTimestamp.Text	= dt.ToString();

			btnReadN.Enabled   = true ;
			btnRead.Enabled    = true ;
			btnWrite.Enabled   = true ;
			btnAddRefresh.Enabled = true ;
			btnOK.Enabled		= true ;
		}


	}
}
