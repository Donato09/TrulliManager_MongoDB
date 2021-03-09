using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrulliManager.Database.Models;

namespace TrulliManager.Repository.Abstract
{
  public interface ITrulliRepository
  {
    Task<IMongoQueryable<Trullo>> All();
    Task<Trullo> Create(Trullo trullo);
    Trullo Remove(Trullo trullo);
    Trullo ByKey(string id);
  }
}
