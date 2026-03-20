using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML.Voice;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Upload_page
{
    public partial class Upload_Page : Form
    {
        DataTable datatable;

        public Upload_Page()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RejLable.Visible = false;
            btnsendsms.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xls; *xlsx) | *xls; *xlsx";
            openFileDialog.Title = "Select a File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblFilePath.Text = openFileDialog.FileName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            {
                String FilePath = lblFilePath.Text;
                if (!String.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
                {
                    LoadExcelData(FilePath);
                }
                else
                {
                    MessageBox.Show("Please Enter a Valid file Path or Check if File Exists", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            dataGridView1.Visible = true;
            RejLable.Visible = false;
            btnsendsms.Visible = false;

            try
            {
                string FilePath = lblFilePath.Text;
                if (!String.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
                {
                    LoadExcelData(FilePath);
                    RejLable.Text = "Rejected Student Details";
                    RejLable.Visible = true;
                    btnsendsms.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please Enter a Valid file Path or Check if File Exists", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadExcelData(string FilePath)
        {
            try
            {
                using (var stream = File.Open(FilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });
                        DataTable table = result.Tables[0];
                        DataTable filteredData = new DataTable();
                        filteredData.Columns.Add("Application No.");
                        filteredData.Columns.Add("Mobile No.");
                        filteredData.Columns.Add("Reason for Rejaction");
                        filteredData.Columns.Add("Scheme Name");
                        foreach (DataRow row in table.Rows)
                        {
                            String appId = row["Application No"].ToString();
                            string mobileNo = row["Beneficiary Mobile No"].ToString();
                            string reason = row["Reason"].ToString();
                            string schemeName = row["Scheme"].ToString();
                            filteredData.Rows.Add(appId, mobileNo, reason, schemeName);
                        }
                        dataGridView1.DataSource = filteredData;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Twilio credentials
                string accountSid = "YOUR_TWILIO_SID";
                string authToken = "YOUR_TWILIO_AUTH_TOKEN";
                string fromPhoneNumber = "+15179968104"; // Your Twilio number

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the phone number from the selected row
                    string toPhoneNumber = dataGridView1.SelectedRows[0].Cells["Mobile No."].Value.ToString();

                    // Ensure that the phone number has the correct E.164 format
                    if (!toPhoneNumber.StartsWith("+"))
                    {
                        toPhoneNumber = "+91" + toPhoneNumber; // Add the country code for India (+91), or modify this for other countries
                    }

                    string messageBody = "Subject: Scholarship Application Status (EBC/SC/ST/OBC)\r\n\r\nDear Student,\r\n\r\nYour application for the EBC/SC/ST/OBC scholarship has not been approved. For more details,visit Mahadbt site or please contact the scholarship office.\r\n\r\nSGMCOE";

                    // Initialize Twilio client
                    TwilioClient.Init(accountSid, authToken);

                    // Send SMS
                    var message = MessageResource.Create(
                        body: messageBody,
                        from: new PhoneNumber(fromPhoneNumber),
                        to: new PhoneNumber(toPhoneNumber)
                    );

                    MessageBox.Show($"SMS sent successfully to {toPhoneNumber}: {message.Sid}", "SMS Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a student from the list to send an SMS.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle error
                MessageBox.Show($"Error sending SMS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExcelData1(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet();
                DataTable dataTable = result.Tables[0];
                dataGridView1.DataSource = dataTable;
            }
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    } 
}


