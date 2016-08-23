using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using IronPython.Runtime;



namespace LenguagesProject
{
    public partial class formulario : Form
    {
        private ScriptEngine m_engine = Python.CreateRuntime();
        private ScriptScope m_scope = null;
                

        public formulario()
        {
            InitializeComponent();
            textBox1.AcceptsTab = true;                      
            m_scope = m_engine.CreateScope();
            m_scope.SetVariable("txt", textBox2);



        }
      
        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {

                textBox2.Clear();
                string code = textBox1.Text.Trim();
                ScriptSource source = m_engine.CreateScriptSourceFromString(code, SourceCodeKind.SingleStatement);
                textBox2.Text = source.Execute(m_scope);

                




            }
            catch (Exception ex)
            {
                textBox2.Text = ex.ToString();
            }
        }
    }
}
