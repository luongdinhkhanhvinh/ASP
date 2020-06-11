using CDTH17.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDTH17.Models.Functions
{
    public class DanhMucF
    {
        private MyDBContext context;
        public DanhMucF()
        {
            context = new MyDBContext();
        }
        // Trả về toàn bộ bảng
        public IQueryable<DanhMuc> DSDanhMuc
        {
            get { return context.DanhMucs; }
        }
        // Trả về một đối tượng, khi biết Khóa
        public DanhMuc FindEntity(int MaDM)
        {
            DanhMuc dbEntry = context.DanhMucs.Find(MaDM);
            return dbEntry;
        }

        // Thêm một đối tượng
        public int Insert(DanhMuc model)
        {
            DanhMuc dbEntry = context.DanhMucs.Find(model.MaDM);

            if (dbEntry != null)
            {
                return -1;

            }
            context.DanhMucs.Add(model);
            context.SaveChanges();
            return model.MaDM;
        }

        // Sửa một đối tượng theo khóa
        public int Update(DanhMuc model)
        {
            DanhMuc dbEntry = context.DanhMucs.Find(model.MaDM);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return -1;
            }
            dbEntry.TenDM = model.TenDM;
            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return model.MaDM;
        }
       
        // Xóa một đối tượng theo Key
        public int Delete(int MaDM)
        {
            DanhMuc dbEntry = context.DanhMucs.Find(MaDM);
            if (dbEntry == null)
            {
                return -1;
            }
            context.DanhMucs.Remove(dbEntry);
            context.SaveChanges();
            return MaDM;
        }
    }
}