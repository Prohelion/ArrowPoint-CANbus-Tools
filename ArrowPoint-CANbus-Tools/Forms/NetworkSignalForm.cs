using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class NetworkSignalForm : Form
    {
        private const string uint8Txt = "uint8";
        private const string int8Txt = "int8";
        private const string uint16Txt = "uint16";
        private const string int16Txt = "int16";
        private const string uint32Txt = "uint32";
        private const string int32Txt = "int32";
        private const string floatSingleTxt = "floatSingle";
        private const string floatDoubleTxt = "floatDouble";

        private Configuration.Signal signal;

        public bool IsOk { get; set; } = false;
        public Configuration.Signal Signal
        {
            get
            {
                signal.name = SignalNameTextBox.Text;
                signal.offset = OffsetComboBox.SelectedItem.ToString();
                signal.Value.type = ValueType;
                signal.length = LengthFromType.ToString();                
                return signal;
            }
        }
        private Configuration.ValueType ValueType
        {
            get
            {
                switch (TypeComboBox.ToString().ToLower())
                {
                    case uint8Txt: return Configuration.ValueType.unsigned;
                    case int8Txt: return Configuration.ValueType.signed;
                    case uint16Txt: return Configuration.ValueType.unsigned;
                    case int16Txt: return Configuration.ValueType.signed;
                    case uint32Txt: return Configuration.ValueType.unsigned;
                    case int32Txt: return Configuration.ValueType.signed;
                    case floatSingleTxt: return Configuration.ValueType.single;
                    case floatDoubleTxt: return Configuration.ValueType.@double;
                    default: return 0;
                }

            }
        }
        private int LengthFromType {
            get
            {
                switch (TypeComboBox.SelectedItem.ToString().ToLower())
                {                    
                    case uint8Txt: return 1;
                    case int8Txt: return 1;
                    case uint16Txt: return 2;
                    case int16Txt: return 2;
                    case uint32Txt: return 4;
                    case int32Txt: return 4;
                    case floatSingleTxt: return 4;
                    case floatDoubleTxt: return 4;
                    default: return 0;
                }
            }
        }
       
        private void SetTypeCombox(Configuration.ValueType valueType, int length)
        {
            string textToSelect = null;

            switch (valueType)
            {
                case Configuration.ValueType.unsigned:
                    if (length == 1) textToSelect = uint8Txt;
                    if (length == 2) textToSelect = uint16Txt;
                    if (length == 4) textToSelect = uint32Txt;
                    break;
                case Configuration.ValueType.signed: 
                    if (length == 1) textToSelect = int8Txt;
                    if (length == 2) textToSelect = int16Txt;
                    if (length == 4) textToSelect = int32Txt;
                    break;
                case Configuration.ValueType.single:
                    if (length == 4) textToSelect = floatSingleTxt;
                    break;
                case Configuration.ValueType.@double:
                    if (length == 4) textToSelect = floatDoubleTxt;
                    break;
            }

            if (textToSelect != null)
            {
                TypeComboBox.SelectedIndex = TypeComboBox.FindStringExact(textToSelect);
            }
        }

        private void InitialiseCombo()
        {
            TypeComboBox.Items.Clear();
            TypeComboBox.Items.Add(uint8Txt);
            TypeComboBox.Items.Add(int8Txt);
            TypeComboBox.Items.Add(uint16Txt);
            TypeComboBox.Items.Add(int16Txt);
            TypeComboBox.Items.Add(uint32Txt);
            TypeComboBox.Items.Add(int32Txt);
            TypeComboBox.Items.Add(floatSingleTxt);
            TypeComboBox.Items.Add(floatDoubleTxt);
            TypeComboBox.SelectedIndex = 0;
        }

        public NetworkSignalForm()
        {
            InitializeComponent();
            InitialiseCombo();
        }

        public NetworkSignalForm(Configuration.Signal signal)
        {
            InitializeComponent();
            InitialiseCombo();

            this.signal = signal;

            SignalNameTextBox.Text = signal.name;
            OffsetComboBox.SelectedIndex = OffsetComboBox.FindStringExact(signal.offset);
            int length = Int32.Parse(signal.length);
            SetTypeCombox(signal.Value.type, length);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (SignalNameTextBox.Text.Length > 0) IsOk = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
