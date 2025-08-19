using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Atleta
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Usuario é obrigatório.")]
    public long UsuarioId { get; set; }
    public decimal Peso {  get; set; } = decimal.Zero;
    public int Altura { get; set; } = 0;
    public string ? Apelido { get; set; } = string.Empty;
    public int Resistencia {  get; set; }
    public int Agilidade {  get; set; }
    public int Solo {  get; set; }
    public int Wrestling {  get; set; }
    public int FocoMental {  get; set; }
    public int Defesa {  get; set; }
    public int LutaEmPe {  get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    // Dados do atleta, como peso, faixa, etc (expansível depois)

    protected Atleta() { }
    public Atleta(long usuarioId)
    {
        UsuarioId = usuarioId;
    }
}
