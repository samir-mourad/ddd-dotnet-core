using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SAM.DDD.Infra.Identity
{
    public class IdentityUser
    {
        public virtual int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public string Gender { get; set; }
        public IEnumerable<IdentityProfile> ExcludedProfiles { get; set; } = new List<IdentityProfile>();
        public IEnumerable<IdentityProfile> IncludedProfiles { get; set; } = new List<IdentityProfile>();
        public IEnumerable<IdentityProfile> Profiles { get; set; } = new List<IdentityProfile>();
        public DateTime? Birthdate { get; set; }
        public bool AgreedToReceiveEmail { get; set; }
        public bool AgreedToReceiveSMS { get; set; }
        public bool AgreedToReceiveWhatsApp { get; set; }
        public bool Enabled => true;
        public string ProfileName { get; set; }
        public string ClientId { get; set; }
        public string BusinessEmail { get; set; }
        public string Email { get; set; }
        public string CellPhoneNumber { get; set; }
        public string ResidencialPhoneNumber { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool IuCollaborator { get; set; }
        public IEnumerable<string> Features { get; set; }

        public IEnumerable<Claim> Claims =>
            Profiles.Select(p => new Claim("profile", $"{p.ProfileName}#{p.ClientId}", "http://www.w3.org/2001/XMLSchema#string"));
    }

    public class IdentityProfile
    {
        public string ProfileName { get; set; }
        public string ClientId { get; set; }
    }
}
