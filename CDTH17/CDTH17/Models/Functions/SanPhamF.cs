using CDTH17.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDTH17.Models.Functions
{
    public class SanPhamF
    {
        private MyDBContext context;
        public SanPhamF()
        {
            context = new MyDBContext();
        }
        // Trả về toàn bộ bảng
        public IQueryable<SanPham> DSSanPham
        {
            get { return context.SanPhams; }
        }
        // Trả về một đối tượng, khi biết Khóa
        public SanPham FindEntity(string MaSP)
        {
            SanPham dbEntry = context.SanPhams.Find(MaSP);
            return dbEntry;
        }

        // Thêm một đối tượng
        public string Insert(SanPham model)
        {
            SanPham dbEntry = context.SanPhams.Find(model.MaSP);

            if (dbEntry != null)
            {
                return null;

            }
            context.SanPhams.Add(model);
            context.SaveChanges();
            return model.MaSP;
        }

        // Sửa một đối tượng theo khóa
        public string Update(SanPham model)
        {
            SanPham dbEntry = context.SanPhams.Find(model.MaSP);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return null;
            }
            dbEntry.TenSP = model.TenSP;
            dbEntry.GiaSP = model.GiaSP;
            dbEntry.MoTa = model.MoTa;
            dbEntry.MaDM = model.MaDM;
            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return model.MaSP;
        }
       
        // Xóa một đối tượng theo Key
        public string Delete(string MaSP)
        {
            SanPham dbEntry = context.SanPhams.Find(MaSP);
            if (dbEntry == null)
            {
                return null;
            }
            context.SanPhams.Remove(dbEntry);
            context.SaveChanges();
            return MaSP;
        }
    }
}