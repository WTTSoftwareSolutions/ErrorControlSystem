﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinFormDotNet45
{
    public partial class FormTest : Form
    {
        private readonly List<Action> _exps;

        public FormTest()
        {
            InitializeComponent();

            _exps = new List<Action>
            {
                () => { throw new ArithmeticException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new ArithmeticException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); },
                () => { throw new Exception("Test"); },
                () => { throw new InvalidExpressionException("Test"); },
                () => { throw new ApplicationException("Test"); },
                () => { throw new SystemException("Test"); }
            };

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // End the program.
            Close();
        }


        private void btnTestHandledFirstExp_Click(object sender, EventArgs e)
        {
            var item = _exps[new Random().Next(0, _exps.Count - 1)];
            try
            {
                item();
            }
            catch (Exception ex)
            {
                ex.Data.Add("test1", "1");
                ex.Data.Add("test2", new Random().Next());
            }
        }

        private void btnTestUnHandledUIExp_Click(object sender, EventArgs e)
        {
            Program.Exp();
        }

        private void btnTestUnHandledThreadExp_Click(object sender, EventArgs e)
        {
            throw new Exception("Test UnHandled Thread Exception");
        }

        private void btnTestUnhandledTaskExp_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            { throw new Exception("Test UnHandled Task Exception"); });
        }

        private void btnThrowExceptExceptions_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Test Except Exceptions");
        }

        private void btnDataException_Click(object sender, EventArgs e)
        {
            try
            {
                var exp = new XExp();
                exp.Data.Add("test data Key", "string Value");
                exp.Data.Add("test data Key2", 25156);
                throw exp;
            }
            catch { }
        }
    }


    class XExp : Exception
    {
        public string MyPublicData1 { get; set; }


        public string MyPublicData2 { get; set; }

        public string MyPublicData3 { get; set; }

        public string MyPublicData4 { get; set; }

        public string MyPublicData5 { get; set; }



        public XExp()
        {
            MyPublicData1 = "I am Public Property 1";
            MyPublicData2 = "I am Public Property 2";
            MyPublicData3 = "I am Public Property 3";
            MyPublicData4 = "I am Public Property 4";
            MyPublicData5 = "I am Public Property 5";

        }
    }
}