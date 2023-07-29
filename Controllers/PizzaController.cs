
using Microsoft.AspNetCore.Mvc;
using AspNet_RestfulAPI.Models;
using AspNet_RestfulAPI.Services;

namespace AspNet_RestfulAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController: ControllerBase {
    public PizzaController() {}

    [HttpGet]
    public ActionResult<List<Pizza>> Get() {
        return PizzaService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id) {
        Pizza pizza = PizzaService.Get(id);

        // if(pizza == null ) {
        //     return NotFound();
        // }
        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza) {
        // Add
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza) {
        // Update
        if(id != pizza.Id) {
            return BadRequest();
        }

        var existingPizza = PizzaService.Get(id);

        if(existingPizza is null) {
            return NotFound();
        }

        PizzaService.Update(pizza);

        return NoContent();
    } 


    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var pizza = PizzaService.Get(id);

        if(pizza is null) return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}