using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//TODO List:
// 1) MOve SQL to resx file when moved to Athena - Line 21
// 2) Update connection string to connect to Athena database when we go live - Line 50

namespace ScanlanPlanning
{
    public partial class scanlan : Form
    {
        //SQL Statement for the Scanlan Planning listView1
        //TODO: Place into a resource file once it has been moved to Athena



        //static SqlConnection connect = new SqlConnection("Data Source=SCSII06;Initial Catalog=Dawn;Persist Security Info=True;User ID=dawn_test;Password=c&GBYucV7SRQJ8Y_xTgNX_S$=3c?6n95;");
        static SqlConnection connect = new SqlConnection();
        SqlCommand cmd = new SqlCommand(ScanlanPlanning.Properties.Resources.sqlQuery, connect);
        SqlCommand cmd2 = new SqlCommand(ScanlanPlanning.Properties.Resources.vencloseQuery, connect);
        SqlCommand cmd3 = new SqlCommand(ScanlanPlanning.Properties.Resources.bardQuery, connect);


        
        //TODO: Connect to Athena database once application is live and in Athena
        
        public scanlan()
        {
            InitializeComponent();
            loadScanlanPlanningSheet();
            loadVenclosePlanningSheet();
            loadBardPlanningSheet();
        }

        private void scanlan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dawnDataSet.planningData' table. You can move, or remove it, as needed.
            this.planningDataTableAdapter.Fill(this.dawnDataSet.planningData);


        }

        //class to load the Scanlan Planning listView
        private void loadScanlanPlanningSheet()
        {
           // listView1.Groups.Clear();
            listView1.Items.Clear();

            

            try
            {
                    connect.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string prevItem = string.Empty;
                        string family = null;
                       // int row = 1;

                        while (reader.Read())
                        {
                            //Populate the Item to be added to the ListView
                            ListViewItem item = new ListViewItem(reader["WO"].ToString());

                        

                            //Assign item to a group based on Manufacturing Family
                            #region Grouping 
                            family = reader["Mfg Family"].ToString();
                            if (family == "AC Locators")
                            {
                                item.Group = listView1.Groups[0];
                            }
                            else if (family == "AC Locators BNS")
                            {
                                item.Group = listView1.Groups[1];
                            }
                            else if (family == "Loop")
                            {
                                item.Group = listView1.Groups[2];
                            }
                            else if (family == "Loop Plus")
                            {
                                item.Group = listView1.Groups[3];
                            }
                            else if (family == "Loop BNS")
                            {
                                item.Group = listView1.Groups[4];
                            }
                            else if (family == "Paws")
                            {
                                item.Group = listView1.Groups[5];
                            }
                            else if (family == "Paws BNS")
                            {
                                item.Group = listView1.Groups[6];
                            }
                            else if (family == "Pin Caps")
                            {
                                item.Group = listView1.Groups[7];
                            }
                            else if (family == "Punch")
                            {
                                item.Group = listView1.Groups[8];
                            }
                            else if (family == "Punch BNS")
                            {
                                item.Group = listView1.Groups[9];
                            }
                            else if (family == "Radiomark BNS")
                            {
                                item.Group = listView1.Groups[10];
                            }
                            else if (family == "SIP BNS")
                            {
                                item.Group = listView1.Groups[11];
                            }
                            else if (family == "Skin markers")
                            {
                                item.Group = listView1.Groups[12];
                            }
                            else if (family == "Suture Boots")
                            {
                                item.Group = listView1.Groups[13];
                            }
                            else if (family == "Suture Boots BNS")
                            {
                                item.Group = listView1.Groups[14];
                            }
                            else if (family == "Suture Statts")
                            {
                                item.Group = listView1.Groups[15];
                            }
                            else if (family == "Suture Statts BNS")
                            {
                                item.Group = listView1.Groups[16];
                            }
                            else if (family == "Tunneller")
                            {
                                item.Group = listView1.Groups[17];
                            }
                            else if (family == "Tunneller BNS")
                            {
                                item.Group = listView1.Groups[18];
                            }
                            else if (family == "Vein Holders")
                            {
                                item.Group = listView1.Groups[19];
                            }
                            else if (family == "Vein Holders BNS")
                            {
                                item.Group = listView1.Groups[20];
                            }
                            else if (family == "VS approx")
                            {
                                item.Group = listView1.Groups[21];
                            }
                            else if (family == "VS approx BNS")
                            {
                                item.Group = listView1.Groups[22];
                            }
                            else if (family == "VS approx foam")
                            {
                                item.Group = listView1.Groups[23];
                            }
                            else if (family == "VS BNS")
                            {
                                item.Group = listView1.Groups[24];
                            }
                            else if (family == "VS foam")
                            {
                                item.Group = listView1.Groups[25];
                            }
                            else if (family == "VS foam BNS")
                            {
                                item.Group = listView1.Groups[26];
                            }
                            else if (family == "VS glue")
                            {
                                item.Group = listView1.Groups[27];
                            }
                            else if (family == "VS std")
                            {
                                item.Group = listView1.Groups[28];
                            }
                            else if (family == "VS std BNS")
                            {
                                item.Group = listView1.Groups[29];
                            }
                            else
                            {
                                item.Group = listView1.Groups[30];
                            }
                        
                            #endregion

                            item.SubItems.Add(reader["StartQty"].ToString());

                            //Change color of every other line in the ListView to a different color
                         //   if (row % 2 == 0)
                         //   {
                         //       item.BackColor = Color.LightCyan;
                         //   }
                         //   row++;
                       
                            item.SubItems.Add(reader["Assembly"].ToString());
                        // item.SubItems.Add(reader["Mfg Family"].ToString());

                        double cea = 0;
                        double box = 0;

                        if ((reader["ceaPercentage"] != DBNull.Value) && (reader["boxPercentage"] != DBNull.Value))
                        {
                           

                             cea = (Convert.ToDouble(reader["ceaPercentage"]));
                             box = (Convert.ToDouble(reader["boxPercentage"]));
                        }
                        else {
                            cea = 0;
                            box = 0;
                        }


                        if (cea >= .95 && box >= .95)
                        {
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add((Convert.ToDecimal(reader["boxPercentage"])).ToString("#0%"));
                            item.BackColor = Color.LightSeaGreen;
                            listView1.Items.Add(item);
                        }
                        else
                        {

                            item.SubItems.Add(reader["ceaQty"].ToString());

                            //Convert the ceaPercentage value from a decimal to a percentage
                            //If Null, add a blank space
                            if (reader["ceaPercentage"] == DBNull.Value)
                            {
                                item.SubItems.Add(" ");
                            }
                            else
                            {
                                item.SubItems.Add((Convert.ToDecimal(reader["ceaPercentage"])).ToString("#0%"));
                            }

                            item.SubItems.Add(reader["boxQty"].ToString());

                            //Convert the ceaPercentage value from a decimal to a percentage
                            //If Null, add a blank space
                            if (reader["boxPercentage"] == DBNull.Value)
                            {
                                item.SubItems.Add(" ");
                            }
                            else
                            {
                                item.SubItems.Add((Convert.ToDecimal(reader["boxPercentage"])).ToString("#0%"));
                            }


                            listView1.Items.Add(item);

                        }

                        }
                    }
                              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Scanlan Planning Tool Failed to Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connect.Close();
         }

