using System.ComponentModel.DataAnnotations;
public class GeraCartaoVirtual
{
  // O e-mail é obrigatório e só poderá ser persistido no banco de dados um e-mail válido
  public long Id { get; set; }

  [Required(ErrorMessage = "O e-mail é obrigatório")]
  [EmailAddress]
  public string Email { get; set; }

  public string NumeroCartao { get; set; }
}