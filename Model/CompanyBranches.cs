using System.ComponentModel.DataAnnotations;

namespace Companies_example1.Model
{
    public class CompanyBranches
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CompanyId { get; set; }        
        public Company? Company { get; set; }
    }
}
