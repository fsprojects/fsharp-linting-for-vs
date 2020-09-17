using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace FSharpLintVs
{
    public class LintProjectInfo
    {
        public Project Project { get; }
        
        public string ProjectName { get; }

        // Performance will be improved if you "prebox" your System.Guid by, 
        // in your Microsoft.VisualStudio.Shell.TableManager.ITableEntry
        // or Microsoft.VisualStudio.Shell.TableManager.ITableEntriesSnapshot, having a
        // member variable:
        // private object boxedProjectGuid = projectGuid;
        // and returning boxedProjectGuid instead of projectGuid.
        public object ProjectGuid { get; }

        public IVsHierarchy Hierarchy { get; }
        
        public EnvDTE.Solution Solution { get; }

        public LintProjectInfo(EnvDTE.Project project, EnvDTE.Solution solution, Guid projectGuid, IVsHierarchy hierarchy)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();

            Project = project;
            ProjectName = project.Name;
            ProjectGuid = projectGuid;
            Hierarchy = hierarchy;
            Solution = solution;
            
        }

    }
}
