using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIS_Praktika1.Models;

namespace TIS_Praktika1.Controllers
{
    [Route("api/pets")]
    public class HomeController : Controller
    {
        private PetsContext? _db;

        public HomeController(PetsContext pizzaContext)
        {
            _db = pizzaContext;
        }

        // GET api/pets
        // Получение списка товаров
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JsonResult>>> Get(string category, string _sort)
        {
            try
            {
                List<Pet> pets = await _db.Pets.ToListAsync();
                return new JsonResult(pets);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/pets
        // Создание товара
        [HttpPost]
        public async Task<ActionResult<Pet>> Post(Pet pet)
        {
            if (_db.Pets.Any(el => el.Name == pet.Name))
            {
                return BadRequest();
            }
            if (pet == null)
            {
                return BadRequest();
            }

            await _db.Pets.AddAsync(pet);
            await _db.SaveChangesAsync();

            return Ok(pet);
        }

        // Обновление товара
        // PUT api/pets
        [HttpPut("{id}")]
        public async Task<ActionResult<Pet>> Put(Pet pet)
        {

            if (pet == null)
            {
                return BadRequest();
            }


            Pet foundPet= await _db.Pets.FirstOrDefaultAsync(el => el.Id == pet.Id);

            if (foundPet == null)
            {
                return NotFound();
            }

            foundPet.Name = pet.Name;
            foundPet.Price = pet.Price;
            foundPet.Age = pet.Age;
            foundPet.IsVaccinated = pet.IsVaccinated;

            await _db.SaveChangesAsync();
            return Ok(pet);
        }


        // DELETE api/pets
        // Удаление товара
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> Delete(int id)
        {
            try
            {
                Pet pet = _db.Pets.FirstOrDefault(el => el.Id == id);

                if (pet == null)
                {
                    return NotFound();
                }

                _db.Pets.Remove(pet);
                await _db.SaveChangesAsync();
                return Ok(pet);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
