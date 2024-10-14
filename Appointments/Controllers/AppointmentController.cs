using Appointments.Data;
using Appointments.Models.domain;
using Appointments.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController(AppointmentsDbContext context) : ControllerBase
{
    private readonly AppointmentsDbContext _aptDB = context;

    [HttpGet]
    public async Task<IActionResult> GetAppointments()
    {
        var appointments = await _aptDB.Appointments.ToListAsync(); 
        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointment(int id)
    {
        var appointment = await _aptDB.Appointments.FindAsync(id);
        if (appointment == null) return NotFound();
        return Ok(appointment);
    }

    // POST: api/Appointments
    [HttpPost]
    public async Task<ActionResult<Appointment>> CreateAppointment(AppointmentDTO appointmentDto)
    {
        var customer = await _aptDB.Customers.FindAsync(appointmentDto.CustomerId);
        var vehicle = await _aptDB.Vehicles.FindAsync(appointmentDto.VehicleId);

        if (customer == null || vehicle == null)
        {
            return NotFound("Customer or Vehicle not found");
        }

        var appointment = new Appointment
        {
            AppointmentDate = appointmentDto.AppointmentDate,
            ServiceType = appointmentDto.ServiceType,
            CustomerId = appointmentDto.CustomerId,
            Customer = customer,
            VehicleId = appointmentDto.VehicleId,
            Vehicle = vehicle
        };

        _aptDB.Appointments.Add(appointment);
        _aptDB.SaveChanges();

        return Ok(new { message = "Appointment created successfully." });
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(int id, Appointment updatedAppointment)
    {
        var existingAppointment = await _aptDB.Appointments.FindAsync(id);

        if (existingAppointment == null) return NotFound();

        existingAppointment.AppointmentDate = updatedAppointment.AppointmentDate;
        existingAppointment.VehicleId = updatedAppointment.VehicleId;
        existingAppointment.ServiceType = updatedAppointment.ServiceType;

        _aptDB.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _aptDB.Appointments.FindAsync(id);
        if (appointment == null) return NotFound();

        _aptDB.Appointments.Remove(appointment);
        _aptDB.SaveChanges();
        return NoContent();
    }
}
