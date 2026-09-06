using LTools.Common.Model;
using LTools.Common.UIElements;
using LTools.SDK;
using System;
using System.Data;
using Primo.Project;

namespace Primo.SDKSample
{
    public class RemoveEmptyRowsBack : PrimoComponentSimple<MyElementUI>
    {
        private const string CGroupName = "Data/Tables";

        public override string GroupName
        {
            get => CGroupName;
            protected set { }
        }

        private DataTable prop1;

        [LTools.Common.Model.Serialization.StoringProperty]
        [System.ComponentModel.Category("SDK")]
        [System.ComponentModel.DisplayName("DataTable")]
        public DataTable Prop1
        {
            get { return prop1; }
            set
            {
                prop1 = value;
                InvokePropertyChanged(this, "Prop1");
            }
        }

        public RemoveEmptyRowsBack(IWFContainer container) : base(container)
        {
            sdkComponentName = "Remove Empty Rows";
            sdkComponentHelp = "Removes empty rows from a DataTable.";
            InitClass(container);
        }

        public override ExecutionResult SimpleAction(ScriptingData sd)
        {
            try
            {
                DataTable table = Prop1;

                for (int i = table.Rows.Count - 1; i >= 0; i--)
                {
                    bool empty = true;

                    foreach (object value in table.Rows[i].ItemArray)
                    {
                        if (value != null && value.ToString().Trim() != "")
                        {
                            empty = false;
                            break;
                        }
                    }

                    if (empty)
                        table.Rows.RemoveAt(i);
                }

                return new ExecutionResult() {SuccessMessage = "Done"};
            }
            catch (Exception ex)
            {
                return new ExecutionResult()
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}