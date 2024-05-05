﻿using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class FlightsModule
{
    private readonly SpoonbillContext m_context;

    public FlightsModule(SpoonbillContext context)
    {
        m_context = context;
    }

    public Flight? GetFlight(int id)
    {
        // kinda hate how big this is but there isn't an easy fix for it
        return m_context.Flights
            .Include(f => f.Passengers)
            .ThenInclude(p => p.Flights)
            .Include(f => f.Pilots)
            .ThenInclude(p => p.AssignedFlights)
            .Include(f => f.WorkerStaff)
            .ThenInclude(s => s.AssignedFlights)
            .Include(f => f.Plane)
            .ThenInclude(p => p.Model).ThenInclude(m => m.Manufacturer).ThenInclude(m => m.City).ThenInclude(c => c.County)
            .Include(f => f.Stops)
            .ThenInclude(s => s.Airport) // don't need to include cities and such as they're already included
            .First(f => f.FlightId == id);
    }

    public IResult CreateFlight(Flight flight)
    {
        try
        {
            m_context.Flights.Add(flight);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateFlight(Flight flight)
    {
        try
        {
            m_context.Flights.Update(flight);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteFlight(Flight flight)
    {
        try
        {
            m_context.Flights.Remove(flight);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<Flight> ListFlights()
    {
        return m_context.Flights
            .Include(f => f.Passengers)
            .Include(f => f.Pilots)
            .Include(f => f.WorkerStaff)
            .Include(f => f.Plane)
            .Include(f => f.Stops)
            .ToList();
    }
}