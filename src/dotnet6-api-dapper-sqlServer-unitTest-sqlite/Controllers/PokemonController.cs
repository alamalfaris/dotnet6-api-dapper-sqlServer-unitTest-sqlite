﻿using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemons()
        {
            try
            {
                var pokemons = await _pokemonRepository.GetPokemons();
                return Ok(pokemons.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
