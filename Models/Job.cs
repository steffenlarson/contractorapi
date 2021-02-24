using System;
using System.ComponentModel.DataAnnotations;


namespace contractorapi.Models
{
  public class Job
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

  }

  public class ContractorJobViewModel : Job
  {
    public int ContractorJobId { get; set; }
  }
}