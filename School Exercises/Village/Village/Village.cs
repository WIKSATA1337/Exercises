using System;
using System.Collections.Generic;
using System.Text;

namespace Village
{
    public class Village
    {
        private string _name;
        private string _location;
        private int _resource;
        List<Peasant> peasants = new List<Peasant>();

        public string Name
        {
            get { return _name; }
            private set {
                if (value.Length < 2 || value.Length > 40)
                {
                    throw new ArgumentException("Name should be between 2 and 40 characters!");
                }
                if (value.Contains(":"))
                {
                    throw new ArgumentException("Name must not contain \";\" ");
                }

                _name = value; 
            }
        }
        public string Location
        {
            get { return _location; }
            private set {
                if (value.Length < 3 || value.Length > 45)
                {
                    throw new ArgumentException("Location should be between 3 and 45 characters!");
                }
                _location = value;
            }
        }
        public int Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

        public Village(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public void AddPeasant(Peasant peasant)
        {
            peasants.Add(peasant);
        }

        public int PassDay()
        {
            int productivitySum = 0;

            foreach (var peasant in peasants)
            {
                productivitySum += peasant.Productivity;
            }

            _resource += productivitySum;

            return productivitySum;
        }

        public List<Peasant> KillPeasants(int count)
        {
            List<Peasant> killed = new List<Peasant>();
            int removedCount = 0;
            foreach (var peasant in peasants)
            {
                removedCount++;
                if (removedCount <= count)
                {
                    killed.Add(peasant);
                }
            }

            if (peasants.Count < count)
            {
                for (int i = 0; i < peasants.Count; i++)
                {
                    peasants.Remove(peasants[i]);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    peasants.Remove(peasants[i]);
                }
            }

            return killed;
        }

        public List<Peasant> GetPeasants()
        {
            return peasants;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Village - {Name} ({Location})");
            sb.AppendLine($"Resources – ({this.Resource})");
            sb.AppendLine($"Peasants – ({this.peasants.Count})");

            foreach (var peasant in peasants)
            {
                sb.AppendLine(peasant.ToString());
            }

            return sb.ToString();
        }
    }
}
