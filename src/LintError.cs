using FSharpLint.Application;
using FSharpLint.Framework;
using Microsoft.FSharp.Core;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using System.Collections.Generic;
using System.Text;

namespace FSharpLintVs
{
    public class LintError
    {
        public readonly SnapshotSpan Span;
        public readonly LintProjectInfo Project;
        private readonly Suggestion.LintWarning LintWarning;

        public int NextIndex = -1;

        public string Tooltip => $"{LintWarning.RuleIdentifier}: {LintWarning.Details.Message}";

        public string Identifier => LintWarning.RuleIdentifier;

        public string Name => LintWarning.RuleName;

        public string Message => LintWarning.Details.Message;

        public string HelpUrl => $"https://fsprojects.github.io/FSharpLint/how-tos/rules/{Identifier}.html";

        public bool HasSuggestedFix => this.LintWarning.Details.SuggestedFix?.Value?.Value != null;

        public Suggestion.SuggestedFix GetSuggestedFix() => LintWarning.Details.SuggestedFix.Value.Value.Value;

        public int Line => LintWarning.Details.Range.StartLine - 1;

        public int Column => LintWarning.Details.Range.StartColumn;

        public string ErrorText => LintWarning.ErrorText;

        public string ReplacementText
        {
            get
            {
                var fix = GetSuggestedFix();
                if (fix == null)
                    return "";

                var startColumn = fix.FromRange.StartColumn;
                return ErrorText.Remove(startColumn, fix.FromRange.EndColumn - startColumn).Insert(startColumn, fix.ToText);
            }
        }

        public LintError(SnapshotSpan span, Suggestion.LintWarning lintWarning, LintProjectInfo project)
        {
            this.Span = span;
            this.LintWarning = lintWarning;
            this.Project = project;
        }

        public static LintError Clone(LintError error)
        {
            return new LintError(error.Span, error.LintWarning, error.Project);
        }

        public static LintError CloneAndTranslateTo(LintError error, ITextSnapshot newSnapshot)
        {
            var newSpan = error.Span.TranslateTo(newSnapshot, SpanTrackingMode.EdgeExclusive);

            // We want to only translate the error if the length of the error span did not change (if it did change, it would imply that
            // there was some text edit inside the error and, therefore, that the error is no longer valid).
            return (newSpan.Length == error.Span.Length)
                   ? new LintError(newSpan, error.LintWarning, error.Project)
                   : null;
        }

    }
}
