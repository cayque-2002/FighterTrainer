using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Atleta
{
    public long Id { get; private set; }

    [Required(ErrorMessage = "Usuario é obrigatório.")]
    public long UsuarioId { get; private set; }
    public decimal Peso {  get; private set; }
    public int Altura {  get; private set; }
    public string Apelido { get; private set; }
    public int Resistencia {  get; private set; }
    public int Agilidade {  get; private set; }
    public int Solo {  get; private set; }
    public int Wrestling {  get; private set; }
    public int FocoMental {  get; private set; }
    public int Defesa {  get; private set; }
    public int LutaEmPe {  get; private set; }

    // Dados do atleta, como peso, faixa, etc (expansível depois)

    protected Atleta() { }
    public Atleta(long usuarioId)
    {
        UsuarioId = usuarioId;
    }
}
