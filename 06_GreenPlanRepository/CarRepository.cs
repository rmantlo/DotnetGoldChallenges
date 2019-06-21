using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlanRepository
{
    public class CarRepository
    {
        private List<ElectricCar> _electricRepo = new List<ElectricCar>();
        private List<HybridCar> _hybridRepo = new List<HybridCar>();
        private List<GasCar> _gasRepo = new List<GasCar>();


        public List<ElectricCar> GetElectricCarList()
        {
            return _electricRepo;
        }
        public List<HybridCar> GetHybridCarList()
        {
            return _hybridRepo;
        }
        public List<GasCar> GetGasCarList()
        {
            return _gasRepo;
        }
        public ICar GetACar(string firstName)
        {
            foreach (ElectricCar electricCar in _electricRepo)
            {
                if (electricCar.FirstName.ToLower() == firstName.ToLower())
                {
                    return electricCar;
                }
                else
                {
                    foreach (HybridCar hybridCar in _hybridRepo)
                    {
                        if (hybridCar.FirstName.ToLower() == firstName.ToLower())
                        {
                            return hybridCar;
                        }
                        else
                        {
                            foreach (GasCar gasCar in _gasRepo)
                            {
                                if (gasCar.FirstName.ToLower() == firstName.ToLower())
                                {
                                    return gasCar;
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        public void CreateNewCar(decimal carPrice, string firstName, TypeOfCar carType)
        {
            if (carType == TypeOfCar.Electric)
            {
                ElectricCar electricCar = new ElectricCar();
                electricCar.CarPrice = carPrice;
                electricCar.CarType = TypeOfCar.Electric;
                electricCar.FirstName = firstName;
                _electricRepo.Add(electricCar);
            }
            else if (carType == TypeOfCar.Hybrid)
            {
                HybridCar hybridCar = new HybridCar();
                hybridCar.FirstName = firstName;
                hybridCar.CarType = TypeOfCar.Hybrid;
                hybridCar.CarPrice = carPrice;
                _hybridRepo.Add(hybridCar);
            }
            else if (carType == TypeOfCar.Gas)
            {
                GasCar gasCar = new GasCar();
                gasCar.CarPrice = carPrice;
                gasCar.CarType = TypeOfCar.Gas;
                gasCar.FirstName = firstName;
                _gasRepo.Add(gasCar);
            }
        }
        public void UpdateElectricCar(string firstName, ElectricCar eCar)
        {
            foreach(ElectricCar car in _electricRepo)
            {
                if(car.FirstName == firstName)
                {
                    _electricRepo.Remove(car);
                    _electricRepo.Add(eCar);
                    
                }
                else
                {
                    foreach(HybridCar carTwo in _hybridRepo)
                    {
                        if(carTwo.FirstName == firstName)
                        {
                            _hybridRepo.Remove(carTwo);
                            _electricRepo.Add(eCar);
                        }
                        else
                        {
                            foreach(GasCar carThree in _gasRepo)
                            {
                                if(carThree.FirstName == firstName)
                                {
                                    _gasRepo.Remove(carThree);
                                    _electricRepo.Add(eCar);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void UpdateHybridCar(string firstName, HybridCar hCar)
        {
            foreach (HybridCar car in _hybridRepo)
            {
                if (car.FirstName == firstName)
                {
                    _hybridRepo.Remove(car);
                    _hybridRepo.Add(hCar);

                }
                else
                {
                    foreach (ElectricCar carTwo in _electricRepo)
                    {
                        if (carTwo.FirstName == firstName)
                        {
                            _electricRepo.Remove(carTwo);
                            _hybridRepo.Add(hCar);
                        }
                        else
                        {
                            foreach (GasCar carThree in _gasRepo)
                            {
                                if (carThree.FirstName == firstName)
                                {
                                    _gasRepo.Remove(carThree);
                                    _hybridRepo.Add(hCar);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void UpdateGasCar(string firstName, GasCar gCar)
        {
            foreach (ElectricCar car in _electricRepo)
            {
                if (car.FirstName == firstName)
                {
                    _electricRepo.Remove(car);
                    _gasRepo.Add(gCar);

                }
                else
                {
                    foreach (HybridCar carTwo in _hybridRepo)
                    {
                        if (carTwo.FirstName == firstName)
                        {
                            _hybridRepo.Remove(carTwo);
                            _gasRepo.Add(gCar);
                        }
                        else
                        {
                            foreach (GasCar carThree in _gasRepo)
                            {
                                if (carThree.FirstName == firstName)
                                {
                                    _gasRepo.Remove(carThree);
                                    _gasRepo.Add(gCar);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void RemoveACar(string firstName)
        {
            ICar car = GetACar(firstName);
            if (car.CarType == TypeOfCar.Electric)
            {
                foreach (ElectricCar eCar in _electricRepo)
                {
                    if (eCar.FirstName == firstName)
                    {
                        _electricRepo.Remove(eCar);
                        break;
                    }
                }
            }
            else if (car.CarType == TypeOfCar.Gas)
            {
                foreach (GasCar gCar in _gasRepo)
                {
                    if (gCar.FirstName == firstName)
                    {
                        _gasRepo.Remove(gCar);
                        break;
                    }
                }
            }
            else if (car.CarType == TypeOfCar.Hybrid)
            {
                foreach (HybridCar hCar in _hybridRepo)
                {
                    if (hCar.FirstName == firstName)
                    {
                        _hybridRepo.Remove(hCar);
                        break;
                    }
                }
            }
        }
    }
}
