using System;

namespace Area51
{
    public class Floor
    {
        public string Name { get; set; }

        public SecurityLevel MinimumSecurityClearance { get; private set; }
        
        public Floor(String name, SecurityLevel authorizationLevel)
        {
            this.Name = name;
            this.MinimumSecurityClearance = authorizationLevel;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}