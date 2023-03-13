namespace ParkingManagementApp.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Bus
{
    [Key]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Route { get; set; } = null!;

    public DateTime DepartureWarehouse { get; set; }

    public DateTime BackToWarehouse { get; set; }

    public virtual User Driver { get; set; } = null!;
}
