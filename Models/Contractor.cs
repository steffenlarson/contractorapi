using System;
using System.ComponentModel.DataAnnotations;


namespace contractorapi.Models
{
  public class Contractor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}