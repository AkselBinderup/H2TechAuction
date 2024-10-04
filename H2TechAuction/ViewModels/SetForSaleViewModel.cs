using H2TechAuction.Converters;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.DatabaseRepositories;
using H2TechAuction.Models.UserModels;
using H2TechAuction.Models.UserModels.Generators;
using H2TechAuction.Models.VehicleModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;

namespace H2TechAuction.ViewModels;

public class SetForSaleViewModel : ViewModelBase
{
    private string? _name;
    private int _mileage;
    private string? _regNr;
    private int _year;
    private decimal _startingBid;
    private string? _vehicle;
    private double _height;
    private double _length;
    private double _weight;
    private double _engineSize;
    private int _kilometerLiter;
    private bool _towBar;
    private VehicleTypes _selectedVehiclType;
    private Vehicle? _selectedVehicle;

    public VehicleTypes SelectedVehicleType
    {
        get => _selectedVehiclType;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedVehiclType, value);
            UpdateSelectedVehicle();
        }
    }
    public Vehicle SelectedVehicle
    {
        get => _selectedVehicle;
        private set => this.RaiseAndSetIfChanged(ref _selectedVehicle, value);
    }
    public List<string> VehicleOptions { get; } =
    [
        VehicleTypes.PrivatePassengerCar.AddSpacesEnum(),
        VehicleTypes.ProfessionalPassengerCar.AddSpacesEnum(),
        VehicleTypes.Bus.AddSpacesEnum(),
        VehicleTypes.Truck.AddSpacesEnum()
    ];
    private void UpdateSelectedVehicle()
    {
        switch (SelectedVehicleType)
        {
            case VehicleTypes.PrivatePassengerCar:
                SelectedVehicle = new PrivatePassengerCar(true);
                break;
            case VehicleTypes.ProfessionalPassengerCar:
                SelectedVehicle = new ProfessionalPassengerCar();
                break;
            case VehicleTypes.Bus:
                SelectedVehicle = new Bus();
                break;
            case VehicleTypes.Truck:
                SelectedVehicle = new Truck();
                break;
            default:
                SelectedVehicle = null;
                break;
        }
    }
    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public int Mileage
    {
        get => _mileage;
        set => this.RaiseAndSetIfChanged(ref _mileage, value);
    }

    public string? RegNr
    {
        get => _regNr;
        set => this.RaiseAndSetIfChanged(ref _regNr, value);
    }

    public int Year
    {
        get => _year;
        set => this.RaiseAndSetIfChanged(ref _year, value);
    }

    public decimal StartingBid
    {
        get => _startingBid;
        set => this.RaiseAndSetIfChanged(ref _startingBid, value);
    }

    public string? Vehicle
    {
        get => _vehicle;
        set => this.RaiseAndSetIfChanged(ref _vehicle, value);
    }

    public double Height
    {
        get => _height;
        set => this.RaiseAndSetIfChanged(ref _height, value);
    }

    public double Length
    {
        get => _length;
        set => this.RaiseAndSetIfChanged(ref _length, value);
    }

    public double Weight
    {
        get => _weight;
        set => this.RaiseAndSetIfChanged(ref _weight, value);
    }

    public double EngineSize
    {
        get => _engineSize;
        set => this.RaiseAndSetIfChanged(ref _engineSize, value);
    }
    public int KilometerLiter
    {
        get => _kilometerLiter;
        set => this.RaiseAndSetIfChanged(ref _kilometerLiter, value);
    }

    public bool TowBar
    {
        get => _towBar;
        set => this.RaiseAndSetIfChanged(ref _towBar, value);
    }

    public void SellCarAction()
    {
        VehicleRepository vehicleRepo = new();
        AuctionRepository auctionRepository = new();
        GetEnergyClass energy = new();
        if (SelectedVehicle != null)
        {
            SelectedVehicle.Name = Name;
            SelectedVehicle.Kilometers = Mileage; 
            SelectedVehicle.ModelYear = Year;
            SelectedVehicle.TowingHitch = TowBar;
            SelectedVehicle.EngineSize = EngineSize;
            SelectedVehicle.Fuel = Vehicle;  
            SelectedVehicle.KilometerLiter = KilometerLiter;
            SelectedVehicle.EnergyClass = energy.DetermineClass(Year, Vehicle, KilometerLiter);
            auctionRepository.Create(new Auction(SelectedVehicle, LoginScreenViewModel.User, StartingBid));
            //DBTODO
            vehicleRepo.Create(SelectedVehicle);
        }
        //ændr private user til brugerens status please::: TODO TODOOO
        Debug.WriteLine($"Selling car: {Name}, Mileage: {Mileage}, RegNr: {RegNr}, Starting Bid: {StartingBid}");
    }
}
