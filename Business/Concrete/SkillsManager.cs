using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Ef;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SkillsManager(ISkillsDal skillsDal) : ISkillsService
    {
        private readonly ISkillsDal _skillsDal = skillsDal;
        public IResult Add(Skill skill)
        {
            _skillsDal.Add(skill);
            return new SuccessResult("skill elave olundu");
        }

        public IResult Delete(int id)
        {
            Skill deleteSkill = null;
            Skill resultSkill = _skillsDal.Get(m => m.IsDeleted == false && m.Id == id);
            if (resultSkill != null)
                deleteSkill = resultSkill;
            deleteSkill.IsDeleted = true;
            _skillsDal.Delete(deleteSkill);
            return new SuccessResult();
        }

        public IDataResult<List<Skill>> GetAllSkill()
        {
            var skills = _skillsDal.GetAll(m => m.IsDeleted == false).Take(4).ToList();
            if (skills.Count > 0)
                return new SuccessDataResult<List<Skill>>(skills);
            else return new ErrorDataResult<List<Skill>>("xeta bash verdi");
        }

        public IDataResult<Skill> GetSkill(int id)
        {
            Skill getSkills = _skillsDal.Get(m => m.Id == id);

            if (getSkills != null)
                return new SuccessDataResult<Skill>(getSkills, "get Skill loaded");
            else return new ErrorDataResult<Skill>(getSkills, "Skill tapilmadi");
        }

        public IResult Update(Skill skill)
        {
            Skill updateSkills;
            updateSkills = _skillsDal.Get(m => m.Id == skill.Id && m.IsDeleted == false);
            updateSkills.Id = skill.Id;
            updateSkills.IsDeleted = skill.IsDeleted;
            updateSkills.SkillsName = skill.SkillsName;


            _skillsDal.Update(updateSkills);
            return new SuccessResult();
        }
    }
}
