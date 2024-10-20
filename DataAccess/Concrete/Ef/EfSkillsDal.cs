using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Ef
{
    public class EfSkillsDal : BaseRepository<Skill, BaseProjectContext>, ISkillsDal
    {
        public EfSkillsDal(BaseProjectContext context) : base(context)
        {
        }
    }
}
