using burger_shack_api.Models;
using burger_shack_api.db;
using System;
using System.Collections.Generic;
using burger_shack_api.Repositories;

namespace burger_shack_api.Services
{
    public class BurgersService
    {
        private readonly BurgerRepository _repo;

    public BurgersService(BurgerRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Burger> GetAll()
        {
            return _repo.GetAll();
        }
        public Burger GetOne(int id)
        {
            Burger found = _repo.GetOne(id);
            if(found == null)
            {
                throw new Exception("UH OH! BAD ID!");
            }
            return found;
        }
        public Burger Create(Burger newBurger)
        {
            _repo.Create(newBurger);
            return newBurger;
        }
        public Burger Edit(int id, Burger editBurger)
        {
            Burger found = GetOne(id);
            if(found == null)
            {
                throw new Exception("UH OH! BAD ID!");
            }
            found.name = editBurger.name != null ? editBurger.name : found.name;
            found.description = editBurger.description != null ? editBurger.description : found.description;
            found.price = editBurger.price > 0 ? editBurger.price : found.price;
            found.id = id;
            return _repo.Edit(found);
        }
        public string Delete(int id)
        {
            Burger found = GetOne(id);
            if(found == null)
            {
                throw new Exception("UH OH! BAD ID!");
            }
            return _repo.Delete(found);
        }
    }
}