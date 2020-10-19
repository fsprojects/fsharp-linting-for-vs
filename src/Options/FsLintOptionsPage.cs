using System;
using System.ComponentModel;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;

namespace FSharpLintVs
{
    [Guid(GuidString)]
    public class FsLintOptionsPage : DialogPage
    {
        public const string GuidString = "74927147-72e8-4b47-a70d-5568807d6879";

        [Category("Performance")]
        [DisplayName("Throttle Interval (ms)")]
        [Description("Wait for this much time after an edit before running the linter. " +
            "Lower values will make it more responsive, but increase CPU usage. " +
            "High values might make the linter seem sluggish.")]
        public int Throttle { get; set; } = 200;

        [Category("Checking")]
        [DisplayName("Type-Check Files")]
        [Description("Type check the file in the current project. " +
            "Regular linting requires only the AST. " +
            "Turning this on enables a few type-checked rules, but makes the linter slower.")]
        public bool TypeCheck { get; set; } = false;

        public event Action Applied;
        protected override void OnApply(PageApplyEventArgs e)
        {
            if(e.ApplyBehavior == ApplyKind.Apply)
            {
                Applied?.Invoke();
            }

            base.OnApply(e);
        }

    }
}
