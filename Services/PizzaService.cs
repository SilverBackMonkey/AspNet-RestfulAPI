using AspNet_RestfulAPI.Models;

namespace AspNet_RestfulAPI.Services;

public static class PizzaService
{
    static List<Pizza> pizzas { get; }
    static int nextId = 3;

    static PizzaService() {
        pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Pizza> GetAll() => pizzas;


    public static Pizza? Get(int id) => pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza) {
        pizza.Id = nextId ++;
        pizzas.Add(pizza);
    }

    public static void Delete(int id) {
        Pizza pizza = Get(id);
        if(pizza is null) return;

        pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza) {
        var index = pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1) return;
        pizzas[index] = pizza;
    }
}