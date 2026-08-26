using LTools.Common.Model;
using LTools.Common.UIElements;
using LTools.SDK;
using System;
using Primo.Project;

namespace Primo.SDKSample
{
    public class StringEqualsBack : PrimoComponentSimple<MyElementUI>
    {
        private const string CGroupName = "Data/Strings";

        private string prop1;
        private string prop2;
        private string result;

        public override string GroupName
        {
            get => CGroupName;
            protected set { }
        }

        public StringEqualsBack(IWFContainer container) : base(container)
        {
            sdkComponentName = "String Equals";
            sdkComponentHelp = "Checks if two strings are equal.";
            InitClass(container);
        }

        [LTools.Common.Model.Serialization.StoringProperty]
        [LTools.Common.Model.Studio.ValidateReturnScript(DataType = typeof(string))]
        public string Prop1
        {
            get => prop1;
            set { prop1 = value; InvokePropertyChanged(this, "Prop1"); }
        }

        [LTools.Common.Model.Serialization.StoringProperty]
        [LTools.Common.Model.Studio.ValidateReturnScript(DataType = typeof(string))]
        public string Prop2
        {
            get => prop2;
            set { prop2 = value; InvokePropertyChanged(this, "Prop2"); }
        }

        [LTools.Common.Model.Serialization.StoringProperty]
        [LTools.Common.Model.Studio.ValidateReturnScript(DataType = typeof(bool))]
        public string Result
        {
            get => result;
            set { result = value; InvokePropertyChanged(this, "Result"); }
        }

        public override ExecutionResult SimpleAction(ScriptingData sd)
        {
            try
            {
                string a = GetPropertyValue<string>(Prop1, "Prop1", sd);
                string b = GetPropertyValue<string>(Prop2, "Prop2", sd);

                SetVariableValue(Result, string.Equals(a, b), typeof(bool), sd);

                return new ExecutionResult() { SuccessMessage = "Done" };
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