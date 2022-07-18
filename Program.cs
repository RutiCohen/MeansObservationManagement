using ManagementOfObservation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementOfObservation.Models.Entities;

namespace ManagementOfObservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to ManagementOfObservation");
            Console.WriteLine("Please enter MeansObservation");
            AddMeansObservation();
            Console.WriteLine("\n-------Remove MeansObservation");
            Console.WriteLine("Please enter MeansObservation details to remove");
            MeansObservation item = MeansObservation.Init();
            if (item == null)
                return;
            MeansObservationManagement.RemoveMeansObservation(item);
            Console.WriteLine("\n-------Display all MeansObservation");
            List<MeansObservation> all = MeansObservationManagement.GetAllMeansObservation();
            if (!all.Any())
                Console.WriteLine("Not found any MeansObservation");
            else
            {
                foreach(MeansObservation meansObservation in all)
                {
                    meansObservation.Details();
                }
            }
            Console.WriteLine("\n-------GetTypesMeansObservation");
            Console.WriteLine("Enter TypesMeansObservation:");
            int TypesMeansObservation = MeansObservation.GetTypesMeansObservation();
            if(TypesMeansObservation == -1)
                Console.WriteLine("not valid TypesMeansObservation to search");
            else
            {
                all = MeansObservationManagement.GetMeansObservation((TypesMeansObservation)TypesMeansObservation);
                if (!all.Any())
                    Console.WriteLine("Not found any MeansObservation");
                else
                {
                    foreach (MeansObservation meansObservation in all)
                    {
                        meansObservation.Details();
                    }
                }
            }
            Console.WriteLine("\n-------GetOrderingMeansObservation");
            all = MeansObservationManagement.GetOrderingMeansObservation();
            if (!all.Any())
                Console.WriteLine("Not found any MeansObservation");
            else
            {
                foreach (MeansObservation meansObservation in all)
                {
                    meansObservation.Details();
                }
            }
            Console.WriteLine("\n-------GetMaxMeansObservation");
            FieldOfView FieldOfView = FieldOfView.Init();
            if(FieldOfView == null)
                Console.WriteLine("not valid FieldOfView to search");
            MeansObservation MaxMeansObservation = MeansObservationManagement.GetMaxMeansObservation(FieldOfView);
            if (MaxMeansObservation == null)
                Console.WriteLine("not found MaxMeansObservation");
            else
                MaxMeansObservation.Details();
            Console.WriteLine("END");
            Console.ReadLine();
        }

        static void AddMeansObservation()
        {
            while (true)
            {
                MeansObservation item = MeansObservation.Init();
                if (item == null)
                    return;
                MeansObservationManagement.AddMeansObservation(item);
            }
        }
    }
}
