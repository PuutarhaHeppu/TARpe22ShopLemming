namespace TARpe22ShopLemming.Core.Dto
{ 
using System.ComponentModel.DataAnnotations;

    internal class SpaceshipDto
    {
        [Key]
        public Guid ID { get; set; } // unique id
        public int Price { get; set; } // price
        public string Type { get; set; } // Spaceship Type [rocket, saucer, cruise ship, cargoship]
        public string Name { get; set; } // Name of the ship
        public string Description { get; set; } // Description for ship
        public string FuelType { get; set; } // Fuel Type
        public int FuelCapacity { get; set; } // Max fuel
        public int FuelConsumption { get; set; } // fuel consumption
        public int PassengerCount { get; set; } // Seat count
        public int EnginePower { get; set; } // Engine power in kWh
        public bool DoesHaveAutoPilot { get; set; } // if have autopilot True or False
        public int CrewCount { get; set; } // How many Crewmembers
        public int CargoWeight { get; set; } // how much cargo can this shit hold
        public bool DoesHaveLifeSupportSystems { get; set; } // if has life support systems
        public DateTime BuiltAt { get; set; } // when was the ship built
        public DateTime LastMaintenence { get; set; } // when was the ship last maintained
        public int MaintenenceCount { get; set; } // how many times maintenence count
        public int FullTripCount { get; set; } // how many voyages has this ship gone through
        public DateTime MaidenLaunch { get; set; } // when did the ship first take its voyage
        public string ManuFacturer { get; set; } // who manufactored the spaceship

        // database info, not for customer
        public DateTime CreatedAt { get; set; } //When was the entry created
        public DateTime ModifiedAt { get; set; } //When was the entry last modified
    }
}
