using System;
using System.Collections.Generic;
using Xunit;
using SistemaGestorRecetas.Modelos;

namespace SistemaGestorRecetas.Tests
{
    public class UsuarioTests
    {
        [Fact]
        public void CrearLibroRecetas_AgregaADiccionario()
        {
            // Arrange
            var u = new Usuario("Bruno");

            // Act
            u.CrearLibroRecetas("Favoritas");

            // Assert
           
            Assert.True(u.MisLibros.ContainsKey("Favoritas"));
            Assert.Empty(u.MisLibros["Favoritas"]);
        }

        [Fact]
        public void CrearLibro_Duplicado_LanzaInvalidOperationException()
        {
            // Arrange
            var u = new Usuario("Bruno");
            u.CrearLibroRecetas("Favoritas");

            // Act & Assert
            // Intentar crear el mismo libro debe lanzar la excepción de operación inválida
            Assert.Throws<InvalidOperationException>(() => u.CrearLibroRecetas("Favoritas"));
        }

        [Fact]
        public void AgregarRecetaALibro_LibroExiste_AgregaCorrectamente()
        {
            // Arrange
            var u = new Usuario("Bruno");
            u.CrearLibroRecetas("Comida Rápida");
            var receta = new Receta("Pollo Frito", "Chef Coronel", 45);

            // Act
            u.AgregarRecetaALibro("Comida Rápida", receta);

            // Assert
          
            Assert.Single(u.MisLibros["Comida Rápida"]);
        }

        [Fact]
        public void AgregarReceta_LibroInexistente_LanzaKeyNotFoundException()
        {
            // Arrange
            var u = new Usuario("Bruno");
            var receta = new Receta("Pizza de Pepperoni", "Chef Luigi", 30);

            // Act & Assert
          
            Assert.Throws<KeyNotFoundException>(() => u.AgregarRecetaALibro("Inexistente", receta));
        }

        [Fact]
        public void ContarRecetas_SumaCorrecta()
        {
            // Arrange
            var u = new Usuario("Bruno");
            u.CrearLibroRecetas("Cenas");
            u.CrearLibroRecetas("Fines de semana");

            u.AgregarRecetaALibro("Cenas", new Receta("Hamburguesa", "Chef Carlos", 20));
            u.AgregarRecetaALibro("Fines de semana", new Receta("Pizza", "Chef Mario", 30));

            // Act
            int totalRecetas = u.ContarRecetas();

            // Assert
           
            Assert.Equal(2, totalRecetas);
        }
    }
}
}
