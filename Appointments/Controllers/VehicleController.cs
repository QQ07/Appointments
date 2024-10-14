using Appointments.Data;
using Appointments.Models.domain;
using Appointments.Models.DTOs;
using Appointments.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VehicleController(AppointmentsDbContext context, IVehicleRepository vehicleRepository, ICustomerRepository customerRepository, IMapper mapper,) : ControllerBase
{
    private readonly AppointmentsDbContext _aptDB = context;
    private readonly IVehicleRepository vehicleRepository = vehicleRepository;

    [HttpGet]
    public async Task<IActionResult> GetVehicles()
    {
        var vehicles = await vehicleRepository.GetAllAsync();
        return Ok(mapper.Map<List<Vehicle>>(vehicles));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicle(int id)
    {
        var vehicle = await vehicleRepository.GetByIDAsync(id);
        if (vehicle == null) return NotFound();
        return Ok(mapper.Map<VehicleDTO>(vehicle));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle(VehicleDTO vehicleDto)
    {
        var customer = await customerRepository.GetByIDAsync(vehicleDto.CustomerId);
        if (customer == null)
        {
            return NotFound();
        }

        var vehicle = mapper.Map<Vehicle>(vehicleDto);

        _aptDB.Vehicles.Add(vehicle);
        await _aptDB.SaveChangesAsync();

        return Ok(new { message = "Vehicle created successfully." });
    }



    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVehicle(int id)
    {
        var vehicle = await _aptDB.Vehicles.FindAsync(id);
        if (vehicle == null) return NotFound();

        _aptDB.Vehicles.Remove(vehicle);
        await _aptDB.SaveChangesAsync();
        return NoContent();
    }
}
