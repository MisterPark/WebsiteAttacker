using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsiteAttacker
{
  public partial class Form1 : Form
  {
    Timer timer = new Timer();
    WebAttacker attacker = new WebAttacker();

    public Form1()
    {
      InitializeComponent();

      timer.Interval = 1000;
      timer.Tick += LogProc;
      timer.Start();
      
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Hexadecimal hexa = Hexadecimal.From(attacker.MacAddress);
      hexa.Increase();
      attacker.ChangeMacAddress(hexa.ToString(12));
    }

    private void LogProc(object sender, EventArgs e)
    {
      List<string> logs = Logger.Dequeue();
      foreach (var log in logs)
      {
        listBox1.Items.Add(log);
      }
    }
  }
}
