﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(FlightId))]
public class Flight
{
    public int FlightId { get; set; } = 0;

    [Required]
    public virtual Plane Plane { get; set; } = null!;

    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

    [Required]
    public virtual ICollection<StaffWorker> WorkerStaff { get; set; } = new List<StaffWorker>();

    [Required]
    public virtual ICollection<Pilot> Pilots { get; set; } = new List<Pilot>();

    [Required]
    public virtual ICollection<FlightStop> Stops { get; set; } = new List<FlightStop>();

    [Required]
    public DateTime DepartureTime { get; set; }

    [Required]
    public DateTime ArrivalTime { get; set; }

    public TimeSpan GetDuration()
    {
        return ArrivalTime - DepartureTime;
    }
}