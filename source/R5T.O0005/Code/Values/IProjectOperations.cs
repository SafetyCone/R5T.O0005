using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0172;
using R5T.T0179.Extensions;
using R5T.T0195;


namespace R5T.O0005
{
    [ValuesMarker]
    public partial interface IProjectOperations : IValuesMarker
    {
        public F0056.IProjectOperations StringlyTyped => F0056.ProjectOperations.Instance;


        public async Task Add_ProjectReferences(
            IProjectFilePath projectFilePath,
            IEnumerable<IProjectFileReference> projectFileReferences)
        {
            var values = projectFileReferences.Get_Values();

            await Instances.ProjectFileOperator.AddProjectReferences_Idempotent(
                projectFilePath.Value,
                values);

            await StringlyTyped.UpdateSolutions(
                projectFilePath.Value);
        }

        public Task Add_ProjectReferences(
            IProjectFilePath projectFilePath,
            params IProjectFileReference[] projectFileReferences)
        {
            return this.Add_ProjectReferences(
                projectFilePath,
                projectFileReferences.AsEnumerable());
        }

        public Task Add_ProjectReference(
            IProjectFilePath projectFilePath,
            IProjectFileReference projectFileReference)
        {
            return this.Add_ProjectReferences(
                projectFilePath,
                projectFileReference);
        }

        public async Task Add_ProjectReferences_WithoutSolutionUpdate(
            IProjectFilePath projectFilePath,
            IEnumerable<IProjectFileReference> projectFileReferences)
        {
            var values = projectFileReferences.Get_Values();

            await Instances.ProjectFileOperator.AddProjectReferences_Idempotent(
                projectFilePath.Value,
                values);
        }

        public Task Add_ProjectReferences_WithoutSolutionUpdate(
            IProjectFilePath projectFilePath,
            params IProjectFileReference[] projectFileReferences)
        {
            return this.Add_ProjectReferences_WithoutSolutionUpdate(
                projectFilePath,
                projectFileReferences.AsEnumerable());
        }

        public Task Add_ProjectReference_WithoutSolutionUpdate(
            IProjectFilePath projectFilePath,
            IProjectFileReference projectFileReference)
        {
            return this.Add_ProjectReferences_WithoutSolutionUpdate(
                projectFilePath,
                projectFileReference);
        }
    }
}
