using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TianQi : Form
    {
        public TianQi()
        {
            InitializeComponent();
        }

        private void TianQi_Load(object sender, EventArgs e)
        {
            cn.com.webxml.www.WeatherWebService wwws = new cn.com.webxml.www.WeatherWebService();
            var re = wwws.getWeatherbyCityName("成都");
            
            string[] tq = re as string[];

            string str = tq[10];
            string[] str_;
            //基于分号分组；
            str_ = str.Split('；');
            //获得温度
            Tq.Font = new Font("微软雅黑", 18);
            Tq.Text = str_[0].Substring(10) + "\r\n";
            Tq.Font = new Font("微软雅黑", 9);
            Tq.AppendText( "成都" + "\r\n");

            Tq.AppendText(str_[1].Substring(6) + "\r\n");

            Tq.AppendText(str_[2] + "\r\n");

            Tq.AppendText (str_[3] + "\r\n");
        }

        private void Wt_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
