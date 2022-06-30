using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiNBP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebApiNBPController : ControllerBase
    {
        private readonly DataContext dataContext;

        public WebApiNBPController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pozycja>>> Get()
        {
            return Ok(await dataContext.Pozycje.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<Pozycja>> Get(Pozycja request)
        {
            var dbCurrency = await dataContext.Pozycje.FindAsync(request.Nazwa_waluty);
            if (dbCurrency == null)
                return BadRequest("Not found");

            dbCurrency.Nazwa_waluty = request.Nazwa_waluty;
            dbCurrency.Przelicznik = request.Przelicznik;
            dbCurrency.Kod_waluty = request.Kod_waluty;
            dbCurrency.Kurs_sredni = request.Kurs_sredni;

            await dataContext.SaveChangesAsync();

            return Ok(await dataContext.Pozycje.ToListAsync());
        }
        [HttpGet("GetCurrency")]
        public async Task<ActionResult<Pozycja>> Get(string Nazwa_waluty)
        {
            var Currency = await dataContext.Pozycje.FindAsync(Nazwa_waluty);
            if (Currency == null)
                return BadRequest("Not found");
            return Ok(Currency);
        }
        [HttpPost]
        public async Task<ActionResult<List<Pozycja>>> AddCurrency(Pozycja Currency)
        {
            dataContext.Pozycje.Add(Currency);
            await dataContext.SaveChangesAsync();
            return Ok(await dataContext.Pozycje.ToListAsync());
        }
        [HttpPost]
      
        public async Task<ActionResult<List<Pozycja>>> AddCurrencyRange(List<Pozycja> Currency)
        {
            dataContext.Pozycje.AddRange(Currency);
            await dataContext.SaveChangesAsync();
            return Ok(await dataContext.Pozycje.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<Pozycja>> Delete(string Nazwa_waluty)
        {
            var dbCurrency = await dataContext.Pozycje.FindAsync(Nazwa_waluty);
            if (dbCurrency == null)
                return BadRequest("Not found");
            dataContext.Pozycje.Remove(dbCurrency);
            await dataContext.SaveChangesAsync();

            return Ok(await dataContext.Pozycje.ToListAsync());
        }
    }
}
