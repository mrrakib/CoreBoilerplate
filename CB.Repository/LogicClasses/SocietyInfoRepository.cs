using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.LogicClasses
{
    public class SocietyInfoRepository : RepositoryBase<SocietyInfo>, ISocietyInfoRepository
    {
        private readonly RepoContext _context;
        public SocietyInfoRepository(RepoContext context)
            : base(context)
        {
            _context = context;
        }

        public SocietyInfo GetSocietyInfo(int id)
        {
            return _context.SocietyInfos.Include("SocietyMembers").Where(s => s.Id == id).FirstOrDefault();
        }
    }

    public interface ISocietyInfoRepository : IRepositoryBase<SocietyInfo>
    {
        SocietyInfo GetSocietyInfo(int id);
    }
}
