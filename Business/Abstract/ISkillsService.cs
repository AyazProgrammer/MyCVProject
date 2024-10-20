using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkillsService
    {
        IResult Add(Skill skill);
        IResult Update(Skill skill);
        IResult Delete(int id);
        IDataResult<List<Skill>> GetAllSkill();
        IDataResult<Skill> GetSkill(int id);
    }
}
