using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //Ejercicio 1
        [HttpPost]
        public IActionResult Post([FromBody] ValuesRequest request)
        {
            if (!ModelState.IsValid || request.Numero == null)
            {
                return BadRequest(new { error = "Debes enviar un número entero válido." });
            }
            var numero = request.Numero.Value;
            if (numero % 2 == 0)
            {
                return Ok(new { resultado = "par", mitad = numero / 2 });
            }
            else
            {
                return Ok(new { resultado = "impar", cuadrado = numero * numero });
            }
        }
        public class ValuesRequest
        {
            public int? Numero { get; set; }
        }
        //Ejercicio 2
        [HttpPost]
        public IActionResult ContarVocales([FromBody] string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return BadRequest(new { error = "Debes enviar una cadena de texto válida." });
            }
            int contador = 0;
            char[] vocales = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach (char caracter in texto)
            {
                if (Array.Exists(vocales, v => v == caracter))
                {
                    contador++;
                }
            }
            return Ok(contador);
        }
        //Ejercicio 3
        [HttpPost]
        public IActionResult InvertirCadena([FromBody] string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return BadRequest(new { error = "Debes enviar una cadena de texto válida." });
            }
            char[] arrayTexto = texto.ToCharArray();
            Array.Reverse(arrayTexto);
            string cadenaInvertida = new string(arrayTexto);
            return Ok(new { cadenaInvertida });
        }
    }
}
