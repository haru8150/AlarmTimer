using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmTimer
{
    public partial class FormMain : Form
    {

        private bool alarmSetFlag = false;//アラームセット中フラグ
        private int alarmHour = 0;//アラーム時
        private int alarmMinute = 0;//アラーム分
        private int alarmSecond = 0;//アラーム秒

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();//タイマーを起動(1秒ごとにtickイベント発生)
            labelStatus.Text = "";
            labelDate.Text = DateTime.Today.ToString("yyyy年MM月dd日(ddd)");//現在の日付を西暦年月日と曜日の文字列に変換
            labelTime.Text = DateTime.Now.ToLongTimeString();//HH:MM:DD形式

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelTime.Text = now.ToLongTimeString();
            labelDate.Text = DateTime.Today.ToString("yyyy年MM月dd日(ddd)");

            //アラーム設定中
            if(alarmSetFlag == true)
            {
                //設定時刻になった
                if(alarmHour == now.Hour && 
                    alarmMinute == now.Minute &&
                    alarmSecond == now.Second)
                {
                    alarmSetFlag = false;//アラームフラグをOFF
                    MessageBox.Show("時間ですよ！", "アラーム", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelStatus.Text = "";
                }
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            //FormSetのフォームをモーダルダイアログで開く
            FormSet formSet = new FormSet();
            //formSet.ShowDialog();
            //FormSetのフォームのOkボタンを押したとき
            if (formSet.ShowDialog() == DialogResult.OK)
            {
                //アラームの設定
                alarmSetFlag = true;
                alarmHour = formSet.alarmHour;//FormSetのフォームの加算後のアラーム時を取り出す
                alarmMinute = formSet.alarmMinute;//FormSetのフォーム加算後のアラーム分を取り出す
                alarmSecond = formSet.alarmSecond;//FormSetのフォーム加算後のアラーム秒を取り出す
                labelStatus.Text = "♪" + alarmHour.ToString("00") + ":"
                    + alarmMinute.ToString("00") + ":"
                    + alarmSecond.ToString("00");
            }
            formSet.Dispose();
        }

        //リセットボタンのイベント
        private void button1_Click(object sender, EventArgs e)
        {
            alarmSetFlag = false;
            labelStatus.Text = "";
        }
    }
}
