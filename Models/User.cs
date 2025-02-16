//Para usar anotaciones como Key
using System.ComponentModel.DataAnnotations;

namespace AztroWebApplication.Models{
    public class User{
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; } = string.Empty;
        public string Email{ get; set; } = string.Empty;
        public int Age{ get; set; }

        //Constructor vacío
        public User(){
        }

    }
}