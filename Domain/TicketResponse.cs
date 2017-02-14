using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace SC.BL.Domain
{
  public class TicketResponse : IValidatableObject
  {
    public virtual int Id { get; set; }
    [Required]
    public virtual string Text { get; set; }
    public virtual DateTime Date { get; set; }
    public virtual bool IsClientResponse { get; set; }

    [Required]
    public virtual Ticket Ticket { get; set; }

    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
      List<ValidationResult> errors = new List<ValidationResult>();

      if (Date < Ticket.DateOpened)
      {
        errors.Add(new ValidationResult("Can't be before the date the ticket is created!", new string[] { "Date" }));
      }

      return errors;
    }
  }
}
