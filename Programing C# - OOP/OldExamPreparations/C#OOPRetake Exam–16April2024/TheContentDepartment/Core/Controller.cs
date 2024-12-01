using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private ResourceRepository resources;
        private MemberRepository members;

        public Controller()
        {
            this.resources = new ResourceRepository();
            this.members = new MemberRepository();
        }
        public string JoinTeam(string memberType, string memberName, string path)
        {
            ITeamMember teamMember = null;
            if (memberType == nameof(TeamLead))
            {
                teamMember = new TeamLead(memberName, path);
            }
            else if (memberType == nameof(ContentMember))
            {
                teamMember = new ContentMember(memberName, path);
            }
            else
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (this.members.Models.Any(m => m.Path == teamMember.Path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }

            if (this.members.Models.Any(m => m.Name == teamMember.Name))
            {
                return string.Format(OutputMessages.MemberExists, memberName);

            }

            this.members.Add(teamMember);
            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);

        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            IResource resource = null;
            if (!ResourceTypeValidate(resourceType))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            ITeamMember[] members = this.members.Models.Where(m => m.GetType().Name == nameof(ContentMember)).ToArray();
            ITeamMember matchMember = null;
            bool isValidated = false;

            foreach (var member in members)
            {
                if (member.Path == path)
                {
                    if (member.InProgress.Contains(resourceName))
                    {
                        return string.Format(OutputMessages.ResourceExists, resourceName);
                    }
                    isValidated = true;
                    matchMember = member;

                }
            }

            if (!isValidated) return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);

            resource = GenerateResourse(resourceType, resourceName, matchMember.Name);
            matchMember.WorkOnTask(resourceName);
            this.resources.Add(resource);
            return string.Format(OutputMessages.ResourceCreatedSuccessfully, matchMember.Name, resourceType, resourceName);

        }

        public string LogTesting(string memberName)
        {
            ITeamMember memberToFind = this.members.TakeOne(memberName);
            if (memberToFind == null)
                return string.Format(OutputMessages.WrongMemberName);

            IResource highhesPriorResource = this.resources.Models
                .Where(r => r.Creator == memberName && r.IsTested == false).OrderBy(r => r.Priority).FirstOrDefault();

            if (highhesPriorResource == null) return string.Format(OutputMessages.NoResourcesForMember, memberName);

            ITeamMember teamLead = this.members.Models.Where(tl => tl.GetType().Name == nameof(TeamLead)).FirstOrDefault();

            memberToFind.FinishTask(highhesPriorResource.Name);
            teamLead.WorkOnTask(highhesPriorResource.Name);
            highhesPriorResource.Test();
            return string.Format(OutputMessages.ResourceTested, highhesPriorResource.Name);
        }


        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resourceToFind = this.resources.Models.Where(resources => resources.Name == resourceName).FirstOrDefault()!;

            if (!resourceToFind.IsTested)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            ITeamMember teamLead = this.members.Models.Where(tl => tl.GetType().Name == nameof(TeamLead)).FirstOrDefault()!;

            if (isApprovedByTeamLead)
            {
                resourceToFind.Approve();
                teamLead.FinishTask(resourceToFind.Name); // ????????/
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }

            if (resourceToFind.IsTested) resourceToFind.Test();
            //TODO the resorce should go back to the ContentMembers??
            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
        }



        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();

            IResource[] approvedResource = this.resources.Models.Where(r => r.IsApproved).ToArray();
            ITeamMember teamLeader = this.members.Models.Where(tl => tl.GetType().Name == nameof(TeamLead)).FirstOrDefault()!;
            ITeamMember[] contentMemebers = this.members.Models.Where(tl => tl.GetType().Name != nameof(TeamLead)).ToArray();

            sb.AppendLine("Finished Tasks:");
            foreach (var resource in approvedResource)
            {
                sb.AppendLine($"--{resource.ToString()}");
            }
            sb.AppendLine("Team Report:");
            sb.AppendLine($"--{teamLeader.ToString()}");
            foreach(var member in contentMemebers)
            {
                sb.AppendLine(member.ToString());
            }

            return sb.ToString().Trim();

        }

        private bool ResourceTypeValidate(string resourceType)
        {
            if (resourceType == nameof(Exam))
            {
                return true;
            }
            else if (resourceType == nameof(Workshop))
            {
                return true;
            }
            else if (resourceType == nameof(Presentation))
            {
                return true;
            }

            return false;
        }

        private IResource? GenerateResourse(string resourceType, string resourceName, string creatorName)
        {
            switch (resourceType)
            {
                case $"{nameof(Exam)}": return new Exam(resourceName, creatorName);
                case $"{nameof(Workshop)}": return new Workshop(resourceName, creatorName);
                case $"{nameof(Presentation)}": return new Presentation(resourceName, creatorName);
                default: return null;
            }
        }
    }
}
