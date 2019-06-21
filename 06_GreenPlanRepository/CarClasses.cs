using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlanRepository
{
    public enum TypeOfCar { Electric = 1, Hybrid, Gas }
    public interface ICar
    {
        decimal CarPrice { get; set; }
        string FirstName { get; set; }
        TypeOfCar CarType { get; set; }
    }
    public class ElectricCar: ICar
    {
        public decimal CarPrice { get; set; }
        public string FirstName { get; set; }
        public TypeOfCar CarType { get; set; }
        public ElectricCar() { }
        public ElectricCar(TypeOfCar carType, decimal carPrice, string firstName)
        {
            CarType = carType;
            CarPrice = carPrice;
            FirstName = firstName;
        }
    }
    public class HybridCar: ICar
    {
        public decimal CarPrice { get; set; }
        public string FirstName { get; set; }
        public TypeOfCar CarType { get; set; }
        public HybridCar() { }
        public HybridCar(TypeOfCar carType, decimal carPrice, string firstName)
        {
            CarType = carType;
            CarPrice = carPrice;
            FirstName = firstName;
        }
    }
    public class GasCar: ICar
    {
        public decimal CarPrice { get; set; }
        public string FirstName { get; set; }
        public TypeOfCar CarType { get; set; }
        public GasCar() { }
        public GasCar(TypeOfCar carType, decimal carPrice, string firstName)
        {
            CarType = carType;
            CarPrice = carPrice;
            FirstName = firstName;
        }
    }
}
