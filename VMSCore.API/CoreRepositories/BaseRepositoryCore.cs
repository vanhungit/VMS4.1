using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VMSCore.API.DataValidation;
using VMSCore.API.EntityModels.Interfaces;
using VMSCore.API.EntityModels.Models;

namespace VMSCore.Infrastructure.Base.Repositories
{
    public class BaseRepositoryCore<T> : IRepository<T> where T : class
    {
        protected EntityDataContextCore _context;

        public BaseRepositoryCore(EntityDataContextCore dbContext)
        {
            _context = dbContext;
        }
        public DataToken JSONParserMapKho(string JSONdata)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(DataToken));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JSONdata));
            DataToken objStudent = (DataToken)jsonSer.ReadObject(stream);
            return objStudent;
        }
        public string CallAPIGet(string Link, string TokenData)
        {
            string Trave = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Link);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            string MaHoa = "Bearer " + TokenData;
            httpWebRequest.Headers.Add("Authorization", MaHoa);
            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = "[{\"color\":\"WHITE\"," +
            //                    "\"duration\":5," +
            //                  "\"pattern\":\"FLASH_4_TIMES\"}]";

            //    streamWriter.Write(json);
            //}

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Trave = result;
                }
            }
            else
            {
                Trave = httpResponse.StatusDescription;
            }
            return Trave;
        }
       
        public string CallAPIPOSTToken(string Link, string UserName, string Pass)
        {
            string Trave = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Link);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";

            httpWebRequest.Headers.Add("Cookie", ".AspNetCore.Culture=c%3Den%7Cuic%3Den");
       
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string postData = "grant_type=password&scope=offline_access%20IndustrialSolution&client_id=IndustrialSolution_App&username="+UserName +"&password=" + Pass;
                //byte[] postArray = Encoding.ASCII.GetBytes(postData);
                streamWriter.Write(postData);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Trave = result;
                }
            }
            else
            {
                Trave = httpResponse.StatusDescription;
            }
            return (Trave);
        }
        public BaseRepositoryCore()
        {
            _context = new EntityDataContextCore();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void DeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public void AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
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
        public T GetByCheckID(string ID)
        {
            if (typeof(IEntity).IsAssignableFrom(typeof(T)))
            {
                return _context.Set<T>().SingleOrDefault(e => ((IEntity)e).Id == ID);
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
