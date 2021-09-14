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
    public interface ISocietyInfoService
    {
        IQueryable<SocietyInfo> FindAll();
        IEnumerable<SocietyInfo> FindAllBySQL();
        Task<IEnumerable<SocietyInfo>> FindAllAsync();
        SocietyInfo FindById(int Id);
        Task<SocietyInfo> FindByIdAsync(int Id);
        bool Create(SocietyInfo model);
        bool Update(SocietyInfo model);
        bool Delete(SocietyInfo model);
        bool Save();
    }

    public class SocietyInfoService : ISocietyInfoService
    {
        #region variables
        private readonly ISocietyInfoRepository _societyInfoRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region constructor
        public SocietyInfoService(ISocietyInfoRepository societyInfoRepository, IUnitOfWork unitOfWork)
        {
            _societyInfoRepository = societyInfoRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion


        public bool Create(SocietyInfo model)
        {
            try
            {
                _societyInfoRepository.Create(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        
            return Save();
        }

        public bool Delete(SocietyInfo model)
        {
            _societyInfoRepository.Delete(model);
            return Save();
        }

        public IQueryable<SocietyInfo> FindAll()
        {
            return _societyInfoRepository.FindAll();
        }

        public IEnumerable<SocietyInfo> FindAllBySQL()
        {
            string query = string.Format(@"SELECT * FROM SocietyInfo");
            return _societyInfoRepository.SQLQueryList<SocietyInfo>(query);
        }

        public async Task<IEnumerable<SocietyInfo>> FindAllAsync()
        {
            return await _societyInfoRepository.FindAll().ToListAsync();
        }

        public SocietyInfo FindById(int Id)
        {
            return _societyInfoRepository.GetSocietyInfo(Id);
        }

        public async Task<SocietyInfo> FindByIdAsync(int Id)
        {
            return await _societyInfoRepository.GetAsync(s => s.Id == Id);
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

        public bool Update(SocietyInfo model)
        {
            _societyInfoRepository.Update(model);
            return Save();
        }
    }
}
