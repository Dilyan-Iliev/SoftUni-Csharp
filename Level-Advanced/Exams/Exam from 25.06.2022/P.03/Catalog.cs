using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name)
                || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            if (NeededRenovators <= renovators.Count)
            {
                return "Renovators are no more needed.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);

            if (renovator != null)
            {
                renovators.Remove(renovator);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> filteredRenovators = renovators.Where(x => x.Type == type).ToList();

            if (filteredRenovators.Count == 0)
            {
                return 0;
            }

            renovators.RemoveAll(x => x.Type == type);
            return filteredRenovators.Count;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);

            if (renovator != null)
            {
                renovator.Hired = true;
                return renovator;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> filtered = renovators.Where(x => x.Days >= days).ToList();

            return filtered;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators.Where(x => x.Hired == false))
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
