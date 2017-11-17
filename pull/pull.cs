using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace pull
{
    public partial class pull : Form
    {
        ReportDocument ReportDoc;
        public pull()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            ReportDoc =new ReportDocument();

            ReportDoc.Load("D:\\pull\\pull\\CrystalReport1.rpt");//�����ļ����ھ���·��
            /****************************************************
             * ���pullģʽ���ܵ�½����
             * ****************************************************/
            TableLogOnInfo logonInfo=new TableLogOnInfo();
            foreach(CrystalDecisions.CrystalReports.Engine.Table tb in ReportDoc.Database.Tables)
            {
                logonInfo=tb.LogOnInfo;
                logonInfo.ConnectionInfo.ServerName = "yafei"; //������
                logonInfo.ConnectionInfo.DatabaseName = "db_CRM";//���ݿ���
                logonInfo.ConnectionInfo.UserID = "sa";//���ݿ��û���   
                logonInfo.ConnectionInfo.Password="123456";//����
                tb.ApplyLogOnInfo(logonInfo);
            }
            crystalReportViewer2.ReportSource = ReportDoc;
        }
    }
}