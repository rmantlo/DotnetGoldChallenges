using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OutingsRepository
{
    public enum TypeOfEvent
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class Outings
    {
        public DateTime DateOfOuting { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostForEvent { get; set; }
        public TypeOfEvent EventType { get; set; }

        public Outings()
        {

        }
        public Outings(DateTime dateOfOuting, int numberOfPeople, decimal costPerPerson, decimal costForEvent, TypeOfEvent eventType)
        {
            DateOfOuting = dateOfOuting;
            NumberOfPeople = numberOfPeople;
            CostPerPerson = costPerPerson;
            CostForEvent = costForEvent;
            EventType = eventType;
        }
    }
}
