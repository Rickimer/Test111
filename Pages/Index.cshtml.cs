using Companies_example1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test1.View;

namespace Test1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        CompaniesContext _dbContext;        
        public bool IsCorrect { get; set; } = true;
        public List<Query1>? Query{ get; set; }        

        public IndexModel(ILogger<IndexModel> logger
            , CompaniesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {            
            var f = from branch in _dbContext.CompaniesBranches
                    group branch by new { branch.CompanyId} into Branchesgroup
                    select new
                    {
                        Branchesgroup.Key.CompanyId,
                        Filials = String.Join(",", Branchesgroup.Select(x => x.Name))
                    ,                        
                    } into setFilials
                    join company in _dbContext.Companies on setFilials.CompanyId equals company.Id
                    join branchcompany in _dbContext.CompaniesBranches on setFilials.CompanyId equals branchcompany.CompanyId
                     from branch in
                       (from b in _dbContext.CompaniesBranches
                        group b by new { } into all
                        select new { Name = String.Join(",", all.Select(x => x.Name)) })
                    select new Query1
                    {
                        FilialName = branchcompany.Name,
                        CompanyName = company.Name,
                        BinarySign = company.BinarySign,
                        RelatedFilials = company.BinarySign ? branch.Name : setFilials.Filials                        
                    };
            
            Query = f.ToList();
            IsCorrect = true;

        }
    }
}
