//-------------------------------------------------------------------------------
// OPC-DA .NET Interface
// =====================
// Sample program using the Wrapper for OPC Data Access Server Interface Functions
// 
// Author:   KHa    Sep-6-02
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
using System.Data;

using OPC;
using OPCDA;
using OPCDA.NET;




namespace VCSSampleClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class SampleClient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbSrvStatus;
		private System.Windows.Forms.TreeView tvItems;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
	
		private System.Windows.Forms.ComboBox cbServerName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader colItem;
		private System.Windows.Forms.ColumnHeader colValue;
		private System.Windows.Forms.ColumnHeader colQuality;
		
		
		
		
		// ----------------------------------------- application data
		OpcServer		Srv = null ;
		SyncIOGroup		ReadWriteGroup ;
		RefreshGroup	AsyncRefrGroup ;
		private System.Windows.Forms.ListView lvRefresh;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnDisconnect;
		BrowseTree		ItemTree ;			// TreeNode browse class 


		public SampleClient()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// init
			tbSrvStatus.Text = "Disconnected" ;
			OpcServerBrowser SrvList = new OpcServerBrowser();
			string[] Servers ;
			SrvList.GetServerList( out Servers );
			if( Servers != null )
			{
				cbServerName.Items.AddRange( Servers );
				cbServerName.SelectedIndex = 0 ;
			}
  		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( Srv != null ) 
			{
				AsyncRefrGroup.Dispose();
				ReadWriteGroup.Dispose();
				Srv.Disconnect();
				Srv = null ;
				tbSrvStatus.Text = "Disconnected" ;
			}

			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SampleClient));
			this.label1 = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbSrvStatus = new System.Windows.Forms.TextBox();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.tvItems = new System.Windows.Forms.TreeView();
			this.cbServerName = new System.Windows.Forms.ComboBox();
			this.lvRefresh = new System.Windows.Forms.ListView();
			this.colItem = new System.Windows.Forms.ColumnHeader();
			this.colValue = new System.Windows.Forms.ColumnHeader();
			this.colQuality = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select from browsed Servers";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(8, 64);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(80, 24);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(248, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Status";
			// 
			// tbSrvStatus
			// 
			this.tbSrvStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSrvStatus.Location = new System.Drawing.Point(240, 32);
			this.tbSrvStatus.Multiline = true;
			this.tbSrvStatus.Name = "tbSrvStatus";
			this.tbSrvStatus.ReadOnly = true;
			this.tbSrvStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSrvStatus.Size = new System.Drawing.Size(328, 48);
			this.tbSrvStatus.TabIndex = 4;
			this.tbSrvStatus.Text = "";
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Location = new System.Drawing.Point(144, 64);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(80, 24);
			this.btnDisconnect.TabIndex = 5;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// tvItems
			// 
			this.tvItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tvItems.ImageIndex = -1;
			this.tvItems.Location = new System.Drawing.Point(8, 112);
			this.tvItems.Name = "tvItems";
			this.tvItems.SelectedImageIndex = -1;
			this.tvItems.Size = new System.Drawing.Size(216, 232);
			this.tvItems.TabIndex = 6;
			//this.tvItems.Click += new System.EventHandler(this.tvItems_Click);
			this.tvItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvItems_AfterSelect);
			// 
			// cbServerName
			// 
			this.cbServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbServerName.Location = new System.Drawing.Point(8, 32);
			this.cbServerName.Name = "cbServerName";
			this.cbServerName.Size = new System.Drawing.Size(216, 20);
			this.cbServerName.TabIndex = 8;
			// 
			// lvRefresh
			// 
			this.lvRefresh.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.colItem,
																						this.colValue,
																						this.colQuality});
			this.lvRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lvRefresh.FullRowSelect = true;
			this.lvRefresh.GridLines = true;
			this.lvRefresh.Location = new System.Drawing.Point(240, 112);
			this.lvRefresh.Name = "lvRefresh";
			this.lvRefresh.Size = new System.Drawing.Size(328, 232);
			this.lvRefresh.TabIndex = 9;
			this.lvRefresh.View = System.Windows.Forms.View.Details;
			// 
			// colItem
			// 
			this.colItem.Text = "ItemId";
			this.colItem.Width = 150;
			// 
			// colValue
			// 
			this.colValue.Text = "Value";
			this.colValue.Width = 100;
			// 
			// colQuality
			// 
			this.colQuality.Text = "Quality";
			this.colQuality.Width = 70;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Server Address Space";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(240, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(256, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "Read Group with asynchronous Refresh";
			// 
			// SampleClient
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 358);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
			   this.label4,
			   this.label3,
			   this.lvRefresh,
			   this.cbServerName,
			   this.tvItems,
			   this.btnDisconnect,
			   this.tbSrvStatus,
			   this.label2,
			   this.btnConnect,
			   this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SampleClient";
			this.Text = "Sample .Net OPC DA CLient";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SampleClient());
		}



		/// <summary>
		/// Button Click 'CONNECT'
		/// Connects to the OPC Server and initializes the controls and data structures
		/// - Get server status and display it
		/// - browse the server and display all items inall branches
		/// - add a group for synchronous read/write and create an empty collection of added items
		/// - add a group for asynchronous refresh and create an empty collection of added items
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConnect_Click(object sender, System.EventArgs e)
		{
         int rtc ;
         if( Srv == null )
         {
            try
            {
               tbSrvStatus.Text = "Connecting to OPC server..." ;
               tvItems.Nodes.Clear();
               this.Update();
               Srv = new OpcServer() ;
               rtc = Srv.Connect( cbServerName.Text );
               if( HRESULTS.Failed(rtc) )
               {
                  tbSrvStatus.Text = "Error " + rtc.ToString() + " at connecting to server." ;
                  Srv = null ;
                  return;
               }
            }
            catch( Exception ex )      // handling COM exceptions
            {
               tbSrvStatus.Text = ex.Message ;
               Srv = null;
               return;
            }

            SERVERSTATUS stat ;
            rtc = Srv.GetStatus( out stat );
            if( HRESULTS.Succeeded(rtc) )
               tbSrvStatus.Text = stat.eServerState.ToString();
            else
            {
               tbSrvStatus.Text = "Error "+rtc.ToString()+" at GetStatus." ;
               Srv = null;
               return;
            }
            tvItems.Nodes.Clear();
            ItemTree = new BrowseTree( Srv );
            rtc = ItemTree.CreateTree();	   // Browse server from root
            if( HRESULTS.Succeeded(rtc) )
            {
               tvItems.ImageList = ItemTree.ImageList ;
               tvItems.Nodes.AddRange( ItemTree.Root() );	
            }
            else
            {
               tbSrvStatus.Text = Srv.GetErrorString( rtc, 0 );
               Srv = null;
               return;
            }

            try
            {
               ReadWriteGroup = new SyncIOGroup( Srv ) ;
               DataChangeEventHandler dch = new DataChangeEventHandler( this.DataChangeHandler );
               AsyncRefrGroup = new RefreshGroup( Srv, dch );
        
               btnConnect.Enabled = false ;
               cbServerName.Enabled = false ;
               btnDisconnect.Enabled = true ;
            }
            catch( OPCException ex )
            {
               tbSrvStatus.Text = ex.Message ;
               Srv = null;
               return;
            }
         }
		}

		private void btnDisconnect_Click(object sender, System.EventArgs e)
		{
			if( Srv != null ) 
			{
				AsyncRefrGroup.Dispose();
				ReadWriteGroup.Dispose();
				Srv.Disconnect();
				Srv = null ;
				tbSrvStatus.Text = "Disconnected" ;
			}
			btnConnect.Enabled = true ;
			cbServerName.Enabled = true ;
			btnDisconnect.Enabled = false ;
			tvItems.Nodes.Clear();
			lvRefresh.Items.Clear();
		}


		private void tvItems_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if( e.Action == TreeViewAction.ByMouse )
			{
				TreeNode sel =  e.Node ;
				if( ItemTree.isItem( sel ) )
				{
					string selItem  = ItemTree.ItemName( sel ) ;
					ItemRW hd = new ItemRW( ReadWriteGroup, AsyncRefrGroup, ItemTree, selItem, lvRefresh );
					hd.Location = this.Location + new Size( 150,200);
					hd.ShowDialog();
					tvItems.SelectedNode = null;
				}
			}
		}

		private void tvItems_Click(object sender, System.EventArgs e)
		{
			TreeNode sel =  tvItems.SelectedNode ;
			if( ( sel != null ) &&ItemTree.isItem( sel ) )
			{
				string selItem  = ItemTree.ItemName( sel ) ;
				ItemRW hd = new ItemRW( ReadWriteGroup, AsyncRefrGroup, ItemTree, selItem, lvRefresh );
				hd.Location = this.Location + new Size( 150,200);
				hd.ShowDialog();
			}
		}



		//================================================================================
		// Handles Data change callbacks
		public void DataChangeHandler( object sender, DataChangeEventArgs e )
		{
         if( this.InvokeRequired )
         {
            this.BeginInvoke( new DataChangeEventHandler( DataChangeHandler ), new object[] { sender, e });
            return;
         }
         for( int i=0 ; i < e.sts.Length ; ++i )
			{
				int hnd		= e.sts[i].HandleClient;
				object val	= e.sts[i].DataValue ;
				string qt	= AsyncRefrGroup.GetQualityString( e.sts[i].Quality );
				DateTime dt = DateTime.FromFileTime(e.sts[i].TimeStamp );

				OPCDA.NET.ItemDef item = AsyncRefrGroup.FindClientHandle( hnd );
				if( item != null )
				{
					string name = item.OpcIDef.ItemID ;
					for( int l=0 ; l<lvRefresh.Items.Count ; ++l )
					{
						if( lvRefresh.Items[l].Text == name )
						{
							while( lvRefresh.Items[l].SubItems.Count > 1 )
								lvRefresh.Items[l].SubItems.RemoveAt(1);
							lvRefresh.Items[l].SubItems.Add( val.ToString() );
							lvRefresh.Items[l].SubItems.Add( qt );
						}
					}
				}
			}
		}


	}
}
