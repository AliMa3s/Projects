using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase {
        //U can use this if u dont have database. 
        //private static List<SuperHero> heroes = new List<SuperHero> {
        //        new SuperHero {
        //            Id = 1,
        //            Name = "Spider Man",
        //            FirstName = "Peter",
        //            LastName = "Parker",
        //            Place = "Brussel"
        //        }, new SuperHero {
        //            Id = 2,
        //            Name = "Iron Man",
        //            FirstName = "Tony",
        //            LastName = "Stark",
        //            Place = "London"
        //        }
        //     };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get() {
            //old methode without database
            //return Ok(heroes);
            //New methode with db
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id) {
            //Old methode 
            /*
            var hero = heroes.Find(h => h.Id == id);
            if(hero == null) {
                return BadRequest("The hero doesn't exist!");
            }

            return Ok(hero);
            */
            //New methode with db
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null) {
                return BadRequest("The hero doesn't exist!");
            }

            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero) {
            //old methode
            /*
            heroes.Add(hero);
            return Ok(heroes); */
            //new methode
            _context.SuperHeroes.Add(hero);
            //Because we make changes to db we have to savechanges
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request) {
            //old methdoe
            /*
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null) {
                return BadRequest("The hero doesn't exist!");
            }

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            
            return Ok(heroes);
            */
            //new methode wiith db
            var dbhero = _context.SuperHeroes.Find(request.Id);
            if (dbhero == null) {
                return BadRequest("The hero doesn't exist!");
            }

            dbhero.Name = request.Name;
            dbhero.FirstName = request.FirstName;
            dbhero.LastName = request.LastName;
            dbhero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());


        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id) {
            //oldmethode
            /*
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null) {
                return BadRequest("The hero doesn't exist!");
            }
            heroes.Remove(hero);
            return Ok(heroes);
            */
            var dbhero = _context.SuperHeroes.Find(id);
            if (dbhero == null) {
                return BadRequest("The hero doesn't exist!");
            }
            _context.SuperHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());

        }


    }

}
