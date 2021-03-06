﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SC.BL.Domain
{
  public class Ticket
  {
    //[Key] /* TOEGEVOEGD, nadien VERWIJDERD 'Fluent API' */
    public virtual int TicketNumber { get; set; }
    public virtual int AccountId { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage="Er zijn maximaal 100 tekens toegestaan")]
    public virtual string Text { get; set; }
    public virtual DateTime DateOpened { get; set; }
    //[Index] /* TOEGEVOEGD, nadien VERWIJDERD 'Fluent API' */
    public virtual TicketState State { get; set; }
          
    public virtual ICollection<TicketResponse> Responses { get; set; } /* TOEGEVOEGD 'virtual' for lazy-loading, if enabled on context (default) */
  }
}
