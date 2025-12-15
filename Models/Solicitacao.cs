using System.ComponentModel.DataAnnotations;

namespace SistemaAlmoxarifado.Models;

public class Solicitacao
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome do solicitante é obrigatório")]
    public string NomeSolicitante { get; set; } = string.Empty;

    [Required(ErrorMessage = "Setor é obrigatório")]
    public string Setor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Item solicitado é obrigatório")]
    public string ItemSolicitado { get; set; } = string.Empty;

    [Required(ErrorMessage = "Quantidade é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
    public int Quantidade { get; set; }

    public DateTime DataSolicitacao { get; set; } = DateTime.Now;

    public StatusSolicitacao Status { get; set; } = StatusSolicitacao.Pendente;
}

public enum StatusSolicitacao
{
    Pendente,
    Aprovado,
    Negado
}
