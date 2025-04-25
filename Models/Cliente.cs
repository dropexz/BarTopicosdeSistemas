namespace BarAPI.Models{
    public class Cliente{
        
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }

        // Calcula a idade automaticamente
        public int Idade => DateTime.Today.Year - DataNascimento.Year -
                            (DateTime.Today.DayOfYear < DataNascimento.DayOfYear ? 1 : 0);
    }
}
