namespace AspNet.Identity.IntegerKeys.Config
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AspNetUserRolesConfig
    {
        private readonly Dictionary<AspNetUserRolesColumn, string> _alternateColumns =
            new Dictionary<AspNetUserRolesColumn, string>();

        public static AspNetUserRolesConfig AllCapsWithUnderscores()
        {
            return new AspNetUserRolesConfig()
                .Set(AspNetUserRolesColumn.RoleId, "ROLE_ID")
                .Set(AspNetUserRolesColumn.UserId, "USER_ID");
        }

        public static AspNetUserRolesConfig Pascal()
        {
            return new AspNetUserRolesConfig()
                .Set(AspNetUserRolesColumn.RoleId, "RoleId")
                .Set(AspNetUserRolesColumn.UserId, "UserId");
        }

        public AspNetUserRolesConfig Set(AspNetUserRolesColumn key, string alternateName)
        {
            if (string.IsNullOrWhiteSpace(alternateName))
            {
                throw new ArgumentNullException("alternateName");
            }
            if (_alternateColumns.Values.Any(s => s.Equals(alternateName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException(string.Format("[{0}] has already been configured.", alternateName));
            }

            if (_alternateColumns.ContainsKey(key))
            {
                _alternateColumns.Remove(key);
            }
            _alternateColumns.Add(key, alternateName);

            return this;
        }

        public bool AltExists(AspNetUserRolesColumn key)
        {
            return _alternateColumns.Keys.Any(t => t == key);
        }

        public string AltName(AspNetUserRolesColumn key)
        {
            return _alternateColumns[key];
        }
    }
}