        private void loadVenclosePlanningSheet()
        {
            listView2.Items.Clear();

            try
            {
                connect.Open();

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["WO"].ToString());
                        item.SubItems.Add(reader["StartQty"].ToString());
                        item.SubItems.Add(reader["Assembly"].ToString());

                        double cea = 0;
                        double box = 0;

                        if ((reader["ceaPercentage"] != DBNull.Value) && (reader["boxPercentage"] != DBNull.Value))
                        {


                            cea = (Convert.ToDouble(reader["ceaPercentage"]));
                            box = (Convert.ToDouble(reader["boxPercentage"]));
                        }
                        else
                        {
                            cea = 0;
                            box = 0;
                        }


                        if (cea >= .95 && box >= .95)
                        {
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add((Convert.ToDecimal(reader["boxPercentage"])).ToString("#0%"));
                            item.BackColor = Color.LightSeaGreen;
                            listView2.Items.Add(item);
                        }
                        else
                        {

                            item.SubItems.Add(reader["ceaQty"].ToString());

                            //Convert the ceaPercentage value from a decimal to a percentage
                            //If Null, add a blank space
                            if (reader["ceaPercentage"] == DBNull.Value)
                            {
                                item.SubItems.Add(" ");
                            }
                            else
                            {
                                item.SubItems.Add((Convert.ToDecimal(reader["ceaPercentage"])).ToString("#0%"));
                            }

                            item.SubItems.Add(reader["boxQty"].ToString());

                            //Convert the ceaPercentage value from a decimal to a percentage
                            //If Null, add a blank space
                            if (reader["boxPercentage"] == DBNull.Value)
                            {
                                item.SubItems.Add(" ");
                            }
                            else
                            {
                                item.SubItems.Add((Convert.ToDecimal(reader["boxPercentage"])).ToString("#0%"));
                            }

                            listView2.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Venclose Planning Tool Failed to Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connect.Close();
        }

        private void loadBardPlanningSheet()
        {
            listView3.Items.Clear();

            try
            {
                connect.Open();

                using (SqlDataReader reader = cmd3.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["WO"].ToString());
                        item.SubItems.Add(reader["StartQty"].ToString());
                        item.SubItems.Add(reader["Assembly"].ToString());

                        double cea = 0;
                        double box = 0;

                        if ((reader["ceaPercentage"] != DBNull.Value) && (reader["boxPercentage"] != DBNull.Value))
                        {


                            cea = (Convert.ToDouble(reader["ceaPercentage"]));
                            box = (Convert.ToDouble(reader["boxPercentage"]));
                        }
                        else
                        {
                            cea = 0;
                            box = 0;
                        }


                        if (cea >= .95 && box >= .95)
                        {
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add(" ");
                            item.SubItems.Add((Convert.ToDecimal(reader["boxPercentage"])).ToString("#0%"));
                            item.BackColor = Color.LightSeaGreen;
                            listView3.Items.Add(item);
                        }
                        else
                        {

                            item.SubItems.Add(reader["ceaQty"].ToString());

                            //Convert the ceaPercentage value from a decimal to a percentage
                            //If Null, add a blank space
                            if (reader["ceaPercentage"] == DBNull.Value)
                            {
                                item.SubItems.Add(" ");
                            }
                            else
                            {
                                item.SubItems.Add((Convert.ToDecimal(reader["ceaPercentage"])).ToString("#0%"));
                            }

                            item.SubItems.Add(reader["boxQty"].ToString());

                            //Convert the ceaPercentage value from a decimal to a percentage
                            //If Null, add a blank space
                            if (reader["boxPercentage"] == DBNull.Value)
                            {
                                item.SubItems.Add(" ");
                            }
                            else
                            {
                                item.SubItems.Add((Convert.ToDecimal(reader["boxPercentage"])).ToString("#0%"));
                            }

                            listView3.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bard Planning Tool Failed to Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connect.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
          
