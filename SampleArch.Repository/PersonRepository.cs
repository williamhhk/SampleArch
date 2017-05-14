﻿using SampleArch.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SampleArch.Repository
{

    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<Person> GetAll()
        {
            return _entities.Set<Person>().Include(x => x.Country).AsEnumerable();
        }

        public Person GetById(long id)
        {
            return _dbset.Include(x => x.Country).Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Person> GetByIdAsync(long id)
        {
            return await _dbset.Include(x => x.Country).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
