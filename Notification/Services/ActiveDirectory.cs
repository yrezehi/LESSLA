﻿using System.DirectoryServices.AccountManagement;

namespace SeqNotification.Services
{
    public class ActiveDirectory
    {
        public List<string> TargetEmails(params string[] groupNames)
        {
            List<string> emails = new List<string>();

            using (var context = CreatePrincipalContext())
            {
                foreach(string groupName in groupNames)
                {
                    using (var group = GroupPrincipal.FindByIdentity(context, groupName))
                    {
                        if (group != null)
                        {
                            var users = group.GetMembers(false);

                            foreach (UserPrincipal user in users)
                            {
                                emails.Add(user.EmailAddress);
                            }
                        }
                    }
                }
            }

            return emails;
        }

        private PrincipalContext CreatePrincipalContext()
        {
            return new PrincipalContext(ContextType.Domain, "domainName");
        }
    }
}
