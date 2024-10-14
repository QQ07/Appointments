using Appointments.Data;
using Appointments.Models.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(AppointmentsDbContext context) : ControllerBase
{
    private readonly AppointmentsDbContext _aptDB = context;

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _aptDB.Customers.ToListAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _aptDB.Customers.FindAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async  Task<IActionResult> CreateCustomer(Customer customer)
    {
        await _aptDB.Customers.AddAsync(customer);
        _aptDB.SaveChanges();
        return Ok(new { message = "Customer created successfully.", id = customer.CustomerId });
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
    {
        customer.CustomerId = id;
        _aptDB.Update(customer);
        await _aptDB.SaveChangesAsync();

        return Ok(new { message = "Customer updated successfully." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _aptDB.Customers.FindAsync(id);
        if (customer == null) return NotFound();

        customer.IsDeleted = true;
        await _aptDB.SaveChangesAsync();
        return Ok(new { message = "Customer deleted successfully." });
    }
}
