using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Companies_example1.Model
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool BinarySign { get; set; }
        public List<CompanyBranches>? CompaniesBranches { get; set; }
    }
}
