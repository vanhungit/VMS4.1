using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using VMSCore.EntityModels;
using VMSCore.EntityModels.Interfaces;


namespace VMSCore.Infrastructure.Base.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected EntityDataContext _context;

        public BaseRepository(EntityDataContext dbContext)
        {
            _context = dbContext;
        }

        public BaseRepository()
        {
            _context = new EntityDataContext();
        }

        public T Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return entity;
        }
        public StatusResponse HamDongBoTable(string table, string Link, string jsonSend, DataToken objToken, Staff objuser)
        {
            StatusResponse objrp = new StatusResponse();
            if (table != "")
            {
                string TimeStart = "", TimeEnd = "";
                TimeStart = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                SyncDataFunction objSync = new SyncDataFunction();
                //string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                //DataToken objToken = objSync.JSONParserMapToken(Data);
                string ds = objSync.CallAPIPost(Link, objToken.access_token, jsonSend);
                TimeEnd = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                objrp = objSync.JSONParserResponse(ds);
                MACHINE_SYNC_LOG objMachineLog = new MACHINE_SYNC_LOG();
                objMachineLog.Id = Guid.NewGuid();
                objMachineLog.Code = objMachineLog.Id.ToString();
                objMachineLog.Name = table;
                objMachineLog.MethodName = Link;
                objMachineLog.TypeGiaoDich = "POST";
                objMachineLog.TokenCode = objToken.access_token;
                objMachineLog.JsonSend = jsonSend;
                objMachineLog.JsonReceiv = ds;
                objMachineLog.Status = objrp.idStatus.ToString();
                objMachineLog.Sorted = new MACHINE_SYNC_LOGRepository().GetMaxMACHINE_SYNC_LOG() + 1;
                objMachineLog.Description = objrp.jsonData + "|" + TimeStart + "|" + TimeEnd;
                objMachineLog.UserName = objuser.Username;
                objMachineLog.CreatedBy = objuser.Username;
                objMachineLog.ModifiedBy = objuser.Username;
                objMachineLog.CreatedDate = DateTime.Now;
                objMachineLog.ModifiedDate = DateTime.Now;
                objMachineLog.Active = true;
                new MACHINE_SYNC_LOGRepository().Add(objMachineLog);

            }
            return objrp;
        }
        public T AddSyncToken(T entity, string TableName, string jsonSend, Staff objuser)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                new SyncDataFunction().DongBoAll(TableName, jsonSend, objuser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public void DeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public void DeleteRangeSyncToken(List<T> entities, string TableName, string jsonSend, Staff objuser)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();
                new SyncDataFunction().DongBoAllDelete(TableName, jsonSend, objuser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }
        public void AddRangeSyncToken(List<T> entities, string TableName, string jsonSend, Staff objuser)
        {
            try
            {
                _context.Set<T>().AddRange(entities);
                _context.SaveChanges();
                new SyncDataFunction().DongBoAll(TableName, jsonSend, objuser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddRangeReturn(List<T> entities)
        {
            string Trave = "1";
            try
            {
                _context.Set<T>().AddRange(entities);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Trave = ex.ToString();
            }
            return Trave;
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByCode(string code)
        {
            if (typeof(ICodedEntity).IsAssignableFrom(typeof(T)))
            {
                return _context.Set<T>().SingleOrDefault(e => ((ICodedEntity)e).Code == code);
            }

            throw new InvalidOperationException("This method can't be called on an entity without a Code property");
        }
        
        public T GetByIdStr(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public List<T> GetAllByToken()
        {
            return _context.Set<T>().ToList();
        }
        // Example: var result = _repository.GetAll(x => x.Id, 0, 10);
        public List<T> GetAllByCondition(Func<T, bool> expression, Func<T, object> orderBy = null, int skip = 0, int take = int.MaxValue)
        {
            //IQueryable<T> query = (IQueryable<T>)_context.Set<T>().Where(expression);
            var query = _context.Set<T>().Where(expression);
            if (orderBy != null)
            {
                query = (IQueryable<T>)query.OrderBy(orderBy);
            }
            return query.Skip(skip).Take(take).ToList();
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public T UpdateSyncToken(T entity, string TableName, string jsonSend, Staff objuser)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                new SyncDataFunction().DongBoAll(TableName, jsonSend, objuser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }
        // Example: _repository.UpdateByCondition(x => x.Id == id, x => x.Name = "New Name");

        /*
         Example: 
            _repository.UpdateByCondition(x => x.Id == id, x => {
                x.Name = "New Name";
                x.Description = "New Description";
            });
         */

        public void UpdateByCondition(Func<T, bool> expression, Action<T> action)
        {
            var entities = _context.Set<T>().Where(expression);
            foreach (var entity in entities)
            {
                action(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public string DeleteSyncToken(Func<T, bool> expression, string TableName, string jsonSend, Staff objuser)
        {

            try
            {
                var entities = _context.Set<T>().Where(expression);
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();
                new SyncDataFunction().DongBoAllDelete(TableName, jsonSend, objuser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "1";
        }
        // Example: _repository.DeleteByCondition(x => x.Id == id);
        public void DeleteByCondition(Func<T, bool> expression)
        {
            var entities = _context.Set<T>().Where(expression);
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public int DeleteByIdStr(string id)
        {
            var entity = GetByIdStr(id);
            _context.Set<T>().Remove(entity);
            var rowsAffected = _context.SaveChanges();
            return rowsAffected;
        }

        public void DeleteRangeById(List<Guid> ids)
        {
            var entities = new List<T>();
            foreach (var id in ids)
            {
                var entity = GetById(id);
                entities.Add(entity);
            }
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void DeleteRangeByIdStr(List<string> ids)
        {
            var entities = new List<T>();
            foreach (var id in ids)
            {
                var entity = GetByIdStr(id);
                entities.Add(entity);
            }
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public T GetOneByCondition(Func<T, bool> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        
       
    }
}