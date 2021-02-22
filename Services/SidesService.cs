using System.Collections.Generic;
using burger_shack_api.Models;
using burger_shack_api.Repositories;
using System;
namespace burger_shack_api.Services
{
    public class SidesService
    {
    private readonly SideRepository _repo;

    public SidesService(SideRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Side> GetAll()
    {
        return _repo.GetAll();
    }

    public Side GetOne(int id)
    {
      Side found = _repo.GetOne(id);
      if (found == null)
      {
        throw new Exception("OOPSIE DAISY! THAT ID DID NOTHING!!!");
      }
      return found;
    }

    public Side Create(Side newSide)
    {
      return _repo.Create(newSide);
    }

    public Side Edit(int id, Side editSide)
    {
      Side found = GetOne(id);
       if (found == null)
      {
        throw new Exception("OOPSIE DAISY! THAT ID DID NOTHING!!!");
      }
      found.name = editSide.name != null ? editSide.name : found.name;
            found.description = editSide.description != null ? editSide.description : found.description;
            found.price = editSide.price > 0 ? editSide.price : found.price;
            found.id = id;
      return _repo.Edit(found);
    }



  }
}