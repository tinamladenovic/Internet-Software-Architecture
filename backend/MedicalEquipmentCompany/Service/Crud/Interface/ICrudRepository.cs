﻿using MedicalEquipmentCompany.Model.Result;

namespace MedicalEquipmentCompany.Service.Crud.Interface;

public interface ICrudRepository<TEntity> where TEntity : Entity
{
    PagedResult<TEntity> GetPaged(int page, int pageSize);
    TEntity Get(long id);
    TEntity Create(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(long id);
}