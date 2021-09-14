using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.LogicClasses
{
    public class SocietyMemberRepository : RepositoryBase<SocietyMember>, ISocietyMemberRepository
    {
        public SocietyMemberRepository(RepoContext context)
            : base(context)
        {
        }
    }

    public interface ISocietyMemberRepository : IRepositoryBase<SocietyMember>
    {

    }
}
