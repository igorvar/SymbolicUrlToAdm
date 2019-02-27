using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;

namespace DataGridViewExtention
{
    //https://msdn.microsoft.com/ru-ru/library/7tas5c80(v=vs.110).aspx
    class NumericColumn : DataGridViewColumn
    {
        //int minVal = 0;
        //int maxVal = 100;
        //public NumericColumn(int MinVal, int MaxVal):this()
        //{
        //    minVal = MinVal;
        //    maxVal = MaxVal;
        //}
        public NumericColumn() : base(new DataGridViewNumericCell())
        {
        }
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }

            set
            {
                // Ensure that the cell used for the template is a NumericCell
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewNumericCell)))
                    throw new InvalidCastException("Must be DataGridViewNumericCell");
                base.CellTemplate = value;
            }
        }
    }

    class DataGridViewNumericCell : DataGridViewTextBoxCell
    {
        public DataGridViewNumericCell() : base()
        {
            //this.Style.Format = "d";
        }
        //public DataGridViewNumericCell(int MinVal, int MaxVal)
        //{

        //}
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericControl ctl = DataGridView.EditingControl as NumericControl;
            // Use the default row value when Value property is null.
            if (this.Value == null)
                ctl.Value = (int)this.DefaultNewRowValue;
            else
                ctl.Value = (int)this.Value;
        }
        public override Type EditType
        {
            get { return typeof(NumericControl); }
        }
        public override Type ValueType
        {
            get { return typeof(int); }
        }
        public override object DefaultNewRowValue
        { get { return 0; } }
    }

    internal class NumericControl : NumericUpDown, IDataGridViewEditingControl
    {
        System.Windows.Forms.DataGridView dgv;
        bool isValueChanged = false;
        public NumericControl()
        {
            this.Maximum = int.MaxValue;
            this.Minimum = -10;
            this.BorderStyle = BorderStyle.None;
        }
        public System.Windows.Forms.DataGridView EditingControlDataGridView
        {
            get { return dgv; }
            set { dgv = value; }
        }
        public object EditingControlFormattedValue
        {
            get { return this.Value.ToString(); }
            set
            {
                if (value is string)
                    try
                    {
                        this.Value = int.Parse((string)value);
                    }
                    catch
                    {
                        this.Value = -7;
                    }
            }
        }
        int rowIndex;
        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }
        public bool EditingControlValueChanged
        {
            get { return isValueChanged; }
            set { isValueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        //=> throw new NotImplementedException();
        {
            get { return false; }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            //throw new NotImplementedException();
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;

            //this.TextAlign = HorizontalAlignment.Right;
            switch (dataGridViewCellStyle.Alignment)
            {

                case DataGridViewContentAlignment.TopLeft:
                case DataGridViewContentAlignment.MiddleLeft:
                case DataGridViewContentAlignment.BottomLeft:
                    this.TextAlign = HorizontalAlignment.Left;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.BottomCenter:
                    this.TextAlign = HorizontalAlignment.Center;
                    break;
                case DataGridViewContentAlignment.TopRight:
                case DataGridViewContentAlignment.NotSet:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.BottomRight:
                    this.TextAlign = HorizontalAlignment.Right;
                    this.UpDownAlign = LeftRightAlignment.Left;
                    break;
                default:
                    this.TextAlign = HorizontalAlignment.Right;
                    break;
            }

        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            //throw new NotImplementedException();
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            //throw new NotImplementedException();
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            //throw new NotImplementedException();
            //nothing ToDo
        }
        protected override void OnValueChanged(EventArgs e)
        {
            isValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }
}
