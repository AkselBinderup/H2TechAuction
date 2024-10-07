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
using System.Linq;
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
    private VehicleTypes _selectedVehicleType;
    private Vehicle? _selectedVehicle;
    private int _fuelCapacity;
    private DateTime? _closeAuctionDate;
    private List<int> _yearItems;

    public SetForSaleViewModel()
    {
        YearItems = Enumerable.Range(1886, DateTime.Now.Year - 1886 + 1).ToList();
        SelectedVehicleType = VehicleTypes.PrivatePassengerCar;
    }

    public List<int> YearItems
    {
        get => _yearItems;
        set => this.RaiseAndSetIfChanged(ref _yearItems, value);
    }
    public DateTime? CloseAuctionDate
    {
        get => _closeAuctionDate;
        set => this.RaiseAndSetIfChanged(ref _closeAuctionDate, value);
    }
    public VehicleTypes SelectedVehicleType
    {
        get => _selectedVehicleType;       
        set
        {
            Debug.WriteLine($"Setting SelectedVehicleType: {value}");
            this.RaiseAndSetIfChanged(ref _selectedVehicleType, value);
            UpdateSelectedVehicle();
        }
    }
    public Vehicle SelectedVehicle
    {
        get => _selectedVehicle;
        private set => this.RaiseAndSetIfChanged(ref _selectedVehicle, value);
    }
    public List<string> VehicleOptions { get; } = Enum.GetValues(typeof(VehicleTypes))
    .Cast<VehicleTypes>()
    .Select(v => v.AddSpacesEnum())
    .ToList();
    private void UpdateSelectedVehicle()
    {
        if (SelectedVehicleType == VehicleTypes.PrivatePassengerCar)
        {
            SelectedVehicle = new PrivatePassengerCar(true);
        }
        else if (SelectedVehicleType == VehicleTypes.ProfessionalPassengerCar)
        {
            SelectedVehicle = new ProfessionalPassengerCar();
        }
        else if (SelectedVehicleType == VehicleTypes.Bus)
        {
            SelectedVehicle = new Bus();
        }
        else if (SelectedVehicleType == VehicleTypes.Truck)
        {
            SelectedVehicle = new Truck();
        }
        else
        {
            SelectedVehicle = null;
        }
        Debug.WriteLine($"SelectedVehicle updated: {SelectedVehicle?.GetType().Name}");
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
    public int FuelCapacity
    {
        get => _fuelCapacity;
        set => this.RaiseAndSetIfChanged(ref _fuelCapacity, value);
    }
    public bool TowBar
    {
        get => _towBar;
        set => this.RaiseAndSetIfChanged(ref _towBar, value);
    }

    public void SellCarAction()
    {
        if (!ValidateInputs())
        {
            Debug.WriteLine("Error: Invalid input detected. Please check all fields and try again.");
            return;
        }
        try
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
                SelectedVehicle.FuelCapacity = FuelCapacity;
                SelectedVehicle.KilometerLiter = KilometerLiter;
                SelectedVehicle.EnergyClass = energy.DetermineClass(Year, Vehicle, KilometerLiter);
                SelectedVehicle.RegistrationNumber = RegNr;
                int Id = vehicleRepo.CreateReturnId(SelectedVehicle);
                SelectedVehicle.VehicleId = Id;
                auctionRepository.Create(new Auction(SelectedVehicle, LoginScreenViewModel.User, StartingBid));
            }
            Debug.WriteLine($"Selling car: {Name}, Mileage: {Mileage}, RegNr: {RegNr}, Starting Bid: {StartingBid}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }
        
    }
    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            Debug.WriteLine("Error: Name cannot be null or empty.");
            return false;
        }
        if (Mileage <= 0)
        {
            Debug.WriteLine("Error: Mileage must be a positive integer.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(RegNr))
        {
            Debug.WriteLine("Error: Registration Number cannot be null or empty.");
            return false;
        }
        if (Year < 1886 || Year > DateTime.Now.Year)
        {
            Debug.WriteLine("Error: Year must be between 1886 and the current year.");
            return false;
        }
        if (StartingBid <= 0)
        {
            Debug.WriteLine("Error: Starting Bid must be a positive value.");
            return false;
        }
        if (_height <= 0 || _length <= 0 || _weight <= 0 || _engineSize <= 0 || _fuelCapacity <= 0)
        {
            Debug.WriteLine("Error: Vehicle dimensions, engine size, and fuel capacity must be positive values.");
            return false;
        }
        if (SelectedVehicle == null)
        {
            Debug.WriteLine("Error: SelectedVehicle cannot be null.");
            return false;
        }
        return true;
    }
}
