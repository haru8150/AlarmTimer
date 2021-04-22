using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmTimer
{
    public partial class FormSet : Form
    {
        //フィールドの設定(FormMainでも参照するのでinternal)
        internal int alarmHour = 0;//アラーム時
        internal int alarmMinute = 0;//アラーム分
        internal int alarmSecond = 0;//アラーム秒

        public FormSet()
        {
            InitializeComponent();
        }

        private void FormSet_Load(object sender, EventArgs e)
        {
            //現在時刻の表示
            numericUpDownAlmHour.Value = DateTime.Now.Hour;
            numericUpDownAlmMnt.Value = DateTime.Now.Minute;


        }

        //NumericUpDownAlmのイベントハンドラ
        private void NumericUpDownAlm_ValueChanged(object sender, EventArgs e)
        {
            //アラーム「時・分」の値が変更されたとき
            radioButtonAlarm.Checked = true;
        }

        private void NumericUpDownTim_ValueChanged(object sender, EventArgs e)
        {
            //タイマー「分・秒」の値が変更されたとき
            radioButtonTimer.Checked = true;
        }

        //OKボタンをクリックしたときの動作
        private void buttonOK_Click(object sender, EventArgs e)
        {
            //アラームのラジオボタンに✔あり
            if(radioButtonAlarm.Checked == true)
            {
                //アラーム時刻の設定
                alarmHour = (int)numericUpDownAlmHour.Value;//decimal⇒intに変換
                alarmMinute = (int)numericUpDownAlmMnt.Value;
                alarmSecond = 0;
            }
            else
            {
                //タイマー時間を現在時刻に加算して、アラーム時刻に設定
                DateTime dtNow = DateTime.Now;
                //加算は（時,分,秒）形式
                TimeSpan addSpan = new TimeSpan(0, (int)numericUpDownAlmMnt.Value,
                    (int)numericUpDownTimSec.Value);

                DateTime setTime = dtNow.Add(addSpan);//加算後の時刻
                alarmHour = setTime.Hour;//加算後のアラーム時
                alarmMinute = setTime.Minute;//加算後のアラーム分
                alarmSecond = setTime.Second;//加算後のアラーム秒

            }
        }
    }
}
