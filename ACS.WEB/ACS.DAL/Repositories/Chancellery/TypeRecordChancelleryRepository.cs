﻿using ACS.DAL.EF;
using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repositories
{
    class TypeRecordChancelleryRepository : IRepository<TypeRecordChancellery>

    {
        private ACSContext db;

        public TypeRecordChancelleryRepository(ACSContext context)
        {
            this.db = context;
        }

        public IEnumerable<TypeRecordChancellery> GetAll()
        {
            return db.TypeRecordChancelleries;
        }

        public TypeRecordChancellery Get(int id)
        {
            return db.TypeRecordChancelleries.Find(id);
        }

        public void Create(TypeRecordChancellery type, int editorId)
        {
            type.s_EditDate = type.s_DateCreation;
            type.s_AuthorId = editorId;
            type.s_EditorId = editorId;
            db.TypeRecordChancelleries.Add(type);
        }
        public void MoveToBasket(TypeRecordChancellery type, int editorId)
        {
            type.s_InBasket = true;
            Update(type, editorId);
        }
        public void Update(TypeRecordChancellery type, int editorId)
        {
            type.s_EditDate = DateTime.Now;
            type.s_EditorId = editorId;
            db.Entry(type).State = EntityState.Modified;
        }

        public IEnumerable<TypeRecordChancellery> Find(Func<TypeRecordChancellery, Boolean> predicate)
        {
            return db.TypeRecordChancelleries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TypeRecordChancellery type = db.TypeRecordChancelleries.Find(id);
            if (type != null)
                db.TypeRecordChancelleries.Remove(type);
        }
    }
}
