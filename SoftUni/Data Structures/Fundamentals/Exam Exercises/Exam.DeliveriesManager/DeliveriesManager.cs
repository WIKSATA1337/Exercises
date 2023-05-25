using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, List<Package>> assignedPackagesToDeliverers;
        private Dictionary<string, Package> packages;
        private Dictionary<string, Deliverer> deliverers;

        public DeliveriesManager()
        {
            packages = new Dictionary<string, Package>();
            deliverers = new Dictionary<string, Deliverer>();
            assignedPackagesToDeliverers = new Dictionary<string, List<Package>>();
        }

        public void AddDeliverer(Deliverer deliverer)
        {
            deliverers.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            packages.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!packages.ContainsKey(package.Id))
            {
                throw new ArgumentException("Package Id doesn't exist.");
            }
            if (!deliverers.ContainsKey(deliverer.Id))
            {
                throw new ArgumentException("Deliverer Id doesn't exist.");
            }

            if (!assignedPackagesToDeliverers.ContainsKey(deliverer.Id))
            {
                assignedPackagesToDeliverers.Add(deliverer.Id, new List<Package>());
            }
            else
            {
                deliverers[deliverer.Id].PackagesCount++;
            }

            assignedPackagesToDeliverers[deliverer.Id].Add(package);
            packages.Remove(package.Id);
        }

        public bool Contains(Deliverer deliverer)
        {
            return deliverers.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packages.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return deliverers.Values.ToList();
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            return deliverers.Count == 0 ? new List<Deliverer>() 
                : deliverers.Values
                .OrderByDescending(d => d.PackagesCount)
                .ThenBy(d => d.Name)
                .ToList();
        }

        public IEnumerable<Package> GetPackages()
        {
            return packages.Values.ToList();
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {
            return packages.Values
                .OrderByDescending(p => p.Weight)
                .ThenBy(p => p.Receiver)
                .ToList();
        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return packages.Values.ToList();
        }
    }
}
