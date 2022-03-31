#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_hello;

namespace web_api_hello.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlaceController : ControllerBase
	{
		private readonly ApiDbContext _context;

		public PlaceController(ApiDbContext context)
		{
			_context = context;
		}

		// GET: api/Place
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
		{
			return await _context.Places.ToListAsync();
		}

		// GET: api/Place/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Place>> GetPlace(uint id)
		{
			var place = await _context.Places.FindAsync(id);

			if (place == null)
			{
				return NotFound();
			}

			return place;
		}

		// PATCH: api/Place/5
		// [HttpPatch("{id}")]
		// public async Task<IActionResult> PatchPlace(uint id, Place place)
		// {
		// 	if (id != place.PlaceID)
		// 	{
		// 		return BadRequest();
		// 	}

		// 	//var dbPlace = _context.Places.Where(p => p.PlaceID == id).FirstOrDefault();

		// 	if (place.Name != null)
		// 	{

		// 	}

		// 	_context.Entry(place).State = EntityState.Modified;

		// 	try
		// 	{
		// 		await _context.SaveChangesAsync();
		// 	}
		// 	catch (DbUpdateConcurrencyException)
		// 	{
		// 		if (!PlaceExists(id))
		// 		{
		// 			return NotFound();
		// 		}
		// 		else
		// 		{
		// 			throw;
		// 		}
		// 	}

		// 	return NoContent();
		// }

		// PUT: api/Place/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPlace(uint id, Place place)
		{
			if (id != place.PlaceID)
			{
				return BadRequest();
			}

			_context.Entry(place).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PlaceExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Place
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Place>> PostPlace(Place place)
		{
			_context.Places.Add(place);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPlace", new { id = place.PlaceID }, place);
		}

		// DELETE: api/Place/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlace(uint id)
		{
			var place = await _context.Places.FindAsync(id);
			if (place == null)
			{
				return NotFound();
			}

			_context.Places.Remove(place);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PlaceExists(uint id)
		{
			return _context.Places.Any(e => e.PlaceID == id);
		}
	}
}
