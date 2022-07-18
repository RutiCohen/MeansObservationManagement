using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementOfObservation.Models.Entities;
using ManagementOfObservation.Models.Enums;

namespace ManagementOfObservation
{
    public class MeansObservationManagement
    {
        private static List<MeansObservation> means  = new List<MeansObservation>();

        public static bool AddMeansObservation (MeansObservation item)
        {
            if(means.Any(x=>x.TypesMeansObservation == item.TypesMeansObservation 
                            && (x.Range.Meters == item.Range.Meters || x.Range.AerialLine == item.Range.AerialLine)))
            {
                Console.WriteLine("There is exists item with same TypesMeansObservation && metters or AerialLine");
                return false;
            }   
            if(means.Any(x => x.TypesMeansObservation == item.TypesMeansObservation
                            && (x.FieldOfView.Degrees == item.FieldOfView.Degrees || x.FieldOfView.Angle == item.FieldOfView.Angle)))
            {
                Console.WriteLine("There is exists item with same TypesMeansObservation && Degrees or Angle");
                return false;
            }
            Console.WriteLine("Item Added Successfully");
            means.Add(item);
            return true;
        }

        public static bool RemoveMeansObservation(MeansObservation item)
        {
            int itemIndexToRemove = means.FindIndex(x => x.TypesMeansObservation == item.TypesMeansObservation
                            && (x.Range.Meters == item.Range.Meters && x.Range.AerialLine == item.Range.AerialLine)
                            && (x.FieldOfView.Degrees == item.FieldOfView.Degrees || x.FieldOfView.Angle == item.FieldOfView.Angle));
            if (itemIndexToRemove != -1)
            {
                means.RemoveAt(itemIndexToRemove);
                Console.WriteLine("Item removed successfully");
                return true;
            }
            Console.WriteLine("Failed remove item, check if item exists...");
            return false;
        }

        public static List<MeansObservation> GetAllMeansObservation()
        {
            return means;
        }

        public static List<MeansObservation> GetMeansObservation(TypesMeansObservation type)
        {
            return means?.FindAll(x=>x.TypesMeansObservation == type);
        }

        public static List<MeansObservation> GetOrderingMeansObservation()
        {
            return means?.OrderBy(x=>x.Range.Meters).ThenBy(x => x.Range.AerialLine).ToList<MeansObservation>();
        }

        public static MeansObservation GetMaxMeansObservation(FieldOfView minFieldOfView)
        {
            List<MeansObservation> list = means.FindAll(x => x.FieldOfView.Angle >= minFieldOfView.Angle && x.FieldOfView.Degrees >= minFieldOfView.Degrees);
            return list?.Count < 2 ? list.FirstOrDefault() : list?.Aggregate((a, b) => a.Range.Meters > b.Range.Meters ? a : b); 
        }

    }
}
