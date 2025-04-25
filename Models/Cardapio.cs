namespace BarAPI.Models{
    public class Bebida{
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public bool Alcoolica { get; set; } // Define se é alcoólica ou não
    }
}
