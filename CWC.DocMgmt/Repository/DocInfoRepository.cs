using Common.Repository;
using CWC.DocMgmt;
using CWC.DocMgmt.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductModule.Repository;

public class DocInfoRepository : GenericRepository<DocInfo>, IDocInfoRepository
{
    public DocInfoRepository(ApplicationDbContext context) : base(context)
    {

    }

}