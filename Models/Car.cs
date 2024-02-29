using System.ComponentModel.DataAnnotations;

namespace MVCAssign1.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string YearOfManufacture { get; set; }
        public string EngineDisplacement { get; set; }

        public string Strength { get; set; }
        public string Fuel { get; set; }
        public string BodyWork { get; set; }
        [StringLength(150,ErrorMessage ="Opis je predugacak.Mozes korisitit 150 karaktera")]
        public string Description { get; set; }

        [Range(10,100000,ErrorMessage = "Cijena mora biti u rasponu 10 €-100000 €")]
        public double Price { get; set; }
        public string Contact { get; set; }


    }
}
