using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SharpClap
{
    public partial class GenericInputDialog : Form
    {
        public int OffsetX = 8;

        public int OffsetY = 8;

        public int MarginY = 7;

        public int IndentX = 2;

        public Dictionary<string, object> Results; 

        public GenericInputDialog()
        {
            InitializeComponent();
        }

        public void Initialize(string header, List<DialogQuestion> questions)
        {
            this.Text = header;
            int positionY = OffsetY;

            foreach (DialogQuestion dq in questions)
            {
                // mmm... dq....

                Size labelSize = TextRenderer.MeasureText(dq.Message, SystemFonts.DefaultFont);
                Label questionLabel = new Label()
                                          {
                                              Text = dq.Message,
                                              Location = new Point(OffsetX, positionY),
                                              Size = labelSize
                                          };
                positionY += questionLabel.Size.Height;
                this.Controls.Add(questionLabel);

                TextBox questionBox = new TextBox()
                                          {
                                              Tag = dq,
                                              Location = new Point(OffsetX + IndentX, positionY),
                                              Text = dq.DefaultValue == null ? "" : dq.DefaultValue.ToString()
                                          };
                positionY += questionBox.Size.Height + MarginY;
                this.Controls.Add(questionBox);
            }

            Button okButton = new Button()
                                  {
                                      Text = "OK", 
                                      AutoSize = true, 
                                      AutoSizeMode = AutoSizeMode.GrowAndShrink, 
                                      Location = new Point(OffsetX, positionY)
                                  };
            okButton.Click += okButton_Click;
            this.AcceptButton = okButton;
            this.Controls.Add(okButton);
        }

        void okButton_Click(object sender, EventArgs e)
        {
            Results = new Dictionary<string, object>();

            foreach (Control c in this.Controls)
            {
                if (c.GetType() != typeof(TextBox)) continue;

                TextBox t = (TextBox)c;

                DialogQuestion dq = (DialogQuestion)t.Tag; // tag was saved on creation

                object result = null;
                try
                {
                    result = Convert.ChangeType(t.Text, dq.ResultType);
                }
                catch (FormatException)
                {
                    MessageBox.Show(String.Format("\"{0}\" is not in a correct format.", dq.Message));
                    t.Focus();
                    return;
                }

                Results.Add(dq.Identifier, result);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GenericInputDialog_Load(object sender, EventArgs e)
        {

        }
    }

    public class DialogQuestion
    {
        public string Identifier;

        public string Message;

        public Type ResultType;

        public object DefaultValue = null;

        public DialogQuestion(string identifier, string message, Type resultType, object defaultValue = null)
        {
            this.Identifier = identifier;
            this.Message = message;
            this.ResultType = resultType;
            this.DefaultValue = defaultValue;
        }
    }
}
