using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using Repository.LogicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ISocietyMemberService
    {
        IQueryable<SocietyMember> FindAll();
        IEnumerable<SocietyMember> FindAllBySQL();
        Task<IEnumerable<SocietyMember>> FindAllAsync();
        SocietyMember FindById(int Id);
        Task<SocietyMember> FindByIdAsync(int Id);
        bool Create(SocietyMember model);
        bool Update(SocietyMember model);
        bool Delete(SocietyMember model);
        bool Save();
    }

    public class SocietyMemberService : ISocietyMemberService
    {
        #region variables
        private readonly ISocietyMemberRepository _societyMemberRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region constructor
        public SocietyMemberService(ISocietyMemberRepository societyMemberRepository, IUnitOfWork unitOfWork)
        {
            _societyMemberRepository = societyMemberRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion


        public bool Create(SocietyMember model)
        {
            try
            {
                _societyMemberRepository.Create(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        
            return Save();
        }

        public bool Delete(SocietyMember model)
        {
            _societyMemberRepository.Delete(model);
            return Save();
        }

        public IQueryable<SocietyMember> FindAll()
        {
            return _societyMemberRepository.FindAll();
        }

        public IEnumerable<SocietyMember> FindAllBySQL()
        {
            string query = string.Format(@"SELECT * FROM SocietyMembers");
            return _societyMemberRepository.SQLQueryList<SocietyMember>(query);
        }

        public async Task<IEnumerable<SocietyMember>> FindAllAsync()
        {
            return await _societyMemberRepository.FindAll().ToListAsync();
        }

        public SocietyMember FindById(int Id)
        {
            return _societyMemberRepository.Get(s => s.Id == Id);
        }

        public async Task<SocietyMember> FindByIdAsync(int Id)
        {
            return await _societyMemberRepository.GetAsync(s => s.Id == Id);
        }

        public bool Save()
        {
            try
            {
                var value=_unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(SocietyMember model)
        {
            _societyMemberRepository.Update(model);
            return Save();
        }
    }
}
